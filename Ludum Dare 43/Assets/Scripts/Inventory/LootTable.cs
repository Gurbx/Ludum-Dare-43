using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour {

	[SerializeField] private List<GameObject> loot;

	public GameObject getRandomLoot() {
		int index = Random.Range (0, loot.Count);
		return loot [index];
	}
}
