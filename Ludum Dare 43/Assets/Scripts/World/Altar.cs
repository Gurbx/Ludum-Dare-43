using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour {

	private bool isUsed = false;
	private bool canInteract = false;
	private bool active = false;

	private GameObject popupText;
	private GameObject altarWindow;

	private GameObject room;

	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private Sprite usedSprite;
	[SerializeField] GameObject deathExplosion;

	// Use this for initialization
	void Start () {
		popupText = GameObject.Find ("UI/Popup Text");
		altarWindow = GameObject.Find ("UI/Sacrafice Window");
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E) && canInteract && !active) {
			Open ();
		}
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player") {
			if (isUsed)
				return;
			else
				popupText.SendMessage ("SetPopupText", "[E] Interact");
		
			canInteract = true;
		}
	}

	private void Open() {
		popupText.SendMessage ("SetPopupText", "");
		altarWindow.SendMessage ("Activate", gameObject);
		active = true;
	}

	void OnTriggerExit(Collider col) {
		if (col.tag == "Player") {
			popupText.SendMessage ("SetPopupText", "");
			altarWindow.SendMessage ("Deactivate");
			canInteract = false;
			active = false;
		}
	}

	public void AlatarUsed() {
		spriteRenderer.sprite = usedSprite;
		active = false;
		isUsed = true;
		room.GetComponent<Room>().RoomCleared ();
		DeathExplosion ();
	}

	public void SetRoom(GameObject room) {
		this.room = room;
	}

	private void DeathExplosion(){
		Vector3 position = new Vector3 (transform.position.x, 1, transform.position.z);
		var expl = (GameObject)Instantiate(
			deathExplosion,
			position,
			transform.rotation);


		// Destroy after 1 seconds
		Destroy(expl, 1.0f);        
	}
}
