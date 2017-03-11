using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {

	public static int lives = 3;
	public GameObject player;
	public static bool gameOver;

	void Start () {
		gameOver = false;
	}

	void Update () {
		if (lives == 2) {
			transform.FindChild ("LifeLabel").gameObject.GetComponent<Text> ().text = "2";
			transform.FindChild ("LifeImage2").gameObject.SetActive (false);
		} if (lives == 1) {
			transform.FindChild ("LifeLabel").gameObject.GetComponent<Text> ().text = "1";
			transform.FindChild ("LifeImage1").gameObject.SetActive (false);
		} if (lives == 0) {
			gameOver = true;
			player.SetActive (false);
			transform.FindChild ("LifeLabel").gameObject.GetComponent<Text> ().text = "0";
		}
	}
}
