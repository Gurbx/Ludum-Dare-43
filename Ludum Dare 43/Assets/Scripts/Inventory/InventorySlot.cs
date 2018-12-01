using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

	[SerializeField] private GameObject item;
	[SerializeField] private GameObject icon;
	private bool isSelected;
	private bool isEmpty;

	// Use this for initialization
	void Start () {
		if (item == null) {
			isEmpty = true;
			icon.SetActive (false);
		} else
			isEmpty = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && isSelected) {
			if (item != null) item.SendMessage ("UseItem");
		}
	}
		
	public void SetSelected(bool selected) {
		isSelected = selected;
		if (isSelected) {
			Select ();
		} else {
			Deselect ();
		}
	}

	private void Deselect() {
		GetComponent<Image> ().color = Color.gray;
		if (item != null) item.SetActive (false);
	}

	private void Select() {
		GetComponent<Image> ().color = Color.white;
		if (item != null) item.SetActive (true);
	}


	public bool isSlotEmpty() {
		return isEmpty;
	}

	public void addItem(GameObject item) {
		this.item = item;
		isEmpty = false;
	}
}
