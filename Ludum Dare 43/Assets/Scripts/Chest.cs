using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour {

	[SerializeField] GameObject loot;
	[SerializeField] bool isLocked;

	private bool canInteract;
	private bool looted = false;

	private GameObject popupText;
	private GameObject lootWindow;


	// Use this for initialization
	void Start () {
		popupText = GameObject.Find ("UI/Popup Text");
		lootWindow = GameObject.Find ("UI/Loot Window");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E) && canInteract) {
			if (isLocked) {
				if (PlayerStatus.keys > 0)
					Unlocked ();
				else
					popupText.SendMessage ("SetPopupText", "Out of keys");
			} else {
				Open ();
			}
		}
	}

	private void Unlocked(){
		//TODO UNLOCK EFFECT
		popupText.SendMessage ("SetPopupText", "[E] to Open");
		isLocked = false;
		PlayerStatus.keys -= 1;
	}

	private void Open() {
		popupText.SendMessage ("SetPopupText", "");
		lootWindow.SendMessage ("Activate", loot);
	}
			

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player") {
			if (looted)
				return;
			if (isLocked) {
				popupText.SendMessage ("SetPopupText", "[E] to Unlock");
			} else
				popupText.SendMessage ("SetPopupText", "[E] to Open");
			canInteract = true;
		}
	}


	void OnTriggerExit(Collider col) {
		if (col.tag == "Player") {
			popupText.SendMessage ("SetPopupText", "");
			lootWindow.SendMessage ("Deactivate");
			canInteract = false;
		}
	}
}
