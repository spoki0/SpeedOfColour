using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Main : MonoBehaviour {
	
	public static float ultimateSpeed = -10;
	public List<Color> listColours = new List<Color>();
	public GameObject stage;
	int randomCInt;
	
	// Use this for initialization
	void Start () {
		StartGame();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void StartGame(){
		Color randomColour;
		randomColour.g = 0;
		randomColour.r = 0;
		randomColour.b = 0;
		randomCInt = Random.Range(0, 3);
		if(randomCInt == 0)
			randomColour.r = 1;
		if(randomCInt == 1)
			randomColour.g = 1;
		if(randomCInt == 2)
			randomColour.b = 1;
		
		
		Instantiate(stage, new Vector3(0,0,0), stage.transform.rotation);
	}
}
