using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour {

	[SerializeField] GameObject loot;
	[SerializeField] bool isLocked;
	[SerializeField] GameObject lights;

	private bool canInteract;
	private bool looted = false;

	private GameObject popupText;
	private GameObject lootWindow;
	private GameObject player;

	private bool active = false;


	// Use this for initialization
	void Start () {
		popupText = GameObject.Find ("UI/Popup Text");
		lootWindow = GameObject.Find ("UI/Loot Window");
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E) && canInteract && !active) {
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

	public void setIsLooted(bool b) {
		looted = b;
		if (looted)
			lights.SetActive (false);
	}

	private void Unlocked(){
		//TODO UNLOCK EFFECT
		popupText.SendMessage ("SetPopupText", "[E] to Open");
		isLocked = false;
		player.GetComponent<PlayerStatus> ().RemoveKey ();
	}

	private void Open() {
		popupText.SendMessage ("SetPopupText", "");
		lootWindow.SendMessage ("Activate", loot);
		lootWindow.SendMessage ("SetChest", gameObject);
		active = true;
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
			active = false;
		}
	}
}
