using UnityEngine;
using System.Collections;

public class Blocker : Object {
	
	GameObject currentLane;
	// Use this for initialization
	//void Start () {
		
	//}
	
	// Update is called once per frame
	//void Update () {
	//	base.Update();
	//}
	
	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Player"){
<<<<<<< HEAD

			print(col.transform.renderer.material.color);

=======
>>>>>>> f42070a3e220e643bde654dbf6a6c289f83b84ce
			bool valid = true;
			if (col.transform.renderer.material.color.r != 0.0f){
				if (transform.renderer.material.color.r == 0.0f){
					valid = false;
				}
			}
			if (col.transform.renderer.material.color.g != 0.0f){
				if (transform.renderer.material.color.g == 0.0f){
					valid = false;
				}
			}
			if (col.transform.renderer.material.color.b != 0.0f){
				if (transform.renderer.material.color.b == 0.0f){
					valid = false;
				}
			}

			if (valid){
				Destroy(gameObject);
			}
<<<<<<< HEAD
=======
			/*if(!valid){
				Destroy(col.gameObject);	
			}*/
			/*
			if(currentLane.renderer.material.color == transform.renderer.material.color){
				Destroy(gameObject);	
			}
			*/

>>>>>>> f42070a3e220e643bde654dbf6a6c289f83b84ce
		}
	}
	
	void GetCurrentLane(GameObject lane){
		currentLane = lane;
	}
}
