using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterScript : MonoBehaviour {

	private Text counterLabel;

	public static bool counter = true;
	public static float count = 3f;

	void Start () {
		counterLabel = GetComponent<Text> ();
	}

	void Update () {
		if (count > 4f)
			UpdateCounter ("5");
		else if (count > 3f) 
			UpdateCounter ("4");
		else if (count > 2f)
			UpdateCounter ("3");
		else if (count > 1f) 
			UpdateCounter ("2");
		else if (count > 0f) 
			UpdateCounter ("1");
		else {
			counterLabel.text = "";
			counter = false;
		}
	}

	void UpdateCounter ( string number ) {
		count = count - (1f * Time.deltaTime);
		counterLabel.text = number;
	}
}
