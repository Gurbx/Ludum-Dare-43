using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
	enum RoomType {BATTLE, LOOT, SACRAFICE};
	[SerializeField] private RoomType type;
	[SerializeField] private GameObject doorWest, doorEast, doorNorth, doorSouth;
	[SerializeField] private bool isCleared = false;
	[SerializeField] private bool isActive = false;

	[SerializeField] List<GameObject> combatEvents;
	[SerializeField] GameObject roomEvent;

	// Use this for initialization
	void Start () {
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
		if (type == RoomType.BATTLE) {
			combatEvents [Random.Range (0, combatEvents.Count)].GetComponent<CombatEvent> ().SpawnEnemies (gameObject);
			//roomEvent.GetComponent<CombatEvent> ().SpawnEnemies (gameObject);
		} else if (type == RoomType.SACRAFICE) {
			roomEvent.GetComponent<Altar> ().SetRoom (gameObject);
		}
	}


	public void RoomCleared() {
		setDoorsOpen (true);
		isCleared = true;
		isActive = false;
	}
}
