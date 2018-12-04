using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacrificeWindow : MonoBehaviour {

	[SerializeField] private PlayerStatus playerStatus;
	[SerializeField] private GameObject panel;
	private bool windowActive = false;

	private GameObject altar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Alpha1) && windowActive){
			altar.GetComponent<Altar> ().AlatarUsed ();
			Sacrafice1 ();
			Deactivate ();
		}
		if (Input.GetKeyDown(KeyCode.Alpha2) && windowActive){
			altar.GetComponent<Altar> ().AlatarUsed ();
			Sacrafice2 ();
			Deactivate ();
		}
		if (Input.GetKeyDown(KeyCode.Alpha3) && windowActive){
			altar.GetComponent<Altar> ().AlatarUsed ();
			Sacrafice3 ();
			Deactivate ();
		}
	}

	private void Sacrafice1() {
		playerStatus.DamagePlayer (1);
		//Effect
		playerStatus.addMana (50);
	}

	private void Sacrafice2() {
		playerStatus.DamagePlayer (2);
		//Effect
		playerStatus.increaseMaxHealth (2);
	}

	private void Sacrafice3() {
		playerStatus.DamagePlayer (5);
		//Effect
		playerStatus.increaseMaxHealth (10);
		playerStatus.addMana (50);
	}

	public void Activate(GameObject altar) {
		this.altar = altar;

		panel.SetActive (true);
		windowActive = true;

		//UsableItem item = loot.GetComponent<UsableItem> ();
		//name.text = item.getName ();
		//description.text = item.getDescription ();
		//icon.sprite = item.getIcon ();
	}

	public void Deactivate() {
		panel.SetActive (false);
		windowActive = false;
		//chest = null;
		//loot = null;
	}
}
