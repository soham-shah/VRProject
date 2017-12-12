using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {
	public float zObstPos;
	public float zGroundPos = 6;

	public GameObject[] Obstacles; //Array for Obstacles
	public GameObject musicCube;
	public Material[] randMats; //Array for Materials

	public Text scoreText;
	private int score;

	//store the previously generated random obstacle so we don't have the same obstacle twice in a row. 
	private int prevRand = 0;

	// Use this for initialization
	void Start () {
		score = 0;
		SetScoreText ();

		for (int i =0; i<5; i++) {
			genNewObst ();
		}
	}

	public void genNewObst(){
		genMusicCubes ();
		int randomIndex = Random.Range(0, Obstacles.Length); //Randomly selects an object in our Array
		while (randomIndex == prevRand) {
			randomIndex = Random.Range(0, Obstacles.Length); 
		}
		GameObject obj = Instantiate (Obstacles [randomIndex], new Vector3 (9.3f, 0.5f, zObstPos), Quaternion.identity); //Instantiates our random obstacle
		Transform temp = obj.GetComponent<Transform>();

		int randomMat = Random.Range(0, randMats.Length);
		SetShader (temp.GetChild(0).gameObject, randMats[randomMat]);
		zObstPos += 20;
		prevRand = randomIndex;
	}

	void SetShader (GameObject obj, Material mat){
		Renderer rend = obj.GetComponent<Renderer>();
		rend.material = mat;
	}

//	void SetShaderRecursive (Transform obj, Material mat){
//		Material rend;
//		try{
//			rend = obj.gameObject.GetComponent<Renderer> ().material;
//			if (rend != null) {
//				rend = mat;
//			}
//			else {
//				Renderer temp = obj.gameObject.AddComponent<Renderer>();
//				temp.material = mat;
//			}
//
//			foreach (Transform child in transform){
//				SetShaderRecursive (child, mat);
//			}
//		}
//		catch{
//		}
//
//	}

	public void genMusicCubes(){
		for (int i = 0; i < 8; i++){
			GameObject obj;
			obj = Instantiate (musicCube, new Vector3 (9.3f, 0.5f, (float)(zObstPos + (2.5*i))), Quaternion.identity);
			obj.AddComponent(typeof(paramCube));
			paramCube pc = obj.GetComponent<paramCube>();
			pc._band = i;
			pc._startScale = 1;
			pc._scaleMultiplier = 40;
			obj = Instantiate (musicCube, new Vector3 (-9.3f, 0.5f, (float)(zObstPos + (2.5*i))), Quaternion.identity);
			obj.AddComponent(typeof(paramCube));
			pc = obj.GetComponent<paramCube>();
			pc._band = i;
			pc._startScale = 1;
			pc._scaleMultiplier = 40;
		}
	}

	public void genNewGround(){
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

