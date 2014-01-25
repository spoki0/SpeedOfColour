using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stage : MonoBehaviour {
	
	public Rigidbody lane = new Rigidbody();
	public Rigidbody blocker;
	List<GameObject> listLanes = new List<GameObject>();
	
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
			
			lane.transform.position = new Vector3(0,0,Screen.height/5* i/10-23);
			listLanes.Add(lane.gameObject);
		}
	}
	
	IEnumerator SpawnBlocker(){
		yield return new WaitForSeconds(1);
		ColourLane();
		
		Instantiate(blocker, blocker.transform.position, blocker.transform.rotation);
		
		blocker.transform.position = new Vector3(transform.position.x+50,0,transform.position.z);
		StartCoroutine("SpawnBlocker");
	}
	
	void ColourLane(){
		int randomNr = Random.Range(0, listLanes.Count);
		listLanes[randomNr].SendMessage("AddColour");
	}
}
