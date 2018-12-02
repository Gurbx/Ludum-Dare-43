using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, UsableItem {

	public PlayerStatus stats;
	private InventorySlot slot;

	private float cooldown = 0.5f;
	private float timer = 0;

	private Animator animator;

	[SerializeField] string name;
	[TextArea]
	[SerializeField] string description;
	[SerializeField] Sprite icon;
	[SerializeField] int damage;

	private SphereCollider colider;
	private bool coliderActive = true;


	[SerializeField] private Transform projectileSpawn;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		colider = GetComponent<SphereCollider> ();
		colider.enabled = false;
		colider.radius = 0;
	}

	private void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Enemy" && timer >= 0.3f) {
			col.gameObject.GetComponent<Health> ().Damage (damage);
		}
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0.3f && coliderActive) {
			coliderActive = false;
			colider.enabled = false;
			colider.radius = 0;
		}
	}

	public void UseItem() {
		if (timer > 0)
			return;
		timer = cooldown;
		animator.SetTrigger ("Attack");
		colider.enabled = true;
		coliderActive = true;
		colider.radius = 2.6f; 
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
