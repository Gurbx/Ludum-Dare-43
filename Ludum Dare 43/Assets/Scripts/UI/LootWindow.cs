using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootWindow : MonoBehaviour {

	[SerializeField] private GameObject panel;

	[SerializeField] Text name;
	[SerializeField] Text description;
	[SerializeField] Image icon;

	[SerializeField] GameObject playerCam;
	[SerializeField] Inventory inventory;
	[SerializeField] PopUpText popup;

	private GameObject loot;

	private bool windowActive = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E) && windowActive){
			LootItem ();
		}
		if (Input.GetKeyDown(KeyCode.Q) && windowActive){
			Deactivate ();
		}
	}

	private void LootItem() {
		InventorySlot slot = inventory.getEmptySlot ();

		if (slot != null) {
			WeaponHandler wepHandler = playerCam.GetComponent<WeaponHandler>();
			wepHandler.AddItem(loot, slot);
		}
	}

	public void Activate(GameObject loot) {
		panel.SetActive (true);
		windowActive = true;

		this.loot = loot;

		UsableItem item = loot.GetComponent<UsableItem> ();
		name.text = item.getName ();
		description.text = item.getDescription ();
		icon = item.getIcon ();
	}

	public void Deactivate() {
		panel.SetActive (false);
		windowActive = false;
	}
}
