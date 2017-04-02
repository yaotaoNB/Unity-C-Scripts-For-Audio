using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;//Don't for get to use UnityEngine.Audio for instantiating AudioMixer in the script!

public class SeaGullTrigger : MonoBehaviour {

	public bool seaGullCheck;
	[SerializeField]
	AudioClip[] seaGull;
	[SerializeField]
	int currentClip;
	[SerializeField]
	int preClip;
	[SerializeField]
	Vector3 position;
	[SerializeField]
	AudioMixerGroup seagullmixer;

	void Start(){
		seaGull = Resources.LoadAll<AudioClip>("Sounds/Object Sounds/Seagull");
	}
		
	float randomise(float max){//set posX posZ to a random number
		while(true){
			float value = Random.Range (5f,max);
			float check = Random.Range (5f,max);
			if (value > check) {
				if (Random.value <= 0.5f)
					value *= -1f;
				return value;
			}
		}
	}

	Vector3 seagullPos(){
		position = new Vector3 (
			Player.playerPosX+randomise(10f),
			Random.Range (Player.playerPosY+5f,Player.playerPosY+15f),
			Player.playerPosZ+randomise(10f));
		return position;
	}
	//Grab player'Pos, return player back to Vector3 with random number range.
	IEnumerator Play(){
		while (seaGullCheck) {
			if(currentClip == preClip)
			currentClip = (int)Random.Range (0f,seaGull.Length);
			
			GameObject soundObject = new GameObject("tempsound");
			soundObject.transform.position = seagullPos ();
			AudioSource audiosource = soundObject.AddComponent<AudioSource> ();
			audiosource.clip = seaGull [currentClip];
			audiosource.rolloffMode = AudioRolloffMode.Logarithmic;
			audiosource.outputAudioMixerGroup = seagullmixer;
			audiosource.dopplerLevel = 0f;
			audiosource.spatialBlend = 1.0f;
			audiosource.maxDistance = 50f;
			audiosource.Play();
			preClip = currentClip;
			yield return new WaitForSeconds (Random.Range(seaGull[currentClip].length+5f,seaGull[currentClip].length+10f));
			Destroy (soundObject);
		}
	}
	public void OnTriggerEnter(Collider col){
		if (col.gameObject.name == "FlyingRigidBodyFPSController_LowQuality") {
			seaGullCheck = true;
			StartCoroutine ("Play");
//			print ("seagull true");
		}
	}
	public void OnTriggerExit(Collider col){
		if (col.gameObject.name == "FlyingRigidBodyFPSController_LowQuality") {
			seaGullCheck = false;
//			print ("seagull false");
		}
	}

}






