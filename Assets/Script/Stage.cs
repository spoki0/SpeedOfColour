using UnityEngine;
using System.Collections;

public class Stage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void SpawnLanes(){
		for(int i = 0; i < 5; i++){
			Lane lane = new Lane();
			
			lane.y = Screen.height/5 * i;
			lane.x = Screen.width/2;
		}
	}
}
