﻿using UnityEngine;
using System.Collections;

public class SlowPower : Object {

	// Use this for initialization
	void Start () {
		base.Start();
	}
	
	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Player"){
			col.gameObject.GetComponent<Character>().countDown = 50;
			col.gameObject.GetComponent<Character>().boost -= 0.5f;

			SoundControl.PlaySound( Main.userNames[ col.gameObject.GetComponent<Character>().userID ] + "PowerUp" );
			
		}
		DestroyObject(gameObject);
	}
	// Update is called once per frame
	//void Update () {
	
	//}
}
