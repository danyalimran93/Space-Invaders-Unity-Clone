using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreUpdateScript : MonoBehaviour {

	private Text highScoreLabel;

	void Start () {
		highScoreLabel = GetComponent<Text> ();
		highScoreLabel.text = "HIGHSCORE: " + PlayerPrefs.GetInt ("highscore", ScoreManager.highScore).ToString ();
	}

	void Update () {
		if (LifeManager.gameOver || EnemyCounter.gameWin) {
			highScoreLabel.text = "HIGHSCORE: " + PlayerPrefs.GetInt ("highscore", ScoreManager.highScore).ToString ();
		}
	}
}
