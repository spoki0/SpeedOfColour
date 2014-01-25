using UnityEngine;
using System.Collections;

public class Lane : MonoBehaviour {
	
	public Rigidbody[] arrayObjects;
	public Color colourValues;
	public GameObject blocker;
	int randomSpawn;

	// Use this for initialization
	void Start () {
		StartCoroutine("SpawnObject");
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void AddGate(bool isChosen){
		GameObject currentBlocker = (GameObject)Instantiate(blocker, blocker.transform.position, blocker.transform.rotation);
			
		currentBlocker.transform.position = new Vector3(transform.position.x+50,0,transform.position.z);
		
		if(isChosen){
			colourValues = currentBlocker.renderer.material.color;
			colourValues.r = 1;
			colourValues.b = 0;
			colourValues.g = 0;
			currentBlocker.renderer.material.color = colourValues;
		}
		else{
			colourValues = currentBlocker.renderer.material.color;
			colourValues.r = 0.5f;
			colourValues.b = 0.5f;
			colourValues.g = 0.5f;
			currentBlocker.renderer.material.color = colourValues;	
		}
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
