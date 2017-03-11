using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour {

	private static Text winLabel;

	public static bool gameWin = false;
	public static int count = 55;

	void Start () {
		winLabel = GetComponent<Text> ();
		winLabel.text = "";
	}

	void Update () {
		if (count == 0) {
			gameWin = true;
			DisplayScore ();
			if (Input.GetKeyDown (KeyCode.Space)) {
				GameOverScript Object = new GameOverScript ();
				Object.ResetGame ();
			}
		}


	}

	void DisplayScore () {
		winLabel.text = "You Win!\r\nScore: " + ScoreManager.points.ToString ();
	}
}
