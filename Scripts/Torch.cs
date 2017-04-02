using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour {

	[SerializeField]
	float pch = 1f;
	[SerializeField]
	float amp = 1f;
	[SerializeField]
	float frq = 8.125f;

	public void PlayEveryXSec() {
		amp = Random.Range (0.9f, 1f);
		pch = Random.Range (0.9f, 1.1f);
		GetComponent<AudioSource> ().volume = amp;
		GetComponent<AudioSource> ().pitch = pch;
	}

	void Start () {
		GetComponent<AudioSource>().loop = true;
		GetComponent<AudioSource> ().Play ();
		InvokeRepeating ("PlayEveryXSec",0.001f, frq);
	}
	

}
