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
		userID = _id;
		lane = _id;
		speed = Main.ultimateSpeed;
		transform.position = new Vector3(0, 0, Screen.height/5* lane/10-23);
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
		transform.position = new Vector3(0, 0, Screen.height/5* lane/10-23);

	}
}
