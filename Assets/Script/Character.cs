using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	int userID;
	int lane;
	int xpos;
	float speed;
	Color colour;
	GameObject currentLane;

	// Use this for initialization
	void Start () {

	}

	void setID(int _id){
		userID = _id;
		lane = _id;
		xpos = 0;
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
	
		//move up
		if(Input.GetKeyDown(Main.keys[userID-1][0]) ){
			lane++; if (lane > 5){lane = 5;}
		}
		//move down
		if(Input.GetKeyDown(Main.keys[userID-1][1]) ){
			lane--; if (lane < 1){lane = 1;}
		}
		//move left
		if(Input.GetKeyDown(Main.keys[userID-1][2]) ){
			xpos -= 5;
		}
		//move right
		if(Input.GetKeyDown(Main.keys[userID-1][3]) ){
			xpos += 5;
		}

		//actual movements, fit plane
		transform.position = new Vector3(xpos, 3, Screen.height/50*lane-23);

	}
	IEnumerator WaitDestroy(){
		yield return new WaitForSeconds(2);
		Destroy(gameObject);	
	}
	
	void OnDisable(){
		if(currentLane){
			currentLane.GetComponent<Lane>().hasPlayerOn = false;
		}
		Main.listColours.Remove(colour);
		Stage.listPlayers.Remove(gameObject);
		
		for(int i = 0; i<Stage.listBlockers.Count; i++){
			Destroy(Stage.listBlockers[i]);
		}
	}
}
