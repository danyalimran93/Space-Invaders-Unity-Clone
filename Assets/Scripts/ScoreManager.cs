using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	private Text scoreLabel;

	public static int highScore;
	public static int points = 0;

	void Start () {
		scoreLabel = GetComponent<Text> ();
		highScore = PlayerPrefs.GetInt ("highscore", highScore);
	}

	void Update () {
		scoreLabel.text = "SCORE: " + points.ToString ();	
		if (LifeManager.gameOver || EnemyCounter.gameWin) {
			if (points > highScore)
				PlayerPrefs.SetInt ("highscore", points);
		}
	}
}
