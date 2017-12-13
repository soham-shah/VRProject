using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLight : MonoBehaviour {

	public float r;
	public float g;
	public float b;

	private static Light myLight;

	// Use this for initialization
	void Start () {
		myLight = GetComponent<Light>();
//		myLight.color = Color.green;
		InvokeRepeating("setColor", .05f, 5f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}

	void setColor (){
		r = interpolate(audioPeer._audioBandBuffer [0]);
		g = interpolate(audioPeer._audioBandBuffer [1]);
		b = interpolate(audioPeer._audioBandBuffer [2]);
		Color x =  new Color (audioPeer._audioBandBuffer [0],audioPeer._audioBandBuffer [1],audioPeer._audioBandBuffer [2],1f);
		myLight.color = Color.Lerp (myLight.color, x, 4f);
	}

	float interpolate(float OldValue){
		float OldMax = 1;
		float OldMin = 0;
		float NewMax = 255;
		float NewMin = 0;
		float OldRange = (OldMax - OldMin);
		float NewRange = (NewMax - NewMin); 
		float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;
		return NewValue;
	}
}
