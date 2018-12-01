using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyInfo : MonoBehaviour {

	[SerializeField] private Text text;

	// Use this for initialization
	void Start () {
		text.text = "" + PlayerStatus.keys;
	}

	public void UpdateKeys() {
		text.text = "" + PlayerStatus.keys;
	}
}
