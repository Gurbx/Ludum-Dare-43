using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour, UsableItem {

	[SerializeField] private GameObject projectilePrefab;
	[SerializeField] private float projectileSpeed;

	[SerializeField] private Transform projectileSpawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		

	public void UseItem() {
		var projectile = (GameObject)Instantiate (
			                 projectilePrefab,
			                 projectileSpawn.position,
			                 projectileSpawn.rotation);

		projectile.GetComponent<Rigidbody> ().velocity = projectile.transform.forward * projectileSpeed;

		Destroy (projectile, 3.0f);
	}


}
