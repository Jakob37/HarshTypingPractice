using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.scripts.story;
using System;

public class StoryController : MonoBehaviour {

    private TextSource text_source;

    private List<StoryEntry> story_entries;
    private StoryEntry current_story_entry;
    private int current_entry;

    private void Awake() {
        text_source = GetComponent<TextSource>();
    }

    private void Start () {
        story_entries = text_source.GetStoryEntries();
        current_entry = 0;
    }

    //public string GetCurrentLine() {
    //    return story_entries[current_entry].GetCurrentLine();
    //}

    public StoryEntry GetCurrentEntry() {
        return story_entries[current_entry];
    }

    public StoryEntry GetSpawnEntry() {

        if (!IsNextNewStoryEntry()) {
            throw new ArgumentException("Next entry is out of bounds!");
        }

        return story_entries[current_entry + 1];
    }

    public bool HasNextLine() {
        if (story_entries[current_entry].HasNextLine()) {
            return true;
        }
        else {
            return current_entry < story_entries.Count - 1;
        }
    }

    public bool IsNextNewStoryEntry() {
        if (story_entries[current_entry].HasNextLine()) {
            return false;
        }
        else {
            return HasNextLine();
        }
    }

    public string GetNextLine() {
        if (!HasNextLine()) {
            throw new ArgumentOutOfRangeException("No more lines!");
        }

        if (!story_entries[current_entry].HasNextLine()) {
            current_entry += 1;
        }
        return story_entries[current_entry].GetNextLine();
    }
}
