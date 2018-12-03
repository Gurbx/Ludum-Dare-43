using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour {

	[SerializeField] private HealthBar hpBar;
	[SerializeField] private ManaBar mpBar;
	[SerializeField] private KeyInfo keyInfo;
	[SerializeField] CameraController camController;

	[SerializeField] AudioSource potionSound;
	[SerializeField] AudioSource damagedSound;

	//For saving loot
	[SerializeField] LootTable loot;
	[SerializeField] WeaponHandler wepHandler;
	[SerializeField] Inventory inventory;
	public static List<int> itemIDs;

	public static int health = 10;
	public static int maxHealth = 10;

	public static int mana = 50;
	public static int maxMana = 50;

	public static int keys = 10;

	// Use this for initialization
	void Start () {
		print ("start");
		//initialize ();
		//itemIDs.Add (2);
		//itemIDs.Add (4);
		LoadLoot ();
	}

	public static void initialize() {
		health = 10;
		maxHealth = 10;
		mana = 50;
		maxMana = 50;
		keys = 10;
	}

	public void SaveLoot() {
		itemIDs = new List<int> ();
		itemIDs.Add (0);
		InventorySlot[] slots = inventory.GetSlots ();
		for (int i = 1; i < slots.GetLength(0); i++) {
			if (slots [i].isSlotEmpty () == false) {
				itemIDs.Add(slots [i].getItem ().GetComponent<UsableItem>().getID());
			}
		}
	}

	private void LoadLoot() {
		if (itemIDs == null)
			return;
		for (int i = 1; i < itemIDs.Count; i++) {
			wepHandler.AddItem(loot.GetItem(itemIDs[i]), inventory.GetSlots()[i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DamagePlayer(int damage) {
		//camController.ShakeCamera (0.05f);
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
		SceneManager.LoadScene ("Assets/Scenes/GameOverScene.unity", LoadSceneMode.Single);
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
