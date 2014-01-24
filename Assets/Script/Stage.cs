using UnityEngine;
using System.Collections;

public class Stage : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		StartCoroutine("SpawnBlocker");
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
	
	IEnumerator SpawnBlocker(){
		yield return new WaitForSeconds(10);
		
		Blocker blocker = new Blocker();
		
		blocker.y = Screen.width/2;
		blocker.x = Screen.height/2;
	}
}
