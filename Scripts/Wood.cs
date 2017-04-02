using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour {

	[SerializeField]
	float counter;
	[SerializeField]
	float random;
	[SerializeField]
	int currentClip;
	[SerializeField]
	int preClip;
	AudioClip[] wood;

	void Start () {
		GetComponent<AudioSource> ().loop = false;
		wood = Resources.LoadAll<AudioClip> ("Sounds/Object Sounds/Wood Squeaks");
		currentClip = (int)Random.Range (0f,wood.Length);
		GetComponent<AudioSource>().clip = wood[currentClip];
		GetComponent<AudioSource> ().Play ();
		random = Random.Range (GetComponent<AudioSource>().clip.length + 0.35f,GetComponent<AudioSource>().clip.length + 2.5f);
		InvokeRepeating ("Add",0f,0.1f);
		InvokeRepeating ("Check",0f,0.1f);
	}
	void Add(){
		counter = counter + 0.1f;
	}
	void Check(){
		while(currentClip == preClip){
			currentClip = (int)Random.Range (0f,wood.Length);
		}
		if(counter >= random){
			GetComponent<AudioSource>().clip = wood[currentClip];
			GetComponent<AudioSource> ().Play ();
			random = Random.Range (GetComponent<AudioSource>().clip.length + 0.35f,GetComponent<AudioSource>().clip.length + 2.5f);
			counter = 0f;
			preClip = currentClip;
		}
	}
}
