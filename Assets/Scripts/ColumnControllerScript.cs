using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnControllerScript : MonoBehaviour {

	public float min = 0;
	public float max = 10;

	void Start () {
		float rand = Random.Range (min, max);
		Invoke ("SelectForFire", rand);
	}

	void Update () {
		if (transform.childCount == 0)
			Destroy (gameObject);
	}

	void SelectForFire () {
		if (!CounterScript.counter && !LifeManager.gameOver && transform.childCount > 0) {
			transform.GetChild (0).gameObject.GetComponent<EnemyScript> ().Invoke ("Fire", 0f);

			float rand = Random.Range (min, max / 4);
			Invoke ("SelectForFire", rand);
		} 
	}
}
