using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stage : MonoBehaviour {
	
	public Rigidbody lane = new Rigidbody();
	public Rigidbody player = new Rigidbody();

	List<GameObject> listLanes = new List<GameObject>();
	public static List<GameObject> listPlayers = new List<GameObject>();
	
	// Use this for initialization
	void Start () {
		SpawnLanes();
		SpawnPlayers(Main.nrPlayers);
		StartCoroutine("SpawnBlocker");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void SpawnLanes(){
		for(int i = 1; i <= 5; i++){
			GameObject currentLane = (GameObject)Instantiate(lane.gameObject, lane.transform.position, lane.transform.rotation);
			
			currentLane.transform.position = new Vector3(0,0,Screen.height/5*i/10-23);
			listLanes.Add(currentLane);
		}
	}

	void SpawnPlayers(int _num){
		for (int i = 1; i <= _num; i++){
			GameObject currentPlayer = (GameObject)Instantiate(player.gameObject, player.transform.position, player.transform.rotation);
			listPlayers.Add(currentPlayer);

			currentPlayer.SendMessage("setID", i);
			currentPlayer.transform.position = listLanes[ i-1 ].transform.position;
		}
	}



	IEnumerator SpawnBlocker(){
		yield return new WaitForSeconds(2);
		
		int chosenGate = Random.Range(0,listLanes.Count);
		
		for(int i = 0; i <= listLanes.Count-1; i++){
			if(i == chosenGate){
				listLanes[i].SendMessage("AddGate", true);
			} else {
				listLanes[i].SendMessage("AddGate", false);
			}
		}
		
		StartCoroutine("SpawnBlocker");
	}
}
