using UnityEngine;
using System.Collections;

public class Lane : MonoBehaviour {
	
	public Rigidbody[] arrayObjects;

	// Use this for initialization
	void Start () {
		StartCoroutine("SpawnObject");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator SpawnObject(){
		yield return new WaitForSeconds(10);
		int randomSpawn = Random.Range(0,2);
		
		if(randomSpawn == 0){
			randomSpawn = Random.Range(0,1);
			arrayObjects[randomSpawn].gameObject = new GameObject();
		}
	}
}
