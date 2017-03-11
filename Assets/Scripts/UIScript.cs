using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour {

	private Text startLabel;

	void Start () {
		startLabel = GetComponent<Text> ();

		if (Application.platform == RuntimePlatform.Android)
			startLabel.text = "Tap to Continue";
		else
			startLabel.text = "Press Start to Continue";
	}

	void Update () {
		if (Application.platform == RuntimePlatform.Android) {
			if (Input.touchCount > 0)
				SceneManager.LoadScene ("main");
		} else {
			if (Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown (KeyCode.Space))
				SceneManager.LoadScene ("main");
		}
	}
}
