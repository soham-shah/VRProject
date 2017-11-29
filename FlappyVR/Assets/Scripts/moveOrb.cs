﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class moveOrb : MonoBehaviour {

	public KeyCode moveL;
	public KeyCode moveR;
	public KeyCode flapper;

	public float horizVel = 0;
	public int laneNum = 2;
	public bool controllLocked = false;

	public int forwardSpeed;
	public int upSpeed;
	public float gravityScale;
	public static float globalGravity = -9.81f;

	private Rigidbody rb;
	private bool didFlap = false;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void Update () {
		if (Input.GetKeyDown(moveL) && laneNum>1 && !controllLocked){
			horizVel = -2;
			StartCoroutine (stopSlide ());
			laneNum -= 1;
			controllLocked = true;
		}

		if (Input.GetKeyDown(moveR) && laneNum<3 && !controllLocked){
			horizVel = 2;
			StartCoroutine (stopSlide ());
			laneNum += 1;
			controllLocked = true;
		}

		if(Input.GetKeyDown(flapper) || Input.GetMouseButtonDown(0) ) {
			didFlap = true;
		}
	}

	void FixedUpdate(){
		//move forward fixed amount and add scalable gravity component
		rb.velocity = new Vector3 (horizVel, rb.velocity.y , rb.velocity.z); 
		Vector3 gravity = globalGravity * gravityScale * Vector3.up;
		rb.AddForce(gravity, ForceMode.Acceleration);
		rb.AddForce (Vector3.forward * forwardSpeed);

		//handle the up and down
		if (didFlap) {
			rb.AddForce (Vector3.up * upSpeed);
			didFlap = false;
		} else {

		}

	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "lethal") {
			SceneManager.LoadScene ("GameOver");
			Destroy (gameObject);
		}
	}

	void onTriggerEnter(Collider other) {
		Debug.Log ("caught the triger");
		if (other.gameObject.tag == "lethal") {
			SceneManager.LoadScene ("GameOver");
			Destroy (gameObject);
		}
	}

	IEnumerator stopSlide(){
		yield return new WaitForSeconds (.5f);
		horizVel = 0;
		controllLocked = false;
	}
}
