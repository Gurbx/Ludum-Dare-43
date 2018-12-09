using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	[SerializeField] private GameObject wall, door;
	[SerializeField] private bool isDoor;

	// Use this for initialization
	void Start () {
		if (isDoor) {
			wall.SetActive (false);
		}
	}
		
	public void SetOpen(bool b) {
        if (door != null) {
            door.SetActive(!b);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setIsDoor(bool b) {
		isDoor = b;
		if (isDoor) {
			wall.SetActive (false);
		} else {
			wall.SetActive (true);
		}
	}
}
