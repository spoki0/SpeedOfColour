using UnityEngine;
using System.Collections;

public class Object : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//MoveSelf();
	}	
	
	public void MoveSelf(){
		Vector3 speed = new Vector3(Main.ultimateSpeed,0,0);
		transform.rigidbody.AddForce(speed);	
	}
}
