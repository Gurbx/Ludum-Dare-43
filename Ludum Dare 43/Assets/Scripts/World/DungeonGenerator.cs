using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour {
	
	[SerializeField] private GameObject spawnRoom;
	[SerializeField] private List<GameObject> rooms;

	private const int ROOM_SIZE = 14;
	private const int SPAWN_X = 5;
	private const int SPAWN_Y = 5;

	private GameObject[,] grid;

	void Start () {
		grid = new GameObject[11,11];


		//TODO Fill list with random rooms


		//Init spawn room position in grid
		grid [SPAWN_X, SPAWN_Y] = spawnRoom;
		// Place rooms
		PlaceRoom(SPAWN_X + 1, SPAWN_Y);
	}


	private void PlaceRoom(int x, int y) {
		Vector2Int spawnCoorOffset = new Vector2Int (x - SPAWN_X, y - SPAWN_Y);

		Vector3 position = new Vector3 (spawnRoom.transform.position.x + spawnCoorOffset.x * ROOM_SIZE, 0,
			spawnRoom.transform.position.z + spawnCoorOffset.y * ROOM_SIZE);

		var room = (GameObject)Instantiate (
			rooms[0],
			position,
			spawnRoom.transform.rotation);

		grid [x, y] = room;
		HandleDoors (x, y);
		rooms.Remove (rooms[0]);
	}

	private void HandleDoors(int x, int y) {
		if (grid [x - 1, y] != null)
			grid [x - 1, y].GetComponent<Room> ().AddDoor (1, 0);
		if (grid [x + 1, y] != null)
			grid [x + 1, y].GetComponent<Room> ().AddDoor (-1, 0);
		if (grid [x, y - 1 ] != null)
			grid [x, y - 1].GetComponent<Room> ().AddDoor (0, 1);
		if (grid [x, y + 1] != null)
			grid [x, y + 1].GetComponent<Room> ().AddDoor (0, -1);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
