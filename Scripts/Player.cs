using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public static float playerPosX;

	public static float playerPosY;

	public static float playerPosZ;

	public void Update () {
		playerPosX = gameObject.transform.position.x;
		playerPosY = gameObject.transform.position.y;
		playerPosZ = gameObject.transform.position.z;
	}
}
