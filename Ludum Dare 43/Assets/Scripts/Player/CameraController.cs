using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	[SerializeField] private float mouseSensitivity;
	[SerializeField] private Transform playerTransform;

	//CAM SHAKE
	public float shakeDuration = 0f;
	public float shakeAmount = 0.003f;
	public float decreaseFactor = 0.4f;
	Vector3 originalPos;

	private float xClamp = 0f;

	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		xClamp = 0;
		originalPos = transform.localPosition;
	}

	void Update () {
		HandleRotation ();
		HandleShake ();
	}

	void HandleShake() {
		if (shakeDuration > 0)
		{
			transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shakeDuration = 0f;
			transform.localPosition = originalPos;
		}
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

	public void ShakeCamera(float duration) {
		originalPos = transform.localPosition;
		shakeDuration = duration;
	}

}
