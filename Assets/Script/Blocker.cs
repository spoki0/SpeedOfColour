﻿using UnityEngine;
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

			bool valid = true;
			if (currentLane.renderer.material.color.r >= 0.4f){
				if (transform.renderer.material.color.r == 0.0f){
					valid = false;
				}
			}
			if (currentLane.renderer.material.color.g >= 0.4f){
				if (transform.renderer.material.color.g == 0.0f){
					valid = false;
				}
			}
			if (currentLane.renderer.material.color.b >= 0.4f){
				if (transform.renderer.material.color.b == 0.0f){
					valid = false;
				}
			}

			if (valid){
				Destroy(gameObject);
			}
		}
	}
	
	void GetCurrentLane(GameObject lane){
		currentLane = lane;
	}
}
