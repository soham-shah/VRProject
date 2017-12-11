using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paramCube : MonoBehaviour {
	public int _band;
	public float _startScale, _scaleMultiplier;
	public bool _useBuffer = true;

	Material _material;

	void Start () {
		_material = GetComponent<MeshRenderer> ().materials [0];
	}
	
	// Update is called once per frame
	void Update () {
		if (_useBuffer) {
			transform.localScale = new Vector3 (transform.localScale.x, (audioPeer._audioBandBuffer [_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
			Color _color = new Color (audioPeer._audioBandBuffer [_band], audioPeer._audioBandBuffer [_band], audioPeer._audioBandBuffer [_band]);
  			_material.SetColor ("_Color", _color);
		} else {
			transform.localScale = new Vector3 (transform.localScale.x, (audioPeer._audioBand [_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
			Color _color = new Color (audioPeer._audioBandBuffer [_band], audioPeer._audioBandBuffer [_band], audioPeer._audioBandBuffer [_band]);
  			_material.SetColor ("_Color", _color);
		}
	}
}
