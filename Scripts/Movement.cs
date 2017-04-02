using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	bool isPlaying;
	bool isJumping;
	bool Grounded;
	[SerializeField]
	AudioClip[] footstepDirt;
	[SerializeField]
	AudioClip[] footstepWood;
	[SerializeField]
	AudioClip[] footstepWater;
	[SerializeField]
	AudioClip[] jumpDirt;
	[SerializeField]
	AudioClip[] jumpWood;
	[SerializeField]
	int currentClip;
	[SerializeField]
	int preClip;
	[SerializeField]
	AudioSource[] movementSource;
	[SerializeField]
	float waitTime;

	int sourceNumber(){
		for(int i = 0;i < movementSource.Length; i++) {
			if (!movementSource [i].isPlaying)
				return i;
		}
		return movementSource.Length - 1;
	}

	void Start () {
		footstepDirt = Resources.LoadAll<AudioClip> ("Sounds/Movement/Footsteps/Dirtstep");
		footstepWood = Resources.LoadAll<AudioClip> ("Sounds/Movement/Footsteps/Woodstep");
		footstepWater = Resources.LoadAll<AudioClip> ("Sounds/Movement/Footsteps/Waterstep");
		jumpDirt = Resources.LoadAll<AudioClip> ("Sounds/Movement/Jump/Dirtjump");
		jumpWood = Resources.LoadAll<AudioClip> ("Sounds/Movement/Jump/Woodjump");
	}

	void Update () {
		RaycastHit hit;
		Ray landingRay = new Ray (transform.position,Vector3.down);

		if (Input.GetKey (KeyCode.LeftShift)) {
			waitTime = 0.2f;//Random.Range (0.2f, 0.22f);
		}
		if (!Input.GetKey (KeyCode.LeftShift)) {
			waitTime = 0.35f;//Random.Range (0.35f, 0.38f);
		}

		if (Input.GetAxis ("Horizontal") > 0.1f && isPlaying == false) {
			StartCoroutine ("Footsteps");
		}
		if (Input.GetAxis ("Horizontal") < -0.1f && isPlaying == false) {
			StartCoroutine ("Footsteps");
		}
		if (Input.GetAxis ("Vertical") > 0.1f && isPlaying == false) {
			StartCoroutine ("Footsteps");
		}
		if (Input.GetAxis ("Vertical") < -0.1f && isPlaying == false) {
			StartCoroutine ("Footsteps");
		}
		if (Input.GetKeyDown (KeyCode.Space)&& isPlaying == false && !movementSource[sourceNumber()].isPlaying && !isJumping) {
			StartCoroutine ("Jump");
			print ("jump");//Can't Detect space key down while holding WSAD keys!
		}
	}

	IEnumerator Footsteps(){
		RaycastHit hit;
		Ray landingRay = new Ray (transform.position,Vector3.down);
		if (Physics.Raycast (landingRay, out hit, 1f)) {
			isPlaying = true;
			if (hit.collider.tag == "Dirt") {
				if(currentClip == preClip){
					currentClip = (int)Random.Range (0f,footstepDirt.Length);
				}
				movementSource[sourceNumber()].clip = footstepDirt[currentClip];
				movementSource[sourceNumber()].volume = Random.Range(0.8f,0.9f);
				movementSource [sourceNumber ()].Play ();
//				movementSource[sourceNumber()].pitch = Random.Range(0.9f,1.1f);
//				movementSource [sourceNumber ()].PlayOneShot (footstepDirt[currentClip],Random.Range(0.9f,1.1f));
			}
			else if (hit.collider.tag == "Wood") {
				if(currentClip == preClip){
					currentClip = (int)Random.Range (0f,footstepWood.Length);
				}
				movementSource[sourceNumber()].clip = footstepWood[currentClip];
				movementSource[sourceNumber()].volume = Random.Range(1f,1.1f);
				movementSource [sourceNumber ()].Play ();
//				movementSource[sourceNumber()].pitch = Random.Range(0.9f,1.1f);
//				movementSource [sourceNumber ()].PlayOneShot (footstepWood[currentClip],Random.Range(0.9f,1.1f));
			}
			else if (hit.collider.tag == "Water") {
				if(currentClip == preClip){
					currentClip = (int)Random.Range (0f,footstepWater.Length);
				}
				movementSource[sourceNumber()].clip = footstepWater[currentClip];
				movementSource[sourceNumber()].volume = Random.Range(0.9f,1.1f);
				movementSource [sourceNumber ()].Play ();
//				movementSource[sourceNumber()].pitch = Random.Range(0.9f,1.1f);
//				movementSource [sourceNumber ()].PlayOneShot (footstepWater[currentClip],Random.Range(0.9f,1.1f));
			}
			yield return new WaitForSeconds (waitTime);
			preClip = currentClip;
			isPlaying = false;
		}
	}
	IEnumerator Jump(){
		RaycastHit hit;
		Ray landingRay = new Ray (transform.position,Vector3.down);
		if (Physics.Raycast (landingRay, out hit, 1f)) {
			isPlaying = true;
			isJumping = true;
			yield return new WaitForSeconds (0.8f);
			if (hit.collider.tag == "Dirt") {
				if (currentClip == preClip) {
					currentClip = (int)Random.Range (0f, jumpDirt.Length);
				}
				movementSource [sourceNumber ()].clip = jumpDirt [currentClip];
				movementSource [sourceNumber ()].Play ();
				print ("jumpdirt");
			} else if (hit.collider.tag == "Wood") {
				if (currentClip == preClip) {
					currentClip = (int)Random.Range (0f, jumpWood.Length);
				}
				movementSource [sourceNumber ()].clip = jumpWood [currentClip];
				movementSource [sourceNumber ()].Play ();
				print ("jumpwood");
			}
			preClip = currentClip;
			isPlaying = false;
			isJumping = false;
		}
	}

}


//if (hit.collider.tag == "Dirt") {
//	currentClip = (int)Random.Range (0f,footstepDirt.Length);
//	AudioSource Dirtsource = gameObject.AddComponent<AudioSource> () as AudioSource;
//	Dirtsource.clip = footstepDirt[currentClip];
//	Dirtsource.pitch = Random.Range(0.9f,1.1f);
//	Dirtsource.volume = Random.Range(0.9f,1.1f);
//	Dirtsource.Play();
//	//				Destroy(Dirtsource);
//}
//&& isPlaying == false && !movementSource[sourceNumber()].isPlaying