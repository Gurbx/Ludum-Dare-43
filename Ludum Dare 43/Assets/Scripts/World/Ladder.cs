using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ladder : MonoBehaviour {
	
	private GameObject popupText;
	private GameObject player;
	private bool canInteract = false;


	void Start () {
		popupText = GameObject.Find ("UI/Popup Text");
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E) && canInteract) {
			Climb ();
		}
	}

	void Climb() {
		//PlayerStatus.SaveInventory ();
		if (DungeonGenerator.dungeonLevel > 5) {
			SceneManager.LoadScene ("Assets/Scenes/WinScene.unity", LoadSceneMode.Single);
		} else {
			SceneManager.LoadScene ("Assets/Scenes/PlayScene.unity", LoadSceneMode.Single);
			player.GetComponent<PlayerStatus> ().SaveLoot ();
		}
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
