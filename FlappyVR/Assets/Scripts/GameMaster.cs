using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

	//public Transform obst1;
	//public Transform MarioPipe;
	public float zObstPos = 4;
	public float zGroundPos = 5;

	public GameObject[] Obstacles; //Array for Obstacles
	public GameObject ground;

	// Use this for initialization
	void Start () {
		while (zObstPos < 40) {
			//Instantiate (MarioPipe, new Vector3 (-1, 0, zscenePos), MarioPipe.rotation);
			///Instantiate (Wall, new Vector3 (-1, 0, zscenePos), Wall.rotation);
			genNewObst ();
		}
		for (int i = 0; i < 5; i++) {
			genNewGround ();
		}
	}

	public void genNewObst(){
		int randomIndex = Random.Range(0, Obstacles.Length); //Randomly selects an object in our Array
		Instantiate (Obstacles [randomIndex], new Vector3 (-1, 0, zObstPos), Quaternion.identity); //Instantiates our random obstacle

		zObstPos += 10;
	}

	public void genNewGround(){
		Instantiate (ground, new Vector3 (0, 0, zGroundPos), Quaternion.identity);
		zGroundPos += 5;
	}




























	// Update is called once per frame
	void Update () {

	}
}

