using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Main : MonoBehaviour {
	
	public static float ultimateSpeed = -10;
	public static List<Color> listColours = new List<Color>();
	public static List< List<KeyCode> > keys = new List< List<KeyCode> >();
	public GameObject stage;
	Color randomColour;
	int randomCInt;
	public static int nrPlayers;
	
	// Use this for initialization
	void Start () {

		List<KeyCode> Player1 = new List<KeyCode>();
		Player1.Add(KeyCode.UpArrow);
		Player1.Add(KeyCode.DownArrow);
		Player1.Add(KeyCode.LeftArrow);
		Player1.Add(KeyCode.RightArrow);

		List<KeyCode> Player2 = new List<KeyCode>();
		Player2.Add(KeyCode.W);
		Player2.Add(KeyCode.S);
		Player2.Add(KeyCode.A);
		Player2.Add(KeyCode.D);

		keys.Add (Player1);
		keys.Add (Player2);






		StartGame();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void StartGame(){
		nrPlayers = 2;
		
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
