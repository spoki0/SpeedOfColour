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
		
		currentBlocker.transform.position = new Vector3(transform.position.x+50,0,transform.position.z);
		
		if(isChosen){
			gateColour = currentBlocker.renderer.material.color;
			gateColour.r = 1;
			gateColour.b = 0;
			gateColour.g = 0;
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
		laneColour.r -= (laneColour.r - characterColour.r)/50;
		laneColour.b -= (laneColour.b - characterColour.b)/50;
		laneColour.g -= (laneColour.g - characterColour.g)/50;
		
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
