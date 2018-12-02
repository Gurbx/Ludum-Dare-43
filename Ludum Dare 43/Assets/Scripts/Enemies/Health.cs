using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	[SerializeField] private int health = 1;
	[SerializeField] GameObject deathExplosion;
	//[SerializeField] private ParticleEmitter emit;

	private CombatEvent listener;

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


	public void AddCombatEvent(CombatEvent listn) {
		this.listener = listn;
	}

	private void Die() {
		listener.EnemyDied ();
		DeathExplosion ();
		Destroy (gameObject);
	}

	void DeathExplosion(){
	//	emit.transform.parent = null;
	//	emit.transform.localScale = new Vector3 (1, 1, 1);

	//	emit.emissionRate = 0;


		var expl = (GameObject)Instantiate(
			deathExplosion,
			transform.position,
			transform.rotation);


		// Destroy after 1 seconds
		Destroy(expl, 1.0f);        
	}
}
