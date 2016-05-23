using UnityEngine;
using System.Collections;

public class Archer : MonoBehaviour {

    public GameObject projectile_prefab;
    public int start_bowstring_count = 5;

    private int current_bowstring_count;
    private GameObject arrow_counter;
    private EntryText entry_text;

    public int GetBowstringCount() {
        return current_bowstring_count;
    }

	private void Start () {
        current_bowstring_count = start_bowstring_count;
        entry_text = FindObjectOfType<EntryText>();
	}

    private void Update () {

        FireLogic();
        if(entry_text.ShouldBePunished()) {
            entry_text.PunishmentCompleted();
            current_bowstring_count -= 1;
        }
	}

    private void FireLogic() {
        bool shoot_press = Input.GetKeyDown(KeyCode.Return);
        bool has_strings = current_bowstring_count > 0;
        bool correct_text = entry_text.TextFullyTyped();

        if (shoot_press && has_strings && correct_text) {
            ShootArrow();
            entry_text.ResetText();
        }
    }

    private void ShootArrow() {
        GameObject new_projectile = Instantiate(projectile_prefab) as GameObject;
        new_projectile.transform.parent = transform;
        new_projectile.transform.position = transform.position;
    }
}
