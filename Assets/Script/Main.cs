using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	
	public static float ultimateSpeed = -1 * Time.deltaTime;
	
	// Use this for initialization
	void Start () {
		StartGame();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void StartGame(){
		Stage stage = new Stage();
	}
}
