using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Main : MonoBehaviour {
	
	public static float ultimateSpeed = -10;
	public static List<Color> listColours = new List<Color>();
	public static List< List<KeyCode> > keys = new List< List<KeyCode> >();
	public GameObject stage;
	public static List<int> listScores = new List<int>();
	Color randomColour;
	int randomCInt;
	public static int nrPlayers;
	
	// Use this for initialization
	void Start () {
		soundClass = SoundControl;
		QualitySettings.antiAliasing = 4;
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

		List<KeyCode> Player3 = new List<KeyCode>();
		Player3.Add(KeyCode.Y);
		Player3.Add(KeyCode.H);
		Player3.Add(KeyCode.G);
		Player3.Add(KeyCode.J);

		List<KeyCode> Player4 = new List<KeyCode>();
		Player4.Add(KeyCode.Keypad5);
		Player4.Add(KeyCode.Keypad2);
		Player4.Add(KeyCode.Keypad1);
		Player4.Add(KeyCode.Keypad3);

		keys.Add(Player1);
		keys.Add(Player2);
		keys.Add(Player3);
		keys.Add(Player4);

		StartGame();
	}
	
	// Update is called once per frame
	void Update () {
		GameOver();
	}
	
	void StartGame(){

		nrPlayers = 4;
		
		for(int i = 1; i <= nrPlayers; i++){

			randomColour = new Color(0,0,0);

			randomColour.r = i%2;
			randomColour.g = i/2%2;
			randomColour.b = i/4%2;

			listColours.Add(randomColour);

		}
		
		
		Instantiate(stage, new Vector3(0,0,0), stage.transform.rotation);
	}
	
	void GameOver(){
		if(listColours.Count <= 0){
			PlayerPrefs.SetInt("PlayerScore", listScores[1]);
			PlayerPrefs.SetInt("TeamScore", listScores[0]);
			Application.LoadLevel(2);
		}
	}
}
