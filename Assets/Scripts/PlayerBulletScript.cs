using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletScript : MonoBehaviour {
	
	private Rigidbody2D bullet;
	private int[] masterPoints = { 50, 100, 300, 500 };

	public float speed = 5f;

	void Start () {
		bullet = GetComponent<Rigidbody2D> ();	
		bullet.velocity = new Vector2 (0, speed);
	}


	void OnBecameInvisible () {
		Destroy (gameObject);
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (!CounterScript.counter && !LifeManager.gameOver || !EnemyCounter.gameWin) {
			if (col.gameObject.tag == "Enemy1")
				Annihilate (col, 10, true);
			else if (col.gameObject.tag == "Enemy2" || col.gameObject.tag == "Enemy3") 
				Annihilate (col, 20, true);
			else if (col.gameObject.tag == "Enemy4" || col.gameObject.tag == "Enemy5") 
				Annihilate (col, 30, true);
			else if (col.gameObject.tag == "Master") 
				Annihilate (col, 0, false);
			else if (col.gameObject.tag == "EnemyBullet" || col.gameObject.tag == "SideCollider")
				Destroy (gameObject);
		}
	}

	void Annihilate (Collider2D col, int point, bool enemy ) {
		Destroy (gameObject);
		ScoreManager.points += point;

		if (enemy) {
			Destroy (col.gameObject);
			EnemyCounter.count--;
		} else {
			if (point == 0) {
				int index = Random.Range (0, 3);
				ScoreManager.points += masterPoints [index];
			}

			col.gameObject.SetActive (false);
		}
	}
}
