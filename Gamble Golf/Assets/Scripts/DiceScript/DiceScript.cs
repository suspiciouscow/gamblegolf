using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour {

	static Rigidbody rb;
	public static Vector3 diceVelocity;
	public int numberRolled;
	public static bool canRoll = true;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		diceVelocity = rb.velocity;

		if (Input.GetKeyDown (KeyCode.Space) && canRoll) {
			DiceNumberTextScript.diceNumber = 0;
			float dirX = Random.Range (0, 500);
			float dirY = Random.Range (0, 500);
			float dirZ = Random.Range (0, 500);
			transform.position = new Vector3 (12, 21, 8);
			transform.rotation = Quaternion.identity;
			rb.AddForce (transform.up * 500);
			rb.AddTorque (dirX, dirY, dirZ);
			canRoll = false;
			BallScript.canShoot = true;
		}
	}
}