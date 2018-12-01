using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour, UsableItem {

	[SerializeField] PlayerStatus stats;

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


}
