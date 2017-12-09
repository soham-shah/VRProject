using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour {

	Vector3 offset;
	private Transform player_pos;
	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag ("player");

		if(player == null) {
			Debug.LogError("Couldn't find an object with tag 'Player'!");
			return;
		}

		player_pos = player.transform;
		offset = transform.position - player_pos.position;
	}

	// Update is called once per frame
	void Update () {
		if (player_pos != null) {
			transform.position = player_pos.position + offset;
		}
	}
}
