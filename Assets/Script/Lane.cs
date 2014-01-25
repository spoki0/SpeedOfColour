using UnityEngine;
using System.Collections;

public class Lane : MonoBehaviour {
	
	public Rigidbody[] arrayObjects;
	public Color gateColour;
	public Color laneColour;
	public GameObject blocker;
	public bool needsColour;
	public bool hasPlayerOn;
	Color defaultColour;
	int randomSpawn;

	// Use this for initialization
	void Start () {
		defaultColour = transform.renderer.material.color;
		StartCoroutine("SpawnObject");
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasPlayerOn){
			LaneColour(defaultColour);
		}
	}
	
	void AddGate(bool isChosen){
		needsColour = isChosen;
		GameObject currentBlocker = (GameObject)Instantiate(blocker, blocker.transform.position, blocker.transform.rotation);
		
		currentBlocker.SendMessage("GetCurrentLane", gameObject);
		currentBlocker.transform.position = new Vector3(transform.position.x+50,0,transform.position.z);

		Color gateColour = new Color(0,0,0);

		if(isChosen){
			Color col1 = Main.listColours[Random.Range(0, Main.listColours.Count)];
			Color col2 = Main.listColours[Random.Range(0, Main.listColours.Count)];

			gateColour.r = (col1.r + col2.r)/2;
			gateColour.g = (col1.g + col2.g)/2;
			gateColour.b = (col1.b + col2.b)/2;

			print (gateColour.r + gateColour.g + gateColour.b);
		}
		else{
			gateColour = currentBlocker.renderer.material.color;
			gateColour.r = 0.0f;
			gateColour.g = 0.0f;
			gateColour.b = 0.0f;
		}

		currentBlocker.renderer.material.color = gateColour;	

	}
	
	void LaneColour(Color characterColour){
		laneColour = transform.renderer.material.color;
		laneColour.r -= (laneColour.r - characterColour.r)/5;
		laneColour.b -= (laneColour.b - characterColour.b)/5;
		laneColour.g -= (laneColour.g - characterColour.g)/5;
		
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
