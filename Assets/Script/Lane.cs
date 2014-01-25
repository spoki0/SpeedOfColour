using UnityEngine;
using System.Collections;

public class Lane : MonoBehaviour {
	
	public Rigidbody[] arrayObjects;
	public Color colourValues;
	int randomSpawn;

	// Use this for initialization
	void Start () {
		StartCoroutine("SpawnObject");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void AddColour(){
		print ("colorChanged");
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
