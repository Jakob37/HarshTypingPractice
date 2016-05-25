using UnityEngine;
using System.Collections;

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
    public bool IsGameOver {
        get {
            return (current_game_condition == GameCondition.lose_done ||
                    current_game_condition == GameCondition.lose_logic);
        }
    }

    public void PlayerIsDead() {
        current_game_condition = GameCondition.lose_logic;
    }

    private StatusText status_text;

	void Start () {
        current_game_condition = GameCondition.running;

        archer = GameObject.FindObjectOfType<Archer>();
        status_text = GameObject.FindObjectOfType<StatusText>();
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
