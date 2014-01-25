﻿using UnityEngine;
using System.Collections;

public class SpeedPower : Object {

	// Use this for initialization
	//void Start () {
	//}
	
	// Update is called once per frame
	//void Update () {
	//	base.Update();
	//}
	
	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Player"){
			col.gameObject.GetComponent<Character>().countDown = 20;
			col.gameObject.GetComponent<Character>().boost += 2;
		}
	}
}
