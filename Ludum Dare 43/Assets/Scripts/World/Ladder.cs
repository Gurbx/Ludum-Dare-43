using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ladder : MonoBehaviour {
	
	private GameObject popupText;
	private bool canInteract = false;


	void Start () {
		popupText = GameObject.Find ("UI/Popup Text");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E) && canInteract) {
			Climb ();
		}
	}

	void Climb() {
		SceneManager.LoadScene ("Assets/Scenes/PlayScene.unity", LoadSceneMode.Single);
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player") {
			popupText.SendMessage ("SetPopupText", "[E] Climb");
			canInteract = true;
		}
	}

		void OnTriggerExit(Collider col) {
			if (col.tag == "Player") {
				popupText.SendMessage ("SetPopupText", "");
				canInteract = false;
			}
		}
}
