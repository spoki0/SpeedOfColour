using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	
	public static float ultimateSpeed = -10;
	public GameObject stage;
	
	// Use this for initialization
	void Start () {
		StartGame();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void StartGame(){
		Instantiate(stage, new Vector3(0,0,0), stage.transform.rotation);
	}
}
