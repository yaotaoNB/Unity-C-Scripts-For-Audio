using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour {

	[SerializeField]
	float counter;
	[SerializeField]
	float random;
	[SerializeField]
	int currentClip;
	[SerializeField]
	int preClip;
	[SerializeField]
	AudioClip[] wolf;
	[SerializeField]
	float posX;
	[SerializeField]
	float posY;
	[SerializeField]
	float posZ;

	void Start () {
		posX = Random.Range (-69.9f,-112.9f);
		posY = Random.Range (0f,3f);
		posZ = Random.Range (-67f,-60.8f);
		gameObject.transform.position = new Vector3 (posX,posY,posZ);
		wolf = Resources.LoadAll <AudioClip> ("Sounds/Object Sounds/Wolf");
		currentClip = (int)Random.Range (0f,wolf.Length);
		GetComponent<AudioSource>().clip = wolf[currentClip];
		random = Random.Range (GetComponent<AudioSource>().clip.length + 3f,GetComponent<AudioSource>().clip.length + 7f);
		GetComponent<AudioSource> ().Play ();
		InvokeRepeating ("Add",0f,0.1f);
		InvokeRepeating ("Check",0f,0.1f);
	}
	void Add(){
		counter = counter + 0.1f;
	}
	void Check(){
		while (currentClip == preClip) {
			currentClip = (int)Random.Range (0f,wolf.Length);
		}
		if(counter >= random){
			posX = Random.Range (-69.9f,-112.9f);
			posY = Random.Range (0f,3f);
			posZ = Random.Range (-67f,-60.8f);
			gameObject.transform.position = new Vector3 (posX,posY,posZ);
			GetComponent<AudioSource>().clip = wolf[currentClip];
			random = Random.Range (GetComponent<AudioSource>().clip.length + 3f,GetComponent<AudioSource>().clip.length + 7f);
			GetComponent<AudioSource> ().Play ();
			counter = 0f;
			random = Random.Range (GetComponent<AudioSource>().clip.length + 3f,GetComponent<AudioSource>().clip.length + 7f);
			preClip = currentClip;
		}
	}

}
