using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	
	public int playerScore;
	public int userID;
	int lane;
	float xpos;
	float speed;
	public float boost;
	public int countDown;
	Color colour;
	GameObject currentLane;

	// Use this for initialization
	void Start () {
		countDown = 0;
	}

	void setID(int _id){
		userID = _id;
		lane = _id;
		xpos = 0;
		speed = 1;
		transform.position = new Vector3(0, 7, Screen.height/5* lane/10-23);

		colour = Main.listColours[ _id-1 ];
		
		ChangeColour();
	}
	
	void OnTriggerStay(Collider col){
		currentLane = col.gameObject;
		if(col.gameObject.name == "Lane(Clone)"){
			col.GetComponent<Lane>().hasPlayerOn = true;
			col.gameObject.SendMessage("LaneColour", colour);
		}
	}
	void OnTriggerExit(Collider col){
		if(col.gameObject.name == "Lane(Clone)"){
			col.GetComponent<Lane>().hasPlayerOn = false;
			col.GetComponent<Lane>().nrPlayersOn --;
		}
	}
	void OnTriggerEnter(Collider col){
		if(col.gameObject.name == "Lane(Clone)"){
			col.GetComponent<Lane>().nrPlayersOn ++;	
		}
	}

	void ChangeColour(){
		transform.renderer.material.color = colour;	
	}

	// Update is called once per frame
	void Update () {
		if(countDown == 0){	boost = 0; }
		if(countDown > 0){ countDown --; }
		
		//move up
		if(Input.GetKeyDown(Main.keys[userID-1][0]) ){
			lane--; if (lane < 1){lane = 1;}
		}

		//move down
		else if(Input.GetKeyDown(Main.keys[userID-1][1]) ){
			lane++; if (lane > 5){lane = 5;}
		}

		//move left
		else if(Input.GetKey(Main.keys[userID-1][2]) ){
			xpos = xpos-speed-boost; if(xpos < -45){ Destroy(gameObject);}
		}

		//move right
		else if(Input.GetKey(Main.keys[userID-1][3]) ){
			xpos = xpos+speed+boost; if(xpos > 40){xpos = 40; }
		}

		//actual movements, fit plane
		transform.position = new Vector3(xpos, 3, Stage.listLanes[lane-1].transform.position.z);
		
		IncreaseScore();
	}
	
	void IncreaseScore(){
		Main.listScores[userID] ++;
	}
	
	IEnumerator WaitDestroy(){
		yield return new WaitForSeconds(2);
		Destroy(gameObject);	
	}
	
	void OnDisable(){
		if(currentLane){
			currentLane.GetComponent<Lane>().hasPlayerOn = false;
			currentLane.GetComponent<Lane>().nrPlayersOn --;
		}
		Main.listColours.Remove(colour);
		Stage.listPlayers.Remove(gameObject);
		
		for(int i = 0; i<Stage.listBlockers.Count; i++){
			Destroy(Stage.listBlockers[i]);
		}
		if(Main.nrPlayers > 1)
			Main.listScores.Remove(playerScore);
	}
}
