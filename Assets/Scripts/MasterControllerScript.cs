using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterControllerScript : MonoBehaviour {

	private Rigidbody2D master;
	private bool start = true;
	private bool visible = false;

	public Rigidbody2D bullet;
	public float moveSpeed = 6f;

	void Start () {
		visible = false;
		transform.gameObject.SetActive (false);
		master = GetComponent<Rigidbody2D> ();
		InvokeRepeating ("move", 0f, 8f);
		Invoke ("ChooseWhenFire", 1f);
	}

	void Update () {
		if (transform.position.x >= 10.5f) {
			transform.gameObject.SetActive (false);
			visible = false;
		}
	}

	void move () {
		if (!EnemyCounter.gameWin && !LifeManager.gameOver && !CounterScript.counter) {
			visible = true;
			transform.gameObject.SetActive (true);
			transform.position = new Vector2 (-10.5f, 4.0f);
			master.velocity = new Vector2 (moveSpeed, 0);
		}
	}

	void ChooseWhenFire () {
		float time = Random.Range (0.1f, 0.8f);
		Invoke ("Fire", time);
	}

	void Fire () {
		
			float x = transform.position.x;
			float y = transform.position.y - 0.4f;
			Instantiate (bullet, new Vector2 (x, y), Quaternion.identity);

			float time = Random.Range (0.1f, 0.8f);
			Invoke ("ChooseWhenFire", time);
	}
}
