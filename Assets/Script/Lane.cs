using UnityEngine;
using System.Collections;

public class Lane : MonoBehaviour {
	
	public Rigidbody[] arrayObjects;
	public Color gateColour;
	public Color laneColour;
	public GameObject blocker;
	public bool needsColour;
	int randomSpawn;

	// Use this for initialization
	void Start () {
		StartCoroutine("SpawnObject");
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void AddGate(bool isChosen){
		needsColour = isChosen;
		GameObject currentBlocker = (GameObject)Instantiate(blocker, blocker.transform.position, blocker.transform.rotation);
		
		currentBlocker.SendMessage("GetCurrentLane", gameObject);
		currentBlocker.transform.position = new Vector3(transform.position.x+50,0,transform.position.z);
		
		if(isChosen){
			int randomNr = Random.Range(0, Main.listColours.Count);
			Color randomColour = Main.listColours[randomNr];
			randomNr = Random.Range(0, Main.listColours.Count);
			Color randomColour2 = Main.listColours[randomNr];
			
			gateColour = currentBlocker.renderer.material.color;
			gateColour.r = (randomColour.r + randomColour2.r)/2;
			gateColour.b = (randomColour.b + randomColour2.b)/2;
			gateColour.g = (randomColour.g + randomColour2.g)/2;
			currentBlocker.renderer.material.color = gateColour;
		}
		else{
			gateColour = currentBlocker.renderer.material.color;
			gateColour.r = 0.5f;
			gateColour.b = 0.5f;
			gateColour.g = 0.5f;
			currentBlocker.renderer.material.color = gateColour;	
		}
	}
	
	void LaneColour(Color characterColour){
		laneColour = transform.renderer.material.color;
		laneColour.r -= (laneColour.r - characterColour.r)/20;
		laneColour.b -= (laneColour.b - characterColour.b)/20;
		laneColour.g -= (laneColour.g - characterColour.g)/20;
		
		transform.renderer.material.color = laneColour;
	}
	
	IEnumerator SpawnObject(){
		yield return new WaitForSeconds(5);
		randomSpawn = Random.Range(0,2);
		
		if(randomSpawn == 0){
			randomSpawn = Random.Range(0,2);
			if(randomSpawn == 0)
				Instantiate(arrayObjects[randomSpawn],new Vector3(transform.position.x+50, transform.position.y, transform.position.z),arrayObjects[randomSpawn].rotation);
		}
		StartCoroutine("SpawnObject");
	}
}
