using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Main : MonoBehaviour {
	
	public static float ultimateSpeed = -10;
	public static List<Color> listColours = new List<Color>();
	public GameObject stage;
	Color randomColour;
	int randomCInt;
	int nrPlayers;
	
	// Use this for initialization
	void Start () {
		StartGame();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void StartGame(){
		nrPlayers = 1;
		
		for(int i = 0; i<nrPlayers; i++){
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
			
			listColours.Add(randomColour);
		}
		
		
		Instantiate(stage, new Vector3(0,0,0), stage.transform.rotation);
	}
}
