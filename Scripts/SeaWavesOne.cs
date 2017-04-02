using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaWavesOne : MonoBehaviour {
	[SerializeField]
	private AudioClip[] seawaves;
	[SerializeField]
	int currentClip;
	[SerializeField]
	float counter = 0f;
	[SerializeField]
	float random;
	[SerializeField]
	int switchcases = 2;
	[SerializeField]
	int previousClip;
	[SerializeField]
	int preswitchcases;

	private Vector3[] position = new [] {
		new Vector3(49.9f,1.7f,58.4f),
		new Vector3(36.4f,1.31f,54.2f),
		new Vector3(23.04f,1.15f,43.47f)
	};

	void Start () {
		gameObject.transform.position = new Vector3(36.4f,1.31f,54.2f);
		GetComponent<AudioSource> ().loop = false;
		seawaves = Resources.LoadAll<AudioClip> ("Sounds/Object Sounds/Sea Waves");
		currentClip = (int)Random.Range (0f, seawaves.Length);
		GetComponent<AudioSource>().clip = seawaves [currentClip];
		random = Random.Range (GetComponent<AudioSource>().clip.length+1f,GetComponent<AudioSource>().clip.length+5f);//set a random# after load the sepecific clip.
		GetComponent<AudioSource> ().Play ();
		InvokeRepeating ("Add",0f,1f);//counter
		InvokeRepeating ("Checking",0f,1f);//check when counter >= random every 1s
	}
	//increment the counter every 1s using Add () called by InvokeRepeating();
	void Add () {
		counter++;
	}

	void Checking(){
		//when checking() is called, make sure don't play the same audio clip/position like previous time.
		while(currentClip == previousClip){
			currentClip = (int)Random.Range (0f, seawaves.Length);//random the currentClip int.
		}
		while(switchcases == preswitchcases){
			switchcases = (int)Random.Range (0f,position.Length);//random the switchcases int.
		}
		if (counter >= random){
			gameObject.transform.position = position[switchcases];
//			switch(switchcases){		//debug
//				case 0:
//				print ("0");
//				break;
//				case 1:
//				print ("1");
//				break;
//				case 2:
//				print ("2");
//				break;
//			}
			GetComponent<AudioSource>().clip = seawaves [currentClip];
			GetComponent<AudioSource> ().Play ();
			counter = 0f;//set counter back to 0 after play the clip
			random = Random.Range (GetComponent<AudioSource>().clip.length+1f,GetComponent<AudioSource>().clip.length+5f);
			previousClip = currentClip;
			preswitchcases = switchcases;
		}
	}

}
