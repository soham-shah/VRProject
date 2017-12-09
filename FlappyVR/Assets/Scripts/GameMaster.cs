using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

	//public Transform obst1;
	//public Transform MarioPipe;
	public float zObstPos;
	public float zGroundPos = 6;

	public GameObject[] Obstacles; //Array for Obstacles
	public GameObject ground;
	public GameObject side1;
	public GameObject side2;

	public Text scoreText;
	private int score;

	// Use this for initialization
	void Start () {
		score = 0;
		SetScoreText ();

		for (int i =0; i<5; i++) {
			genNewObst ();
		}
	}

	public void genNewObst(){
		int randomIndex = Random.Range(0, Obstacles.Length); //Randomly selects an object in our Array
		Instantiate (Obstacles [randomIndex], new Vector3 (9.3f, 0.5f, zObstPos), Quaternion.identity); //Instantiates our random obstacle
		zObstPos += 20;
	}

	public void genNewGround(){
		Instantiate (ground, new Vector3 (0, 0, zGroundPos), Quaternion.identity);
		Instantiate (side1, new Vector3 (-9.5F, 3, zGroundPos), Quaternion.identity);
		Instantiate (side2, new Vector3 (9.5F, 3, zGroundPos), Quaternion.identity);
		zGroundPos += 5;
	}

	public void destroyWall(GameObject obst){
		Destroy (obst);
		score++;
		SetScoreText ();
	}

	void SetScoreText (){
		scoreText.text = "Score: " + score.ToString ();
	}
}

