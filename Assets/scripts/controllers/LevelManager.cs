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
    private LevelSpawner level_spawner;
    private GameCondition current_game_condition;
    public GameCondition CurrentGameCondition { get { return current_game_condition; } }

    private StatusText status_text;
    // private List<StoryEntry> story_entries;

    private TypingController typing_controller;

	void Start () {

        current_game_condition = GameCondition.running;
        archer = GameObject.FindObjectOfType<Archer>();
        status_text = GameObject.FindObjectOfType<StatusText>();

        level_spawner = GetComponentInChildren<LevelSpawner>();
        typing_controller = GetComponentInChildren<TypingController>();

        var my_text_source = GetComponent<TextSource>();
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

        //Debug.Log(typing_controller.HasSpawnEntry());

        if (typing_controller.HasSpawnEntry()) {
            StoryEntry spawn_entry = typing_controller.GetSpawnEntry();
            Debug.Log(spawn_entry);
            level_spawner.AddStoryEntry(spawn_entry);
        }

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
