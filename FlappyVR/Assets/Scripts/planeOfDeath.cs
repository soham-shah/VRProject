﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeOfDeath : MonoBehaviour {

	// Use this for initialization
	GameObject gm;

	void Start () {
		gm = GameObject.FindWithTag("GameMaster");	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "ground") {
			Destroy (other.gameObject);
			gm.GetComponent<GameMaster>().genNewGround();
		}
		if (other.gameObject.tag == "lethal") {
			Destroy (other.gameObject);
//			gm.GetComponent<GameMaster>().genNewObst();
		}
	}
}
