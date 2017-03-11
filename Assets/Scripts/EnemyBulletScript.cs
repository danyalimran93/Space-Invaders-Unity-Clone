using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour {

	private Rigidbody2D bullet;

	public float speed = 5f;

	void Start () {
		bullet = GetComponent<Rigidbody2D> ();
		bullet.velocity = new Vector2 (0, -speed);
	}

	void OnBecameInvisible () {
		Destroy (gameObject);
	}
}
