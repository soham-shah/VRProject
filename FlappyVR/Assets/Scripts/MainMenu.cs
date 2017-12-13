using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	GameObject gm;
	public int lastScore;
	public Text scoreBoard;

	// Use this for initialization

	void Awake() {
		scoreBoard = GetComponent <Text> ();
	}
	void Start () {
		//gm = GameObject.FindWithTag("GameMaster");	
		if(PlayerPrefs.HasKey("Score")){
			lastScore = PlayerPrefs.GetInt("Score");
		}
		//lastScore = PlayerPrefs.GetInt ("Score"); //GameMaster.GM.getScore ();

	}
	
	// Update is called once per frame
	void Update () {
		scoreBoard.text = "Score: " + lastScore;
	}

	public void StartGame(){
		Application.LoadLevel (1);
	}

	public void QuitGame(){
		Application.Quit();
	}
		
	public void getScore() {
		if (lastScore != 0) {
			scoreBoard.text = "Score: " + lastScore.ToString ();
		}
	}
}
