using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.scripts.story;

public class LevelManager : MonoBehaviour {

    public enum GameCondition {
        before_start,
        running,
        win,
        lose_logic,
        lose_done
    }

    private Archer archer;
    private GameCondition current_game_condition;
    public GameCondition CurrentGameCondition { get { return current_game_condition; } }

    private StatusText status_text;
    // private List<StoryEntry> story_entries;

    private TypingController typing_controller;

	void Start () {

        current_game_condition = GameCondition.running;
        archer = GameObject.FindObjectOfType<Archer>();
        status_text = GameObject.FindObjectOfType<StatusText>();

        typing_controller = GameObject.FindObjectOfType<TypingController>();

        var my_text_source = GetComponent<TextSource>();
        // Debug.Log(my_text_source);
        // story_entries = my_text_source.GetStoryEntries();
        // Debug.Log(story_entries.Count);
	}

    public bool IsGameOver {
        get {
            return (current_game_condition == GameCondition.lose_done ||
                    current_game_condition == GameCondition.lose_logic);
        }
    }

    public void PlayerIsDead() {
        current_game_condition = GameCondition.lose_logic;
    }

    void Update () {

        if (current_game_condition == GameCondition.lose_logic) {
            LoseLogic();
            current_game_condition = GameCondition.lose_done;
        }

        if (current_game_condition == GameCondition.running) {
            if (archer.CurrentBowstringCount <= 0) {
                current_game_condition = GameCondition.lose_logic;
            }
        }
	}

    private void LoseLogic() {
        status_text.AssignText("Game over!");
    }
}
