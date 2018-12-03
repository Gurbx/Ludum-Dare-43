using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTable : MonoBehaviour {

	[SerializeField] private GameObject lootRoom;
	[SerializeField] private GameObject alatarRoom;
	[SerializeField] private GameObject endRoom;
	[SerializeField] private List<GameObject> roomsLevel1;
	[SerializeField] private List<GameObject> roomsLevel2;
	[SerializeField] private List<GameObject> roomsLevel3;

	public List<GameObject> GetLevelRooms(int roomCount, int level) {
		List<GameObject> generatedRooms = new List<GameObject> ();

		List<GameObject> roomsList = roomsLevel1;
		if (level == 1) {
			//Level 1 specifics
		} else if (level == 2) {
			//Level 2 specifics
			roomsList = roomsLevel2;
		} else {
			roomsList = roomsLevel3;
		}

		generatedRooms.Add (lootRoom);
		generatedRooms.Add (alatarRoom);

		while (generatedRooms.Count < roomCount) {
			generatedRooms.Add (getRandomRoom (roomsList));
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

	private GameObject getRandomRoom(List<GameObject> roomList) {
		int index = Random.Range (0, roomList.Count);
		return roomList [index];
	}
		
}
