using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music2 : MonoBehaviour {

	[SerializeField]
	AudioClip musicOne;
	[SerializeField]
	AudioClip musicTwo;
	[SerializeField]
	AudioClip musicThree;
	[SerializeField]
	bool musiconebool;
	[SerializeField]
	bool musictwobool;
	[SerializeField]
	bool musicthreebool;

	void OnTriggerEnter(Collider musicOneCheck){
		if (musicOneCheck.tag == "Music1") {
			musiconebool = true;
			musictwobool = false;
			musicthreebool = false;
		}
		if (musicOneCheck.tag == "Music2") {
			musictwobool = true;
			musiconebool = false;
			musicthreebool = false;
		}
		if (musicOneCheck.tag == "Music3") {
			musicthreebool = true;
			musiconebool = false;
			musictwobool = false;
		}
	}

	void Checkmusic(){ // when I use update() and if statement, the 3 bools are frozen
		if (musiconebool == true && GetComponent<AudioSource>().isPlaying == false) {
			GetComponent<AudioSource> ().clip = musicOne;
			GetComponent<AudioSource> ().loop = false;
			GetComponent<AudioSource> ().Play ();
		}
		if (musictwobool == true && GetComponent<AudioSource>().isPlaying == false) {
			GetComponent<AudioSource> ().clip = musicTwo;
			GetComponent<AudioSource> ().loop = false;
			GetComponent<AudioSource> ().Play ();
		}
		if (musicthreebool == true && GetComponent<AudioSource>().isPlaying == false) {
			GetComponent<AudioSource> ().clip = musicThree;
			GetComponent<AudioSource> ().loop = false;
			GetComponent<AudioSource> ().Play ();
		}
	}
	void Update(){
		Checkmusic ();
	}
}
