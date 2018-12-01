using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour {

	[SerializeField] UsableItem loot;
	[SerializeField] bool locked;


	// Use this for initialization
	void Start () {
		//GameObject popupText = GameObject.Find ("UI/Popup Text");
		//popupText.SendMessage ("SetOpenChestText");
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player") {
			GameObject popupText = GameObject.Find ("UI/Popup Text");
			popupText.SendMessage ("SetPopupText", "[E] to Open");
		}
	}


	void OnTriggerExit(Collider col) {
		if (col.tag == "Player") {
			GameObject popupText = GameObject.Find ("UI/Popup Text");
			popupText.SendMessage ("SetPopupText", "");
		}
	}
}
