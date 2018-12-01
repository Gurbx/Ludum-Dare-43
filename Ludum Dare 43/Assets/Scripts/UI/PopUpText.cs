using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpText : MonoBehaviour {

	[SerializeField] Text popupText;

	public void SetPopupText(string text) {
		popupText.text = text;
	}
}
