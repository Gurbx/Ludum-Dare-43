using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour {

	[SerializeField] private HealthBar hpBar;
	[SerializeField] private ManaBar mpBar;

	public static int health = 3;
	public static int maxHealth = 10;

	public static int mana = 10;
	public static int maxMana = 10;

	public static int keys = 2;

	// Use this for initialization
	void Start () {
		initialize ();
	}

	public static void initialize() {
		health = 10;
		maxHealth = 10;
		mana = 10;
		maxMana = 10;
		keys = 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DamagePlayer(int damage) {
		health -= damage;
		if (health <= 0) {
			health = 0;
			GameOver ();
		}
		hpBar.UpdateHPBar ();
	}

	public void addHealth(int hp) {
		health += hp;
		if (health > maxHealth) 
			health = maxHealth;
		hpBar.UpdateHPBar();
	}

	public void increaseMaxHealth(int increase) {
		maxHealth += increase;
		hpBar.UpdateHPBar();
	}

	public void increaseMaxMana(int increase) {
		maxMana += increase;
		mpBar.UpdateMPBar ();
	}

	public void useMana(int mp) {
		mana -= mp;
		if (mana < 0)
			mana = 0;
		mpBar.UpdateMPBar ();
	}

	public void addMana(int mp) {
		mana += mp;
		if (mana > maxMana)
			mana = maxMana;
		mpBar.UpdateMPBar ();
	}



	private static void GameOver() {
		print ("Game Over");
	}
}
