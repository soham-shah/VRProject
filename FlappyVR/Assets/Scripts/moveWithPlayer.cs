using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWithPlayer : MonoBehaviour {

	public float offset;
	private Transform player_pos;
	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag ("player");

		if(player == null) {
			Debug.LogError("Couldn't find an object with tag 'Player'!");
			return;
		}

		player_pos = player.transform;
		offset = transform.position.z - player_pos.position.z;
	}

	// Update is called once per frame
	void Update () {
		if (player_pos != null) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, player_pos.position.z + offset);
		}
	}
}
