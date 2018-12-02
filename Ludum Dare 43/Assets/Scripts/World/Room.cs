using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
	[SerializeField] private GameObject doorWest, doorEast, doorNorth, doorSouth;
	[SerializeField] private bool isCleared = false;
	[SerializeField] private bool isActive = false;

	// Use this for initialization
	void Start () {
		if (isCleared || !isActive)
			setDoorsOpen (true);
	}

	public void AddDoor(int x, int y) {
		if (x < 0)
			doorWest.GetComponent<Door> ().setIsDoor (true);
		if (x > 0)
			doorEast.GetComponent<Door> ().setIsDoor (true);
		if (y < 0)
			doorSouth.GetComponent<Door> ().setIsDoor (true);
		if (y > 0)
			doorNorth.GetComponent<Door> ().setIsDoor (true);
	}

	private void setDoorsOpen(bool b) {
		doorWest.GetComponent<Door> ().SetOpen (b);
		doorEast.GetComponent<Door> ().SetOpen (b);
		doorNorth.GetComponent<Door> ().SetOpen (b);
		doorSouth.GetComponent<Door> ().SetOpen (b);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player" && !isCleared && !isActive) {
			ActivateEvents ();
		}
	}

	void ActivateEvents() {
		isActive = true;
		setDoorsOpen (false);
	}
}
