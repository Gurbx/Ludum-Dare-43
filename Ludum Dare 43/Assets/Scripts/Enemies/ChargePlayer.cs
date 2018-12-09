using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargePlayer : MonoBehaviour {

	[SerializeField] private float speed = 5;
	[SerializeField] private float attackRange;
	[SerializeField] private float aggroRange;
	[SerializeField] private int damage;
	[SerializeField] private float attackCooldown;
	[SerializeField] private bool isGrounded = false;

	private float cooldown;

	private GameObject player;
	private Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		rigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate() {
		cooldown -= Time.deltaTime;

		if (Vector3.Distance (transform.position, player.transform.position) < aggroRange) {
			HandleMovement ();
			HandleAttack ();
		} else
			rigidbody.velocity *= 0;
			
	}

	private void HandleMovement() {
		Vector3 dir = (player.transform.position - transform.position).normalized * speed;

		if (isGrounded)
			dir.y = 0;

		if (cooldown > 0) {
			rigidbody.velocity = -dir;
		} else {
			rigidbody.velocity = dir;
		}
	}


	private void HandleAttack() {
		if (Vector3.Distance (transform.position, player.transform.position) < attackRange && cooldown <= 0) {
			//Attack
			player.GetComponent<PlayerStatus>().DamagePlayer(damage);
			cooldown = attackCooldown;
		}
	}
}
