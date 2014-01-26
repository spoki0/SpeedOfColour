using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	
	public Rect menuArea;
	public Rect playButton;
	public Rect playerScore;
	public Rect teamScore;
	Rect menuAreaNormalized;
	
	//GUI Skins
	public GUISkin mainMenu;
	
	// Use this for initialization
	void Start () {
		menuAreaNormalized = new Rect(menuArea.x * Screen.width - (menuArea.width * 0.5f),
			menuArea.y * Screen.height - (menuArea.height * 0.5f), 
			menuArea.width, menuArea.height);
	}
	
	void OnGUI(){
		GUI.skin = mainMenu;
		GUI.BeginGroup(menuAreaNormalized);
		
		if(GUI.Button(playButton, new GUIContent("Play Again"))){
			Application.LoadLevel(1);
		}
		
		GUI.Label(playerScore, "" +PlayerPrefs.GetInt("PlayerScore"));
		
		GUI.EndGroup();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
