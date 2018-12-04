using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SacrificeTextHandler : MonoBehaviour {
	[SerializeField] private PlayerStatus playerStatus;
	[SerializeField] private Text effecText;

	[SerializeField] private float textFadeoutTime;
	[SerializeField] private Color outColor, inColor;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		FadeOut ();

		//if (Input.GetKeyDown (KeyCode.Q))
		//	SetSacrificeText ("LUCK INCREASED");
	}

	void FadeOut()
	{
		effecText.color = Color.Lerp(effecText.color, outColor, textFadeoutTime * Time.deltaTime);
	}

	public void SetSacrificeText(string msg) {
		effecText.text = msg;
		effecText.color = inColor;
	}
}
