﻿using UnityEngine;
using System.Collections;

public class Object : MonoBehaviour {
	
	// Use this for initialization
	protected virtual void Start () {
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		MoveSelf();

		if (transform.position.x < -45){
			Destroy(gameObject);
		}
	}	
	
	public void MoveSelf(){
		Vector3 speed = new Vector3(Main.ultimateSpeed,0,0);
		transform.rigidbody.AddForce(speed);	
	}
}
