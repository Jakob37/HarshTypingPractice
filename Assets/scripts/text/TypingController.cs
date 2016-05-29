using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.scripts.story;

public class TypingController : MonoBehaviour {

    // Components
    private Archer archer;
    private EntryText entry_text;
    private TextSource text_source;

    // Private attributes
    private List<StoryEntry> story_entries;
    private string current_typed_text;
    private string current_target_text;

    void Start () {
        archer = GameObject.FindObjectOfType<Archer>();
        entry_text = GameObject.FindObjectOfType<EntryText>();
        text_source = GetComponent<TextSource>();

        story_entries = text_source.GetStoryEntries();
        current_typed_text = "";
        current_target_text = "PLACEHOLDER TEXT";
    }

    void Update () {

        if (EraseAction()) {
            current_typed_text = EraseSingleLetterFromText(current_typed_text);
        }
        else {
            string new_typed_text = GetTypedText();
            current_typed_text += new_typed_text;
        }

        string visual_text = TextUtils.GenerateVisualText(current_target_text, current_typed_text);
        entry_text.SetVisualText(visual_text);
        //my_text.text = visual_text;
    }

    private bool EraseAction() {
        return Input.GetKeyDown(KeyCode.Backspace) && current_typed_text.Length > 0;
    }

    private string EraseSingleLetterFromText(string raw_text) {
        return raw_text.Substring(0, raw_text.Length - 1);
    }

    private string GetTypedText() {

        string typed_text = "";

        foreach (char c in Input.inputString) {

            if (c == (char)KeyCode.Return) {
                continue;
            }

            if (c == (char)KeyCode.Backspace) {
                continue;
            }

            typed_text += c;
        }

        return typed_text;
    }
}
