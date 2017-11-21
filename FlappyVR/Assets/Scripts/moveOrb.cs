using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOrb : MonoBehaviour {

	public KeyCode moveL;
	public KeyCode moveR;

	public float horizVel = 0;

	public int laneNum = 2;
	public bool controllLocked = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody> ().velocity = new Vector3 (horizVel, 0, 4); 
		if (Input.GetKeyDown(moveL) && laneNum>1 && !controllLocked){
			horizVel = -2;
			StartCoroutine (stopSlide ());
			laneNum -= 1;
			controllLocked = true;
		}

		if (Input.GetKeyDown(moveR) && laneNum<3 && !controllLocked){
			horizVel = 2;
			StartCoroutine (stopSlide ());
			laneNum += 1;
			controllLocked = true;
		}
	}

	IEnumerator stopSlide(){
		yield return new WaitForSeconds (.5f);
		horizVel = 0;
		controllLocked = false;
	}
}
