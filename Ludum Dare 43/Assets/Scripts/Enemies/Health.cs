using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	[SerializeField] private int health = 1;


	public void Damage(int damage) {
		health -= damage;
		if (health <= 0) {
			health = 0;
			Die ();
		}
	}


	private void Die() {
		Destroy (gameObject);
	}
}
