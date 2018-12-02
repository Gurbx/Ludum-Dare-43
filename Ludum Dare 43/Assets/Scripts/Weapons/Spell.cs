using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spell : MonoBehaviour, UsableItem {

	public PlayerStatus stats;
	private InventorySlot slot;

	private float cooldown = 0.65f;
	private float timer = 0;

	public int id;
	[SerializeField] string name;
	[TextArea]
	[SerializeField] string description;
	[SerializeField] Sprite icon;

	[SerializeField] private GameObject projectilePrefab;
	[SerializeField] private Transform projectileSpawn;

	[SerializeField] private int manaCost = 1;

	[SerializeField] AudioSource audio;

	private Animator animator;


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
	}
		
	public void UseItem() {
		if (timer > 0)
			return;
		//Return if not enough mana
		if (PlayerStatus.mana < manaCost)
			return;

		timer = cooldown;
		animator.SetTrigger ("Attack");
		stats.useMana (manaCost);
		audio.Play ();

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

	public int getID() {
		return id;
	}

	public void SetID (int id) {
		this.id = id;
	}
}
