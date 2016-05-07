using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EntryText : MonoBehaviour {

    private string targetText = "This is a target text";
    private string typedText;

    private Text myText;

	void Start () {

        typedText = "";
        myText = GetComponent<Text>();
        myText.text = "";
	}

    void Update() {

        if (Input.GetKeyDown(KeyCode.Backspace) && typedText.Length > 0) {
            typedText = typedText.Substring(0, typedText.Length - 1);
        }
        else {
            foreach (char c in Input.inputString) {
                //print(c);
                typedText += c;
            }
        }

        string visual_text = GenerateVisualText(targetText, typedText);
        myText.text = visual_text;
    }

    private string GenerateVisualText(string target_text, string typed_text) {

        string green_tag = "<color=\"#009900\">{0}</color>";
        string red_tag = "<color=\"#990000\">{0}</color>";
        string yellow_tag = "<color=\"#999900\">{0}</color>";

        string visual_text = "";
        string add_char;

        for (int i = 0; i < target_text.Length; i++) {

            string target_char = target_text.Substring(i, 1);

            if (i < typedText.Length) {

                string typed_char = typed_text.Substring(i, 1);

                if (target_char == typed_char) {
                    add_char = string.Format(green_tag, target_char);
                }
                else {
                    add_char = string.Format(red_tag, target_char);
                }
            }
            else if (i == typedText.Length) {
                if (target_char == " ") {
                    add_char = string.Format(yellow_tag, "_");
                }
                else {
                    add_char = string.Format(yellow_tag, target_char);
                }
            }
            else {
                add_char = target_char;
            }

            visual_text += add_char;
        }

        return visual_text;
    }
}
