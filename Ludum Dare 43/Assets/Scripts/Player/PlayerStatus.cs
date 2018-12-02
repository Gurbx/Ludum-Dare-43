using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour {

	[SerializeField] private HealthBar hpBar;
	[SerializeField] private ManaBar mpBar;
	[SerializeField] private KeyInfo keyInfo;

	[SerializeField] AudioSource potionSound;
	[SerializeField] AudioSource damagedSound;

	public static int health = 10;
	public static int maxHealth = 10;

	public static int mana = 50;
	public static int maxMana = 50;

	public static int keys = 10;

	// Use this for initialization
	void Start () {
		initialize ();
	}

	public static void initialize() {
		health = 10;
		maxHealth = 10;
		mana = 50;
		maxMana = 50;
		keys = 10;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DamagePlayer(int damage) {
		damagedSound.Play ();
		health -= damage;
		if (health <= 0) {
			health = 0;
			GameOver ();
		}
		hpBar.UpdateHPBar ();
	}

	public void addHealth(int hp) {
		potionSound.Play ();
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
		potionSound.Play ();
		mana += mp;
		if (mana > maxMana)
			mana = maxMana;
		mpBar.UpdateMPBar ();
	}



	private static void GameOver() {
		print ("Game Over");
	}

	public void RemoveKey() {
		keys -= 1;
		if (keys == 0) {
			keys = 0;
		}
		keyInfo.UpdateKeys ();
	}

	public void AddKeys(int nr) {
		keys += nr;
		keyInfo.UpdateKeys ();
	}
}
