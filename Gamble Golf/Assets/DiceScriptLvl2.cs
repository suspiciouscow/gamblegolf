using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScriptLvl2 : MonoBehaviour {

	static Rigidbody rb;
	public static Vector3 diceVelocity;
	public int numberRolled;

	// Use this for initialization
	void Start() {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update() {
		diceVelocity = rb.velocity;

		if (Input.GetKeyDown(KeyCode.Space))
		{
			DiceNumberTextScript.diceNumber = 0;
			float dirX = Random.Range(0, 500);
			float dirY = Random.Range(0, 500);
			float dirZ = Random.Range(0, 500);
			transform.position = new Vector3(3, 20, 1);
			transform.rotation = Quaternion.identity;
			rb.AddForce(transform.up * 500);
			rb.AddTorque(dirX, dirY, dirZ);
		}
	}
}