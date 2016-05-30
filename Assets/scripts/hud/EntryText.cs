using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EntryText : MonoBehaviour {

    private Text my_text;
    
	private void Start () {

        my_text = GetComponent<Text>();
        my_text.text = "";
	}

    public void SetVisualText(string visual_text) {
        my_text.text = visual_text;
    }
}
