using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	[SerializeField] GameObject deathExplosion;

	public float speed;
	public int damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

//	void OnTriggerEnter(Collider col) {
//		if (col.gameObject.tag == "Enemy") {
//			col.gameObject.GetComponent<Health>().Damage (damage);
//		}
//		if (col.gameObject.tag != "Room") Destroy (gameObject);
//	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Enemy") {
			collision.gameObject.GetComponent<Health> ().Damage (damage);
		}
		if (collision.gameObject.tag != "Room") {
			Destroy (gameObject);
			DeathExplosion ();
		}
	}

	void DeathExplosion(){

		var expl = (GameObject)Instantiate(
			deathExplosion,
			transform.position,
			transform.rotation);


		// Destroy after 1 seconds
		Destroy(expl, 1.0f);        
	}
}
