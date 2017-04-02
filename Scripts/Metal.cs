using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metal : MonoBehaviour {

	[SerializeField]
	float counter;
	[SerializeField]
	float random;
	[SerializeField]
	int currentClip;
	[SerializeField]
	int preClip;
	AudioClip[] metal;

	void Start () {
		GetComponent<AudioSource> ().loop = false;
		metal = Resources.LoadAll<AudioClip> ("Sounds/Object Sounds/Metal Squeaks");
		currentClip = (int)Random.Range (0f,metal.Length);
		GetComponent<AudioSource>().clip = metal[currentClip];
		GetComponent<AudioSource> ().Play ();
		random = Random.Range (GetComponent<AudioSource>().clip.length + 0.5f,GetComponent<AudioSource>().clip.length + 2f);
		InvokeRepeating ("Add",0f,0.1f);
		InvokeRepeating ("Check",0f,0.1f);
	}
	void Add(){
		counter = counter + 0.1f;
	}
	void Check(){
		while(currentClip == preClip){
			currentClip = (int)Random.Range (0f,metal.Length);
		}
		if(counter >= random){
			GetComponent<AudioSource>().clip = metal[currentClip];
			GetComponent<AudioSource> ().Play ();
			random = Random.Range (GetComponent<AudioSource>().clip.length + 0.5f,GetComponent<AudioSource>().clip.length + 2f);
			counter = 0f;
			preClip = currentClip;
		}
	}
}
