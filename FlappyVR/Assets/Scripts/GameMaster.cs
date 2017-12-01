using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

	//public Transform obst1;
	//public Transform MarioPipe;
	public float zscenePos = 4;

	public GameObject[] Obstacles; //Array for Obstacles

	// Use this for initialization
	void Start () {
		while (zscenePos < 40) {
			//Instantiate (MarioPipe, new Vector3 (-1, 0, zscenePos), MarioPipe.rotation);
			///Instantiate (Wall, new Vector3 (-1, 0, zscenePos), Wall.rotation);

			int randomIndex = Random.Range(0, Obstacles.Length); //Randomly selects an object in our Array
			Instantiate (Obstacles [randomIndex], new Vector3 (-1, 0, zscenePos), Quaternion.identity); //Instantiates our random obstacle

			zscenePos += 10;
		}
	}

	// Update is called once per frame
	void Update () {

	}
}

