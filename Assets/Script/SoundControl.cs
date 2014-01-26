using UnityEngine;
using System.Collections;

public class SoundControl : MonoBehaviour {
	
	AudioSource audioSource;
	AudioClip sound;
	
	// Use this for initialization
	void Start () {
	
	}
	
	public static void PlaySound(string audioFile){
		/*
		audioSource = (AudioSource)gameObject.AddComponent(audioFile);	
		sound = (AudioClip)Resources.Load(audioFile);
		audioSource.clip = sound;*/

		//Buggy?
		Debug.Log("Play sound event " +audioFile);
		Fabric.EventManager.Instance.PostEvent(audioFile);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
