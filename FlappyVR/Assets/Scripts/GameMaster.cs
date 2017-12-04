﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

	//public Transform obst1;
	//public Transform MarioPipe;
	public float zObstPos;
	public float zGroundPos = 5;

	public GameObject[] Obstacles; //Array for Obstacles
	public GameObject ground;
	public GameObject clone;

	// Use this for initialization
	void Start () {
		while (zObstPos < 40) {
			genNewObst ();
		}
		for (int i = 0; i < 5; i++) {
			genNewGround ();
		}
	}

	public void genNewObst(){
		int randomIndex = Random.Range(0, Obstacles.Length); //Randomly selects an object in our Array
		clone = Instantiate (Obstacles [randomIndex], new Vector3 (-1, 0, zObstPos), Quaternion.identity); //Instantiates our random obstacle

		zObstPos += 30;
	}

	public void genNewGround(){
		Instantiate (ground, new Vector3 (0, 0, zGroundPos), Quaternion.identity);
		zGroundPos += 5;
	}

	public void destroyWall(){
		Destroy (clone);
	}




























	// Update is called once per frame
	void Update () {

	}
}

