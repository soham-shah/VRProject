using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeOfDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "destroyable"  || other.gameObject.tag == "lethal")
		{
			Destroy (other.gameObject);
		}
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "destroyable" || other.gameObject.tag == "lethal") {
			Destroy (other.gameObject);
		}
	}
}
