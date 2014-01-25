using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	int userID;
	int lane;
	float speed;
	Color colour;
		

	// Use this for initialization
	void Start () {

	}

	void setID(int _id){
		//userID = _id;
		lane = _id;
		//speed = Main.ultimateSpeed;
		transform.position = new Vector3(0, 7, Screen.height/5* lane/10-23);

		colour = Main.listColours[ _id-1 ];
		
		ChangeColour();
	}
	
	void OnTriggerEnter(Collider col){
		if(col.gameObject.name == "Lane(Clone)"){
			col.gameObject.SendMessage("LaneColour", colour);
		}
	}
	void OnTriggerExit(Collider col){
		if(col.gameObject.name == "Lane(Clone)"){
			Color tempColour = transform.renderer.material.color;
			tempColour.r = 1;
			tempColour.g = 1;
			tempColour.b = 1;
			col.gameObject.SendMessage("LaneColour", tempColour);
		}
	}
	
	void ChangeColour(){
		transform.renderer.material.color = colour;	
	}

	// Update is called once per frame
	void Update () {
	
		//move up
		if(Input.GetKeyDown(KeyCode.UpArrow) ){
			lane++; if (lane > 5){lane = 5;}
		}
		//move down
		if(Input.GetKeyDown(KeyCode.DownArrow) ){
			lane--; if (lane < 1){lane = 1;}
		}

		//actual movements, fit plane
		transform.position = new Vector3(0, 6, Screen.height/5* lane/10-23);

	}
	
	void OnDisable(){
		Main.listColours.Remove(colour);
	}
}
