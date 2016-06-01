using UnityEngine;
using System.Collections;
using System;
using Assets.scripts.story;
using System.Collections.Generic;

public class TextSource : MonoBehaviour {

    public TextAsset text_asset;

    private string[] lines;
    private int current_line;
    private List<StoryEntry> story_entries;

    public List<StoryEntry> GetStoryEntries() {
        return story_entries;
    }

    private void Awake() {

        lines = text_asset.text.Split(new string[] { "\r\n", "\n" }, 
            StringSplitOptions.None);
        current_line = 0;

        story_entries = ParseLines(lines);
    }

    private List<StoryEntry> ParseLines(string[] input_lines) {

        List<StoryEntry> new_story_entries = new List<StoryEntry>();

        bool entry_assigned = false;
        StoryEntry current_entry = new StoryEntry();

        foreach (string line in input_lines) {

            if (line.StartsWith("---")) {

                if (entry_assigned) {
                    new_story_entries.Add(current_entry);
                }
                else {
                    entry_assigned = true;
                }

                current_entry = new StoryEntry();
            }
            else if (line.StartsWith("#")) {
                var field_vals = line.Split(new string[] { ":" },
                    StringSplitOptions.None);
                string field_key = field_vals[0];
                string field_val = field_vals[1];

                AssignFieldEntry(current_entry, field_key, field_val);

            }
            else {
                current_entry.AddStoryLine(line);
            }
        }

        return new_story_entries;
    }

    private void AssignFieldEntry(StoryEntry entry, string field_key, string field_val) {

        // Assign stat received from field to appropriate entry method

        switch (field_key) {
            case "# Title":
                entry.SetTitle(field_val);
                break;
            case "# Enemies":
                entry.SetEnemies(int.Parse(field_val));
                break;
            case "# Speed":
                entry.SetSpeed(int.Parse(field_val));
                break;
            default:
                Debug.LogWarning("Unvalid story format: " + field_key);
                break;
        }
    }

    private void Start () {

    }

    public string GetNextLine() {
        current_line += 1;
        return (lines[current_line - 1]);
    }
}
