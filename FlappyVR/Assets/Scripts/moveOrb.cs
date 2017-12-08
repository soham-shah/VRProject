using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class moveOrb : MonoBehaviour
{

    public KeyCode moveL;
    public KeyCode moveR;
    public KeyCode moveU;
    public KeyCode moveD;

    public KeyCode flapper;

    public float horizVel = 0;
    public float vertVel = 0;
    public int laneNum = 2;
    public bool controllLocked = false;

    public int forwardSpeed;
    public int upSpeed;
    public float gravityScale;
    public static float globalGravity = -9.81f;

    private Rigidbody rb;
    private bool didFlap = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && laneNum > 1 && !controllLocked)
        {
            horizVel = -2;
            StartCoroutine(stopHorizontalSlide());
            //laneNum -= 1;
            controllLocked = true;
        }

        if (Input.GetKey(KeyCode.RightArrow) && laneNum < 3 && !controllLocked)
        {
            horizVel = 2;
            StartCoroutine(stopHorizontalSlide());
            //laneNum += 1;
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

        if (Input.GetKeyDown(flapper) || Input.GetMouseButtonDown(0))
        {
            didFlap = true;
        }
    }

    void FixedUpdate()
    {
        //move forward fixed amount and add scalable gravity component
        rb.velocity = new Vector3(horizVel, rb.velocity.y, rb.velocity.z);
        rb.velocity = new Vector3(rb.velocity.x, vertVel, rb.velocity.z);
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        //rb.AddForce(gravity, ForceMode.Acceleration);
        rb.AddForce(Vector3.forward * 1);

        //handle the up and down
        if (didFlap)
        {
            rb.AddForce(Vector3.up * upSpeed);
            didFlap = false;
        }
        else
        {

        }

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
