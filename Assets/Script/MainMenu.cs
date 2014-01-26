using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public Rect menuArea;
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
		
		if(GUI.Button(menuArea, new GUIContent("Start"))){
			Application.LoadLevel(1);
		}
		
		GUI.EndGroup();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
