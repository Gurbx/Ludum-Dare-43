using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spell : MonoBehaviour, UsableItem {

	public PlayerStatus stats;
	private InventorySlot slot;

	[SerializeField] string name;
	[SerializeField] string description;
	[SerializeField] Sprite icon;

	[SerializeField] private GameObject projectilePrefab;
	[SerializeField] private Transform projectileSpawn;

	[SerializeField] private int manaCost = 1;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void UseItem() {
		//Return if not enough mana
		if (PlayerStatus.mana < manaCost)
			return;

		stats.useMana (manaCost);

		var projectile = (GameObject)Instantiate (
			                 projectilePrefab,
			                 projectileSpawn.position,
			                 projectileSpawn.rotation);

		projectile.GetComponent<Rigidbody> ().velocity = projectile.transform.forward * projectile.GetComponent<Projectile>().speed;

		Destroy (projectile, 3.0f);
	}

	public void SetItemSlot (InventorySlot slot) {
		this.slot = slot;
	}

	public string getName () {
		return name;
	}

	public string getDescription() {
		return description;
	}

	public Sprite getIcon() {
		return icon;
	}

	public void SetPlayerStatus(PlayerStatus status) {
		this.stats = status;
	}

	public void SetProjectileSpawn(Transform tf) {
		this.projectileSpawn = tf;
	}
}
