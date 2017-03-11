using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponsiveScript : MonoBehaviour {

	public float orthographicSize = 10;
	public float aspect = 1f;

	void Start() {
		Camera.main.projectionMatrix = Matrix4x4.Ortho (
			-orthographicSize * aspect, orthographicSize * aspect,
			-orthographicSize, orthographicSize,
			Camera.main.nearClipPlane, Camera.main.farClipPlane);
	}
}
