using UnityEngine;
using System.Collections;

public class SlowPower : Object {

	// Use this for initialization
	void Start () {
		base.Start();
		
		Color tempColour = transform.renderer.material.color;
		tempColour.g = 0.5f;
		tempColour.r = 0;
		tempColour.b = 0.5f;
		
		transform.renderer.material.color = tempColour;
	}
	
	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Player"){
			col.gameObject.GetComponent<Character>().countDown += 50;
			col.gameObject.GetComponent<Character>().boost -= 0.5f;
		}
	}
	// Update is called once per frame
	//void Update () {
	
	//}
}
