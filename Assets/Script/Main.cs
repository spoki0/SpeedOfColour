using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Main : MonoBehaviour {
	
	public static float ultimateSpeed = -10;
	public static List<Color> listColours = new List<Color>();
	public GameObject stage;
	Color randomColour;
	int randomCInt;
	public static int nrPlayers;
	
	// Use this for initialization
	void Start () {
		StartGame();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void StartGame(){
		nrPlayers = 1;
		
		for(int i = 1; i <= nrPlayers; i++){

			randomColour = new Color(0,0,0);

			randomColour.r = i%2;
			randomColour.g = i/2%2;
			randomColour.b = i/4%2;

			listColours.Add(randomColour);

		}
		
		
		Instantiate(stage, new Vector3(0,0,0), stage.transform.rotation);
	}
}
