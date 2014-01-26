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
	public int nrPlayersOn;

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
		/*
		transform.position = new Vector3(transform.position.x-0.25f, transform.position.y, transform.position.z);
		if (transform.position.x <= -110){transform.position = new Vector3((38+150), transform.position.y, transform.position.z);}
		*/
	}
	
	void AddGate(bool isChosen){
		needsColour = isChosen;
		GameObject currentBlocker = (GameObject)Instantiate(blocker, blocker.transform.position, blocker.transform.rotation);
		
		Stage.listBlockers.Add(currentBlocker);
		currentBlocker.SendMessage("GetCurrentLane", gameObject);
		currentBlocker.transform.position = new Vector3(40,0,transform.position.z);

		Color gateColour = new Color(0,0,0);

		if(isChosen){
			Color col1 = Main.listColours[Random.Range(0, Main.listColours.Count)];
			Color col2 = Main.listColours[Random.Range(0, Main.listColours.Count)];
			
			gateColour.r = 0;
			gateColour.g = 0;
			gateColour.b = 0;
			
			gateColour.r = (col1.r + col2.r)/2;
			gateColour.g = (col1.g + col2.g)/2;
			gateColour.b = (col1.b + col2.b)/2;
		}
		else{
			gateColour = currentBlocker.renderer.material.color;
			gateColour.r = 0.5f;
			gateColour.g = 0.5f;
			gateColour.b = 0.5f;
		}

		currentBlocker.renderer.material.color = gateColour;	

	}
	
	void LaneColour(Color characterColour){
		if(nrPlayersOn < 3){
			laneColour = transform.renderer.material.color;
			laneColour.r -= (laneColour.r - characterColour.r)/15;
			laneColour.b -= (laneColour.b - characterColour.b)/15;
			laneColour.g -= (laneColour.g - characterColour.g)/15;
		}else{
			laneColour.r -= (laneColour.r - 1f)/15;
			laneColour.b -= (laneColour.b - 1f)/15;
			laneColour.g -= (laneColour.g - 1f)/15;
		}
		//laneColour.a = 0.3f;
		//transform.renderer.material.shader = Shader.Find( "Transparent/Diffuse" );
		transform.renderer.material.color = laneColour;
	}
	
	IEnumerator SpawnObject(){
		yield return new WaitForSeconds(7);
		randomSpawn = Random.Range(0,3);
		
		if(randomSpawn == 0){
			randomSpawn = Random.Range(0,arrayObjects.Length);
			Instantiate(arrayObjects[randomSpawn],new Vector3(45, transform.position.y+3, transform.position.z),arrayObjects[randomSpawn].rotation);
		}
		StartCoroutine("SpawnObject");
	}
	
	void OnDisable(){
		Stage.listLanes.Remove(gameObject);	
	}
}
