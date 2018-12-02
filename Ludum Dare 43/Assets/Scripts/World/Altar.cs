using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour {

	private bool isUsed = false;
	private bool canInteract = false;

	private GameObject popupText;

	// Use this for initialization
	void Start () {
		popupText = GameObject.Find ("UI/Popup Text");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player") {
			if (isUsed)
				return;
			else
				popupText.SendMessage ("SetPopupText", "[E] Interact");
		
			canInteract = true;
		}
	}
}
