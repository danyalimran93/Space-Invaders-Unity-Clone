using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunkerScript : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "EnemyBullet" || col.gameObject.tag == "PlayerBullet") {
			Destroy (gameObject);
			Destroy (col.gameObject);
		}
	}
}
