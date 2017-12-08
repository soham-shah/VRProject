using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class moveOrb : MonoBehaviour{
    public KeyCode moveL;
    public KeyCode moveR;
    public KeyCode moveU;
    public KeyCode moveD;

    public float horizVel = 0;
    public float vertVel = 0;
    public int forwardSpeed;
    
	private Rigidbody rb;
	private bool controllLockVert = false;
	private bool controllLockHoriz = false;

    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    void Update(){
        if (Input.GetKey(KeyCode.LeftArrow) && !controllLockHoriz){
            horizVel = -3;
            StartCoroutine(stopHorizontalSlide());
            controllLockHoriz = true;
        }

        if (Input.GetKey(KeyCode.RightArrow) && !controllLockHoriz){
            horizVel = 3;
            StartCoroutine(stopHorizontalSlide());
            controllLockHoriz = true;
        }
        if (Input.GetKey(KeyCode.UpArrow) && !controllLockVert){
            vertVel = 3;
            StartCoroutine(stopVertSlide());
			controllLockVert = true;
        }
		if (Input.GetKey(KeyCode.DownArrow) && !controllLockVert){
            vertVel = -3;
            StartCoroutine(stopVertSlide());
			controllLockVert = true;
        }
    }

    void FixedUpdate(){
		rb.velocity = new Vector3(horizVel, vertVel, rb.velocity.z);
        rb.AddForce(Vector3.forward * 1);
    }

    void OnCollisionEnter(Collision other){
        if (other.gameObject.tag == "lethal"){
            SceneManager.LoadScene("GameOver");
            Destroy(gameObject);
        }
    }

    void onTriggerEnter(Collider other){
        Debug.Log("caught the triger");
        if (other.gameObject.tag == "lethal"){
            SceneManager.LoadScene("GameOver");
            Destroy(gameObject);
        }
    }

    IEnumerator stopHorizontalSlide(){
        yield return new WaitForSeconds(.5f);
        horizVel = 0;
        controllLockHoriz = false;
    }

    IEnumerator stopVertSlide(){
        yield return new WaitForSeconds(.5f);
        vertVel = 0;
        controllLockVert = false;
    }
}