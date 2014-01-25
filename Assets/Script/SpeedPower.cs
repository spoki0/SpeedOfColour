﻿using UnityEngine;
using System.Collections;

public class SpeedPower : Object {
	
	// Use this for initialization
	void Start () {
		base.Start();
		
		Color tempColour = transform.renderer.material.color;
		tempColour.g = 0.5f;
		tempColour.r = 0.5f;
		tempColour.b = 0;
		
		transform.renderer.material.color = tempColour;
	}
	
	// Update is called once per frame
	//void Update () {
	//	base.Update();
	//}
	
	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Player"){
			col.gameObject.GetComponent<Character>().countDown += 50;
			col.gameObject.GetComponent<Character>().boost += 0.5f;
		}
		DestroyObject(gameObject);
	}
}
