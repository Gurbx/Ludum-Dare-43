using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	[SerializeField] Text healthText;

	void Start () {
		UpdateHPBar ();
	}

	public void UpdateHPBar() {
		GetComponent<Slider> ().value = ((float) PlayerStatus.health / (float) PlayerStatus.maxHealth);
		healthText.text = "HP: " + PlayerStatus.health + "/" + PlayerStatus.maxHealth;
	}
}
