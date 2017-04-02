using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seagull : MonoBehaviour {
	[SerializeField]
	int currentClip;
	[SerializeField]
	int preclip;
	[SerializeField]
	AudioClip[] seagull;
	[SerializeField]
	float counter;
	[SerializeField]
	float random;
	public float seagullX;
	float preseagullX;
	public float seagullY;
	float preseagullY;
	public float seagullZ;
	float preseagullZ;
	[SerializeField]
	bool seagullActivate;
	SeaGullTrigger enter = new SeaGullTrigger();

	void Start(){
		seagullActivate = true;//Initialize seagull to be true when start the game
//		enter.TestSea ();
		GetComponent<AudioSource>().loop = false;
		seagull = Resources.LoadAll<AudioClip>("Sounds/Object Sounds/Seagull");
		currentClip = (int)Random.Range (0f,seagull.Length);
		GetComponent<AudioSource>().clip = seagull[currentClip];
		random = Random.Range(GetComponent<AudioSource>().clip.length + 1f,GetComponent<AudioSource>().clip.length + 5f);
		seagullX = Random.Range (Player.playerPosX-10f,Player.playerPosX+10f);
		seagullY = Random.Range (Player.playerPosY+5f,Player.playerPosY+15f);
		seagullZ = Random.Range (Player.playerPosZ-10f,Player.playerPosZ+10f);
		gameObject.transform.position = new Vector3(seagullX,seagullY,seagullZ);
		InvokeRepeating ("Add",0f,0.1f);
		InvokeRepeating ("Checking",0f,0.1f);

	}

	void Update(){
		if(enter.seaGullCheck == true){
			print ("collide");
		}
		if (seagullActivate == false) {
			counter = 0f;
		}
	}


	void Add(){
		counter = counter + 0.1f;
	}
	void Checking(){
		if(seagullActivate == true) {
		while (seagullX == preseagullX || seagullY == preseagullY || seagullZ == preseagullZ){
			seagullX = Random.Range (Player.playerPosX-10f,Player.playerPosX+10f);
			seagullY = Random.Range (Player.playerPosY+5f,Player.playerPosY+15f);
			seagullZ = Random.Range (Player.playerPosZ-10f,Player.playerPosZ+10f);
		}
			while(currentClip == preclip){
				currentClip = (int)Random.Range (0f,seagull.Length);
			}

//		while (SeaGullTrigger.seaGullCheck == true){
//					print("collide");
//				}
		if (counter >= random){
			print ("seagullActivate");
			gameObject.transform.position = new Vector3 (seagullX,seagullY,seagullZ);//Why I have to use a new word for this Vector3?
			GetComponent<AudioSource>().clip = seagull[currentClip];
			GetComponent<AudioSource>().Play();
			counter = 0f;
			random = Random.Range(GetComponent<AudioSource>().clip.length + 1f,GetComponent<AudioSource>().clip.length + 5f);
			preseagullX = seagullX;
			preseagullY = seagullY;
			preseagullZ = seagullZ;
			preclip = currentClip;
		}
	 }
  }
}
