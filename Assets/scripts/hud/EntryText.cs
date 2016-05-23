using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EntryText : MonoBehaviour {

    public bool punish_mistakes = true;
    private bool should_be_punished;

    private string target_text = "This is a target text";
    private string typed_text;

    private Text myText;

    public bool TextFullyTyped() {
        return target_text == typed_text;
    }

    public void ResetText() {
        typed_text = "";
    }

    public bool ShouldBePunished() {
        if (punish_mistakes) {
            return should_be_punished;
        }
        else {
            return false;
        }
    }

    public void PunishmentCompleted() {
        if (!ShouldBePunished()) {
            Debug.LogWarning("Attempted to punish undeservingly!");
        }
        should_be_punished = false;
    }

	void Start () {

        typed_text = "";
        myText = GetComponent<Text>();
        myText.text = "";
	}

    void Update() {

        if (Input.GetKeyDown(KeyCode.Backspace) && typed_text.Length > 0) {
            typed_text = typed_text.Substring(0, typed_text.Length - 1);
        }
        else {
            foreach (char c in Input.inputString) {

                if (c == (char)KeyCode.Return) {
                    continue;
                }

                if (c == (char)KeyCode.Backspace) {
                    continue;
                }

                typed_text += c;
            }
        }

        if (punish_mistakes) {
            if (!target_text.StartsWith(typed_text)) {
                should_be_punished = true;
                typed_text = "";
            }
        }

        string visual_text = TextUtils.GenerateVisualText(target_text, typed_text);
        myText.text = visual_text;
    }
}
