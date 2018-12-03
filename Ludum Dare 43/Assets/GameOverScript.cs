using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;

		PlayerStatus.initialize ();
		DungeonGenerator.dungeonLevel = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
