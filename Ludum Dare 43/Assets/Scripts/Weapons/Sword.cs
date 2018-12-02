using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, UsableItem {

	public PlayerStatus stats;
	private InventorySlot slot;

	private Animator animator;

	[SerializeField] string name;
	[TextArea]
	[SerializeField] string description;
	[SerializeField] Sprite icon;

	[SerializeField] private Transform projectileSpawn;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UseItem() {
		animator.SetTrigger ("Attack");
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
