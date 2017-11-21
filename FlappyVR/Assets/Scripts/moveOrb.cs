using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class moveOrb : MonoBehaviour {

	public KeyCode moveL;
	public KeyCode moveR;
	public KeyCode flapper;

	public float horizVel = 0;
	public float flapSpeed = 100f;
	public int laneNum = 2;
	public bool controllLocked = false;

	private bool didFlap = false;
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

		if(Input.GetKeyDown(flapper) || Input.GetMouseButtonDown(0) ) {
			didFlap = true;
		}
	}

	void FixedUpdate(){
		if(didFlap) {
//			rigidbody2D.AddForce( Vector2.up * flapSpeed );
//			animator.SetTrigger("DoFlap");
//

			didFlap = false;
		}

	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "lethal") {
			SceneManager.LoadScene ("GameOver");
			Destroy (gameObject);
		}
	}

	IEnumerator stopSlide(){
		yield return new WaitForSeconds (.5f);
		horizVel = 0;
		controllLocked = false;
	}
}
