using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTable : MonoBehaviour {

	[SerializeField] private GameObject lootRoom;
	[SerializeField] private GameObject alatarRoom;
	[SerializeField] private GameObject endRoom;
	[SerializeField] private List<GameObject> rooms;

	public List<GameObject> GetLevel1Rooms(int roomCount) {
		List<GameObject> generatedRooms = new List<GameObject> ();
		generatedRooms.Add (lootRoom);
		generatedRooms.Add (alatarRoom);

		while (generatedRooms.Count < roomCount) {
			generatedRooms.Add (getRandomRoom ());
		}
		//Shuffle list
		for (int i = 0; i < generatedRooms.Count; i++) {
			GameObject temp = generatedRooms[i];
			int randomIndex = Random.Range(i, generatedRooms.Count);
			generatedRooms[i] = generatedRooms[randomIndex];
			generatedRooms[randomIndex] = temp;
		}

		generatedRooms.Add (endRoom);
		return generatedRooms;
	}

	private GameObject getRandomRoom() {
		int index = Random.Range (0, rooms.Count);
		return rooms [index];
	}
		
}
