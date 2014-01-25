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
			if(currentLane.renderer.material.color == transform.renderer.material.color){
				Destroy(gameObject);	
			}
		}
	}
	
	void GetCurrentLane(GameObject lane){
		currentLane = lane;
	}
}
