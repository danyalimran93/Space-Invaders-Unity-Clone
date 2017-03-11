using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

	private Text gameoverLabel;

	public Rigidbody2D enemy;
	public Text restartLabel;

	void Start () {
		gameoverLabel = GetComponent<Text> ();

		gameoverLabel.text = "";
		restartLabel.text = "";
	}

	void Update () {
		if (LifeManager.gameOver) {
			gameoverLabel.text = "GAME OVER!";
			if (Input.GetKeyDown (KeyCode.Space) || Input.touchCount > 0) {
				Invoke ("ResetGame", 0.5f);
			}
		}

		if (LifeManager.gameOver || EnemyCounter.gameWin) {
			if (Application.platform == RuntimePlatform.Android)
				restartLabel.text = "Tap to restart game";
			else
				restartLabel.text = "press Space to restart game";
		}
	}

	public void ResetGame () {
		LifeManager.lives = 3;
		ScoreManager.points = 0;
		EnemyCounter.count = 55;
		CounterScript.count = 3;
		CounterScript.counter = true;
		EnemyCounter.gameWin = false;
		LifeManager.gameOver = false;
		SceneManager.LoadScene ("main");
	}
}
