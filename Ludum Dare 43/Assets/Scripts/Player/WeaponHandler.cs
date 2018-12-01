using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour {

	[SerializeField] PlayerStatus playerStatus;
	[SerializeField] Transform weaponSpawn;
	[SerializeField] Transform projectileSpawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddItem(GameObject itemPrefab, InventorySlot slot) {
		var item = (GameObject)Instantiate (
			itemPrefab,
			weaponSpawn.position,
			weaponSpawn.rotation);
		item.transform.parent = transform;

		item.GetComponent<UsableItem> ().SetPlayerStatus (playerStatus);
		item.GetComponent<UsableItem> ().SetProjectileSpawn (projectileSpawn);

		slot.addItem (item);
	}
}
