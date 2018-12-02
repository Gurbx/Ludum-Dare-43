using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEvent : MonoBehaviour {
	[SerializeField] private Vector2Int numberOfEnemiesRange;
	[SerializeField] private List<GameObject> enemyTypes;

	private int enemiesCount = -1;

	private GameObject room;

	void Start() {
	}

	public void SpawnEnemies(GameObject room) {
		enemiesCount = 0;
		this.room = room;
		int n = Random.Range (numberOfEnemiesRange.x, numberOfEnemiesRange.y);
		for (int i = 0; i < n; i++) {
			SpawnEnemy ();
		}
	}

	private void SpawnEnemy() {
		Vector3 position = new Vector3 (room.transform.position.x, 1, room.transform.position.z);


		var enemy = (GameObject)Instantiate (
			enemyTypes[Random.Range(0, enemyTypes.Count)],
			position,
			room.transform.rotation);

		enemiesCount++;
		enemy.GetComponent<Health> ().AddCombatEvent (GetComponent<CombatEvent> ());
	}

	//Called from enemy health script
	public void EnemyDied () {
		enemiesCount--;
		if (enemiesCount <= 0) {
			room.GetComponent<Room>().RoomCleared ();
		}
	}
}
