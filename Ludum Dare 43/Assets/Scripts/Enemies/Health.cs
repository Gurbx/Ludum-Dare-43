using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	[SerializeField] private int health = 1;
	[SerializeField] GameObject deathExplosion;
	[SerializeField] AudioSource audio;

	[SerializeField] GameObject deathSpawn;
	[SerializeField] int deathSpawnAmount = 1;
	//[SerializeField] private ParticleEmitter emit;

	private float timer = 0;
	private const float COOLDOWN = 0.25f;

	private CombatEvent listener;

	private Animator animator;

	void Start () {
		animator = GetComponent<Animator> ();
	}

	void Update() {
		timer -= Time.deltaTime;
	}

	public void Damage(int damage) {
		if (timer > 0)
			return;

		timer = COOLDOWN;
		animator.SetTrigger ("Hit");
		health -= damage;
		if (health <= 0) {
			health = 0;
			Die ();
		} else
			audio.Play ();
	}


	public void AddCombatEvent(CombatEvent listn) {
		this.listener = listn;
	}

	private void Die() {
		listener.EnemyDied ();
		DeathExplosion ();
		if (deathSpawn != null) {
			for (int i = 0; i < deathSpawnAmount; i++) {
				var spwn = (GameObject)Instantiate(
					deathSpawn,
					transform.position,
					transform.rotation);
				spwn.GetComponent<Health> ().AddCombatEvent (listener);
			}
		}
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
