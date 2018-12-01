using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

	private UsableItem item;
	private bool isSelected;
	private bool isEmpty;
	private Image bg;

	// Use this for initialization
	void Start () {
		bg = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && isSelected && !isEmpty) {
			//item.UseItem ();
		}
	}
		
	public void SetSelected(bool selected) {
		isSelected = selected;
		if (isSelected) {
			bg.color = Color.white;
		} else {
			bg.color = Color.gray;
		}
	}
}
