using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.scripts.story;
using System;

public class TypingController : MonoBehaviour {

    // Components
    private Archer archer;
    private EntryText entry_text;
    private StoryController story_controller;

    // Private attributes
    private List<StoryEntry> story_entries;
    private string current_typed_text;
    private string current_target_text;

    private StoryEntry spawn_entry;
    public bool HasSpawnEntry() {
        return spawn_entry != null;
    }

    public StoryEntry GetSpawnEntry() {

        if (!HasSpawnEntry()) {
            throw new ArgumentException("No spawn entry!");
        }
        var return_object = spawn_entry;
        spawn_entry = null;
        return return_object;
    }

    private void Awake() {
        archer = GameObject.FindObjectOfType<Archer>();
        entry_text = GameObject.FindObjectOfType<EntryText>();
        story_controller = GetComponentInChildren<StoryController>();
    }

    private void Start () {
        current_typed_text = "";
        current_target_text = story_controller.GetNextLine();
        spawn_entry = story_controller.GetCurrentEntry();
    }

    private void Update () {

        if (ShootAction()) {
            archer.ShootArrow();

            if (story_controller.IsNextNewStoryEntry()) {
                Debug.Log("Next is new story entry!");
                spawn_entry = story_controller.GetSpawnEntry();
            }

            if (story_controller.HasNextLine()) {

                current_target_text = story_controller.GetNextLine();
                current_typed_text = "";
            }
        }
        else if (EraseAction()) {
            current_typed_text = EraseSingleLetterFromText(current_typed_text);
        }
        else {
            string new_typed_text = GetTypedText();
            AssignNewTypedText(new_typed_text);
        }

        SyncVisualText();
    }

    private void AssignNewTypedText(string new_typed_text) {
        if (new_typed_text.Length > 0) {
            foreach (char c in new_typed_text) {

                if (current_typed_text.Length == current_target_text.Length) {
                    break;
                }

                current_typed_text += c;

                if (IsEnteredTextCorrect()) {
                    archer.TextEnteredSuccessfully();
                }
                else {
                    archer.PunishError();
                    current_typed_text = "";
                    break;
                }
            }
        }
    }

    private bool IsEnteredTextCorrect() {
        return current_target_text.StartsWith(current_typed_text);
    }

    private bool ShootAction() {
        return Input.GetKeyDown(KeyCode.Return) 
            && archer.HasArrows
            && current_typed_text == current_target_text;
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

    private void SyncVisualText() {
        string visual_text = TextUtils.GenerateVisualText(current_target_text, current_typed_text);
        entry_text.SetVisualText(visual_text);
    }
}
