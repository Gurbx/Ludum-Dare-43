using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour {

	[SerializeField] Text manaText;

	void Start () {
		UpdateMPBar ();
	}

	public void UpdateMPBar() {
		GetComponent<Slider> ().value = ((float) PlayerStatus.mana / (float) PlayerStatus.maxMana);
		manaText.text = "MP: " + PlayerStatus.mana + "/" + PlayerStatus.maxMana;
	}
}
