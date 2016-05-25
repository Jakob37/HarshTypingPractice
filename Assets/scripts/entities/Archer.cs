using UnityEngine;
using System.Collections;

public class Archer : MonoBehaviour {

    public GameObject projectile_prefab;
    public int start_bowstring_count = 5;

    private int current_bowstring_count;
    public int CurrentBowstringCount { get { return current_bowstring_count; } }

    private GameObject arrow_counter;
    private EntryText entry_text;
    private AudioSource shoot_arrow_audio;

    private AudioSourceCollection audio_source_collection;
    private LevelManager level_manager;

    private void Awake() {
        current_bowstring_count = start_bowstring_count;
    }

    private void Start () {
        shoot_arrow_audio = GetComponent<AudioSource>();
        audio_source_collection = GetComponent<AudioSourceCollection>();
        level_manager = FindObjectOfType<LevelManager>();
        entry_text = FindObjectOfType<EntryText>();
    }

    public int GetBowstringCount() {
        return current_bowstring_count;
    }

    private void Update () {

        if (level_manager.IsGameOver) {
            return;
        }

        FireLogic();

        if (entry_text.ShouldBePunished()) {
            entry_text.PunishmentCompleted();
            current_bowstring_count -= 1;
            audio_source_collection.PlayClip(AudioSourceCollection.AudioSourceKey.bow_snap);
        }
        else if (entry_text.WasTextEntered()) {
            audio_source_collection.PlayClip(AudioSourceCollection.AudioSourceKey.key_tap);
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

        audio_source_collection.PlayClip(AudioSourceCollection.AudioSourceKey.bow_shoot);
        GameObject new_projectile = Instantiate(projectile_prefab) as GameObject;
        new_projectile.transform.parent = transform;
        new_projectile.transform.position = transform.position + Vector3.right * 10;
    }

    public void OnTriggerEnter2D(Collider2D collider) {
        GameObject other_obj = collider.gameObject;
        if (other_obj.GetComponent<Enemy>()) {
            level_manager.PlayerIsDead();
        }
    }
}
