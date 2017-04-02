using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {
	//BPM = 75, 60/75 = 0.8 sec per beat
	[SerializeField]
	AudioClip musicOne;
	[SerializeField]
	AudioClip musicTwo;
	[SerializeField]
	AudioClip musicThree;
	[SerializeField]
	float counter;
//	float beat = 40f;//1.25 * 32(8 bars) = 25.6s

	public bool musiconebool;

	public bool musictwobool;

	public bool musicthreebool;

	void Add(){
		counter = counter + (60f/130f);
		counter = Mathf.Clamp (counter,0f,(60f/130f)*47f);//24.8s(Beat#33) "0" is the 1st beat in the clip
		if(counter == (60f/130f)*47f){
			counter = 0f;
		}
	}

	void Start(){
		GetComponent<AudioSource> ().clip = musicTwo;
		GetComponent<AudioSource> ().loop = true;
		GetComponent<AudioSource> ().Play ();
		counter = 0f;
		InvokeRepeating ("Add", 0.6f, (60f/130f)); //There is the 0.6s lag when start the game, so delay the Invokerepeating for 0.6s to match the beat
		InvokeRepeating ("Checkmusic", 0.6f, (60f/130f));
	}

	public void OnTriggerEnter(Collider musicOneCheck){
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
		if (musiconebool == true && counter == 0f) {
			counter = 0f;
			GetComponent<AudioSource> ().clip = musicOne;
			GetComponent<AudioSource> ().loop = true;
			GetComponent<AudioSource> ().Play ();
//			InvokeRepeating ("Add", 0f, 1.25f);
		}
		if (musictwobool == true && counter == 0f) {
			counter = 0f;
			GetComponent<AudioSource> ().clip = musicTwo;
			GetComponent<AudioSource> ().loop = true;
			GetComponent<AudioSource> ().Play ();
//			InvokeRepeating ("Add", 0f, 1.25f);
		}
		if (musicthreebool == true && counter == 0f) {
			counter = 0f;
			GetComponent<AudioSource> ().clip = musicThree;
			GetComponent<AudioSource> ().loop = true;
			GetComponent<AudioSource> ().Play ();
//			InvokeRepeating ("Add", 0f, 1.25f);
		}
	}

}
