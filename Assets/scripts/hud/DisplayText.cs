using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour {

    private Text display_text;

	private void Start () {
        display_text = GetComponent<Text>();
	}

    public void SetText(string new_text) {
        display_text.text = new_text;
    }

    public void SetRedTint(float red_tint) {
        display_text.color = new Color(1, 1 - red_tint, 1 - red_tint);
    }
}
