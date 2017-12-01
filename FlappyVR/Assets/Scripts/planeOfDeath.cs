using System.Collections;
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
		if (other.gameObject.tag == "destroyable") {
			Destroy (other.gameObject);
		}
		if (other.gameObject.tag == "lethal") {
			Debug.Log ("here");

			Destroy (other.gameObject);
			gm.GetComponent<GameMaster>().genNewObst();
		}
	}
}
