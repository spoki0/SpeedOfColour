﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stage : MonoBehaviour {
	
	public Rigidbody lane = new Rigidbody();
	public Rigidbody player = new Rigidbody();
	public Rigidbody player2 = new Rigidbody();
	public Rigidbody player3 = new Rigidbody();
	public Rigidbody player4 = new Rigidbody();
	public Rigidbody[] players;
	public int mainScore;

	public static List<GameObject> listLanes = new List<GameObject>();
	public static List<GameObject> listBlockers = new List<GameObject>();
	public static List<GameObject> listPlayers = new List<GameObject>();
	
	// Use this for initialization
	void Start () {
		SpawnLanes();
		SpawnPlayers(Main.nrPlayers);
		StartCoroutine("SpawnBlocker");
	}
	
	// Update is called once per frame
	void Update () {
		IncreaseMainScore();
	}
	
	void IncreaseMainScore(){
		Main.listScores[0] ++;	
	}
	
	void SpawnLanes(){
		//First set of lanes
		for(int i = 0; i < 5; i++){
			
			//scrolle fra x = 38 -> x = -39 -Random.Range(0, 70)
			GameObject currentLane = (GameObject)Instantiate(lane.gameObject, lane.transform.position, lane.transform.rotation);
			currentLane.transform.position = new Vector3((30-Random.Range(0, 60)), 0, 16 - currentLane.renderer.bounds.size.z*i);

			listLanes.Add(currentLane);
		}
	}

	void SpawnPlayers(int _num){
		Main.listScores.Add(mainScore);
		for (int i = 1; i <= _num; i++){
			GameObject currentPlayer = new GameObject(); 
			currentPlayer = (GameObject)Instantiate(players[i-1].gameObject, player.transform.position, player.transform.rotation);
			listPlayers.Add(currentPlayer);
			Main.listScores.Add(currentPlayer.GetComponent<Character>().playerScore);

			currentPlayer.SendMessage("setID", i);
			currentPlayer.transform.position = listLanes[ i-1 ].transform.position;
		}
	}



	IEnumerator SpawnBlocker(){
		yield return new WaitForSeconds(2);
		
		int chosenGate = Random.Range(0,listLanes.Count);

		int temp = Random.Range(0, 2);
		if( temp == 0){

			for(int i = 0; i < listLanes.Count; i++){
				if(i == chosenGate){
					listLanes[i].SendMessage("AddGate", true);
				} else {
					listLanes[i].SendMessage("AddGate", false);
				}
			}
		}

		else{
			listLanes[chosenGate].SendMessage("AddGate", false);
		}
		
		StartCoroutine("SpawnBlocker");
	}
}
