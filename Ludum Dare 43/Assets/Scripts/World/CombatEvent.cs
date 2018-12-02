using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEvent : MonoBehaviour {
	[SerializeField] private Vector2Int numberOfEnemiesRange;
	[SerializeField] private List<GameObject> enemyTypes;
	[SerializeField] private float spawnHeight;
	[SerializeField] private GameObject spawnEffect;
	[SerializeField] private int spawnSpread;

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
		Vector3 position = new Vector3 (room.transform.position.x, spawnHeight, room.transform.position.z);
		position.x += Random.Range (-spawnSpread, spawnSpread+1);
		position.z += Random.Range (-spawnSpread, spawnSpread+1);

		var enemy = (GameObject)Instantiate (
			enemyTypes[Random.Range(0, enemyTypes.Count)],
			position,
			room.transform.rotation);

		enemiesCount++;
		enemy.GetComponent<Health> ().AddCombatEvent (GetComponent<CombatEvent> ());

		//Spawn effect
		var expl = (GameObject)Instantiate(
			spawnEffect,
			position,
			room.transform.rotation);
		
		// Destroy after 1 seconds
		Destroy(expl, 1.0f);    
	}

	//Called from enemy health script
	public void EnemyDied () {
		enemiesCount--;
		if (enemiesCount <= 0) {
			room.GetComponent<Room>().RoomCleared ();
		}
	}
}
