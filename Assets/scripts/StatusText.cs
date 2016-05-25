using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatusText : MonoBehaviour {

    private Text status_text;

	private void Start () {
        status_text = GetComponent<Text>();
	}
	
    public void AssignText(string target_text) {
        status_text.text = target_text;
    }
}
