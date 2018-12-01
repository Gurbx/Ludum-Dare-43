using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	[SerializeField] private int health = 1;

	private Animator animator;

	void Start () {
		animator = GetComponent<Animator> ();
	}


	public void Damage(int damage) {
		animator.SetTrigger ("Hit");
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
