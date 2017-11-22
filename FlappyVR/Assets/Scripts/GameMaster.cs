using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

	public Transform obst1;
	public float zscenePos = 4;


	// Use this for initialization
	void Start () {
		while (zscenePos < 200) {
			Instantiate (obst1, new Vector3 (-1, 0, zscenePos), obst1.rotation);
			zscenePos += 4;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
