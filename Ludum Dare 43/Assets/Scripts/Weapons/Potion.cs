using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour, UsableItem {

	enum PotionType { HEALTH, MANA };
	[SerializeField] PotionType type;
	[SerializeField] int amountRestored;

	public PlayerStatus stats;
	private InventorySlot slot;

	[SerializeField] string name;
	[SerializeField] string description;
	[SerializeField] Sprite icon;

	private GameObject projectilePrefab;
	private Transform projectileSpawn;


	public void UseItem() {
		if (type == PotionType.HEALTH) {
			stats.addHealth (amountRestored);
		} else if (type == PotionType.MANA) {
			stats.addMana (amountRestored);
		}
		slot.RemoveItem ();
		Destroy (gameObject);
	}

	public void SetItemSlot (InventorySlot slot) {
		this.slot = slot;
	}

	public string getName () {
		return name;
	}

	public string getDescription() {
		return description;
	}

	public Sprite getIcon() {
		return icon;
	}

	public void SetPlayerStatus(PlayerStatus status) {
		this.stats = status;
	}

	public void SetProjectileSpawn(Transform tf) {
		this.projectileSpawn = tf;
	}
}
