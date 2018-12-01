using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	[SerializeField] private float mouseSensitivity;
	[SerializeField] private Transform playerTransform;

	private float xClamp = 0;

	void Start () {
		xClamp = 0;
	}

	void Update () {
		HandleRotation ();
	}

	private void HandleRotation() {
		float mouseX = Input.GetAxis ("Mouse X") * mouseSensitivity * Time.deltaTime;
		float mouseY = Input.GetAxis ("Mouse Y") * mouseSensitivity * Time.deltaTime;

		xClamp += mouseY;
		if (xClamp < -90f) {
			xClamp = -90f;
			mouseY = 0;
			ClampXAxisRotationToValue (90f);
		} else if (xClamp > 90f) {
			xClamp = 90f;
			mouseY = 0;
			ClampXAxisRotationToValue (270f);
		}
			
		transform.Rotate (Vector3.left * mouseY);
		playerTransform.Rotate (Vector3.up * mouseX);
	}


	private void ClampXAxisRotationToValue(float value)
	{
		Vector3 eulerRotation = transform.eulerAngles;
		eulerRotation.x = value;
		transform.eulerAngles = eulerRotation;
	}

}
