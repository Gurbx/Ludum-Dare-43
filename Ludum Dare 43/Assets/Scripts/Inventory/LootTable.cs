using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour {

	[SerializeField] private List<GameObject> loot;

	void Start() {
		for (int i = 0; i < loot.Count; i++) {
			loot [i].GetComponent<UsableItem> ().SetID (i);
		}
	}

	public GameObject getRandomLoot() {
		int index = Random.Range (0, loot.Count);
		return loot [index];
	}

	public GameObject GetItem(int id) {
		return loot [id];
	}
}
