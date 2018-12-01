using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SerializeField]
public interface UsableItem {
	void UseItem();
	string getName ();
	string getDescription();
	Sprite getIcon();
	void SetPlayerStatus(PlayerStatus status);
	void SetProjectileSpawn (Transform transform);
	void SetItemSlot (InventorySlot slot);
}
