using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour {

	private static Rigidbody2D collection;
	private BoxCollider2D box;
	private bool right = true;
	private bool start = true;

	public bool[] dec;
	public static float moveSpeed;

	void Start () {
		box = GetComponent<BoxCollider2D> ();
		collection = GetComponent<Rigidbody2D> ();
		moveRight ();

		dec = new bool[10];
		for (int i = 0; i < 10; i++)
			dec [i] = false;
	}

	void Update () {
		moveSpeed = Mathf.Pow ((Mathf.Sqrt (56 - EnemyCounter.count) / (Mathf.Sqrt (Mathf.Pow (56, 2) - Mathf.Pow (EnemyCounter.count, 2)))) * 10, 3) - 0.25f;

		if (!CounterScript.counter) {
			if (start) {
				moveRight ();
				start = false;
			}

			if (LifeManager.gameOver)
				collection.velocity = Vector2.zero;

			if (!transform.FindChild ("EnemyColumn5")) {
				if (!dec [4])
					decrementBoxOffset (4);
				if (!transform.FindChild ("EnemyColumn4")) {
					if (!dec [3])
						decrementBoxOffset (3);
					if (!transform.FindChild ("EnemyColumn3")) {
						if (!dec [2])
							decrementBoxOffset (2);
						if (!transform.FindChild ("EnemyColumn2")) {
							if (!dec [1])
								decrementBoxOffset (1);
							if (!transform.FindChild ("EnemyColumn1")) {
								if (!dec [0])
									decrementBoxOffset (0);
							}
						}
					}
				}
			}

			if (!transform.FindChild ("EnemyColumn10")) {
				if (!dec [9])
					incrementBoxOffset (9);
				if (!transform.FindChild ("EnemyColumn9")) {
					if (!dec [8])
						incrementBoxOffset (8);
					if (!transform.FindChild ("EnemyColumn8")) {
						if (!dec [7])
							incrementBoxOffset (7);
						if (!transform.FindChild ("EnemyColumn7")) {
							if (!dec [6])
								incrementBoxOffset (6);
							if (!transform.FindChild ("EnemyColumn6")) {
								if (!dec [5])
									incrementBoxOffset (5);
							}
						}
					}
				}
			}
		} else
			collection.velocity = Vector2.zero;
	}

	void decrementBoxOffset (int index) {
		dec [index] = true;

		box.offset = new Vector2 (box.offset.x - 0.5f, box.offset.y);
		box.size = new Vector2 (box.size.x - 1f, box.offset.y);
	}

	void incrementBoxOffset (int index) {
		dec [index] = true;

		box.offset = new Vector2 (box.offset.x + 0.5f, box.offset.y);
		box.size = new Vector2 (box.size.x - 1f, box.offset.y);
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "SideCollider") {
			if (right) {
				right = false;
				moveLeft ();
			} else {
				right = true;
				moveRight ();
			}

			moveDown ();
		} else if (col.gameObject.tag == "EndGame") {
			LifeManager.lives = 0;
			LifeManager.gameOver = true;
		}
	}

	static void moveRight () {
		collection.velocity = new Vector2 (moveSpeed, 0);
	}

	void moveLeft () {
		collection.velocity = new Vector2(-moveSpeed, 0);
	}

	void moveDown () {
		float x = transform.position.x;
		float y = transform.position.y - 0.2f;
		transform.position = new Vector2 (x, y);
	}
}
