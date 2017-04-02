using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour {

	[SerializeField]
	float counter;
	[SerializeField]
	int currentClip; //the Index number for the crane(wood) Audio Clip array.
	[SerializeField]
	int currentClipMetal; //the Index number for the metal Audio Clip array.
	public AudioClip[] crane;//the clip array for loadAll wood AudioClips in the Resources floder.
	public AudioClip[] metal;//the clip array for loadAll metal AudioClips in the Resources floder.
	[SerializeField]
	float random;
	[SerializeField]
	int preClip; // previous wood Clip
	[SerializeField]
	int preClipMetal; // previous metal CLip.
	AudioSource[] sources = new AudioSource [2];//Create an Audio Source Array [2] for 2 Audio sources attach to this crane boject.
	[SerializeField]
	AudioSource woodSource;//Instantiate the 1st audio source(wood) attach to this crane boject in the inspector
	[SerializeField]
	AudioSource metalSource;//Instantiate the 2nd audio source(metal) attach to this crane boject in the inspector
	[SerializeField]
	AudioClip woodS; //create/instantiate an Audio Clip Var(wood,1st Source) for Debuging Null Reference
	[SerializeField]
	AudioClip metalS; //create/instantiate an Audio Clip Var(metal,2nd Source) for Debuging Null Reference

	void Start () {
		woodSource =  sources [0];
		metalSource = sources [1];
		random = Random.Range (crane.Length+1f,crane.Length+3f);
		crane = Resources.LoadAll<AudioClip> ("Sounds/Object Sounds/Wood Squeaks");
		metal = Resources.LoadAll<AudioClip> ("Sounds/Object Sounds/Metal Squeaks");
		//random those index
		currentClip = (int)Random.Range (0f,crane.Length);
		currentClipMetal = (int)Random.Range (0f,metal.Length);
		//Assign the Clip Arrays with the random index # created just now to an Audio Clip var.
		//crane [currentClip] = woodS; 
//		woodSource.clip = crane [currentClip];
		//Assign this Clip var to the Source var instance
//		crane = woodSource.GetComponent<AudioClip> ();
//		metal [currentClipMetal] = metalS;
//		metalS = metalSource.GetComponent<AudioClip> ();
//		metalSource.clip = metal[currentClipMetal];// _ This is what it suppose to be
		//Play the Source instance
		woodSource.Play ();
		metalSource.Play ();
//		GetComponent<AudioSource>().clip = crane[currentClip];
//		GetComponent<AudioSource> ().Play ();
		InvokeRepeating ("Add",0f,0.1f);
		InvokeRepeating ("Checking",0f,0.1f);
	}

	void Add(){
		counter = counter+0.1f;
		print (counter);
	}

	void Checking(){
		while (currentClip == preClip) {
			currentClip = (int)Random.Range (0f,crane.Length);
		}
		while (currentClipMetal == preClipMetal) {
			currentClipMetal = (int)Random.Range (0f,metal.Length);
		}
		if (counter >= random){
			crane [currentClip] = woodS;
			woodS = woodSource.GetComponent<AudioClip> ();
			metal [currentClipMetal] = metalS;
			metalS = metalSource.GetComponent<AudioClip> ();
//			crane[currentClip] = woodSource.GetComponent<AudioClip> ();
//			metal [currentClipMetal] = metalSource.GetComponent<AudioClip> ();
//			woodSource.clip = crane[currentClip];
			woodSource.Play ();
//			metalSource.clip = metal[currentClipMetal];
			metalSource.Play ();
			counter = 0f;
			random = Random.Range (crane.Length+1f,crane.Length+3f);
			preClip = currentClip;
		}
	}
		
}
