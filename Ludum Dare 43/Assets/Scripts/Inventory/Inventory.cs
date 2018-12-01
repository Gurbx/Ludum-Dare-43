using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	private InventorySlot[] slots;
	private int selectedIndex = 0;

	// Use this for initialization
	void Start () {
		slots = GetComponentsInChildren<InventorySlot> ();
	}

	void Update () {
		//Key input
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			deselectAll ();
			slots [0].SetSelected (true);
			selectedIndex = 0;
		}

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
		}

		if (Input.GetAxis ("Mouse ScrollWheel") < 0f) {
			selectedIndex -= 1;
			if (selectedIndex > slots.GetLength (0)-1)
				selectedIndex = 0;
			else if (selectedIndex < 0)
				selectedIndex = slots.GetLength (0)-1;

			deselectAll ();
			slots [selectedIndex].SetSelected (true);
		}
	}


	private void deselectAll() {
		for (int i = 0; i < slots.GetLength (0); i++) {
			slots [i].SetSelected (false);
		}
	}
}
