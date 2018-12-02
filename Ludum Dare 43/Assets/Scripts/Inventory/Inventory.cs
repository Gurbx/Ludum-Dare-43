using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	[SerializeField] private Text name, description;
	private InventorySlot[] slots;
	private int selectedIndex = 0;

	// Use this for initialization
	void Start () {
		slots = GetComponentsInChildren<InventorySlot> ();
		deselectAll ();
		slots [selectedIndex].SetSelected (true);

		UpdateText ();
	}

	void Update () {
		//Key input
		//if (Input.GetKeyDown (KeyCode.Alpha1)) {
		//	deselectAll ();
		//	slots [0].SetSelected (true);
		//	selectedIndex = 0;
		//}

		MouseScroll ();
			
	}

	private void MouseScroll() {
		if (Input.GetAxis ("Mouse ScrollWheel") > 0f) {
			selectedIndex += 1;
			if (selectedIndex > slots.GetLength (0)-1)
				selectedIndex = 0;
			else if (selectedIndex < 0)
				selectedIndex = slots.GetLength (0)-1;

			deselectAll ();
			slots [selectedIndex].SetSelected (true);
			UpdateText ();
		}

		if (Input.GetAxis ("Mouse ScrollWheel") < 0f) {
			selectedIndex -= 1;
			if (selectedIndex > slots.GetLength (0)-1)
				selectedIndex = 0;
			else if (selectedIndex < 0)
				selectedIndex = slots.GetLength (0)-1;

			deselectAll ();
			slots [selectedIndex].SetSelected (true);
			UpdateText ();
		}
	}

	private void UpdateText() {
		if (slots [selectedIndex].isSlotEmpty() == false) {
			UsableItem item = slots [selectedIndex].getItem ().GetComponent<UsableItem> ();
			name.text = item.getName ();
			description.text = item.getDescription ();
		} else {
			name.text = "";
			description.text = "";
		}
	}


	private void deselectAll() {
		for (int i = 0; i < slots.GetLength (0); i++) {
			slots [i].SetSelected (false);
		}
	}

	public InventorySlot getEmptySlot() {
		for (int i = 0; i < slots.GetLength (0); i++) {
			if (slots [i].isSlotEmpty ()) {
				return slots [i];
			}
		}
		return null;
	}
}
