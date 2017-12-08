﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class moveOrb : MonoBehaviour
{

    public KeyCode moveL;
    public KeyCode moveR;
    public KeyCode moveU;
    public KeyCode moveD;

    public float horizVel = 0;
    public float vertVel = 0;
    public bool controllLocked = false;

    public int forwardSpeed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && !controllLocked)
        {
            horizVel = -2;
            StartCoroutine(stopHorizontalSlide());
            controllLocked = true;
        }

        if (Input.GetKey(KeyCode.RightArrow) && !controllLocked)
        {
            horizVel = 2;
            StartCoroutine(stopHorizontalSlide());
            controllLocked = true;
        }
        if (Input.GetKey(KeyCode.UpArrow) && !controllLocked)
        {
            vertVel = 2;
            StartCoroutine(stopVertSlide());
            controllLocked = true;
        }
        if (Input.GetKey(KeyCode.DownArrow) && !controllLocked)
        {
            vertVel = -2;
            StartCoroutine(stopVertSlide());
            controllLocked = true;
        }
    }

    void FixedUpdate()
    {
		rb.velocity = new Vector3(horizVel, vertVel, rb.velocity.z);
        rb.AddForce(Vector3.forward * 1);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "lethal" || other.gameObject.tag == "Regen")
        {
            SceneManager.LoadScene("GameOver");
            Destroy(gameObject);
        }
    }

    void onTriggerEnter(Collider other)
    {
        Debug.Log("caught the triger");
        if (other.gameObject.tag == "lethal" || other.gameObject.tag == "Regen")
        {
            SceneManager.LoadScene("GameOver");
            Destroy(gameObject);
        }
    }

    IEnumerator stopHorizontalSlide()
    {
        yield return new WaitForSeconds(.5f);
        horizVel = 0;
        controllLocked = false;
    }

    IEnumerator stopVertSlide()
    {
        yield return new WaitForSeconds(.5f);
        vertVel = 0;
        controllLocked = false;
    }

}
