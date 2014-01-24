using UnityEngine;
using System.Collections;

public class Stage : MonoBehaviour {
	
	public Rigidbody lane;
	public Rigidbody blocker;
	
	// Use this for initialization
	void Start () {
		SpawnLanes();
		StartCoroutine("SpawnBlocker");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void SpawnLanes(){
		for(int i = 1; i <= 5; i++){
			Instantiate(lane, lane.transform.position, lane.transform.rotation);
			
			lane.transform.position = new Vector3(0,0,Screen.height/5* i/10-20);
		}
	}
	
	IEnumerator SpawnBlocker(){
		yield return new WaitForSeconds(1);
		
		Instantiate(blocker, blocker.transform.position, blocker.transform.rotation);
		
		blocker.position = new Vector3(Screen.height/2,Screen.width/2,0);
		StartCoroutine("SpawnBlocker");
	}
}
