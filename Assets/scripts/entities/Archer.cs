using UnityEngine;
using System.Collections;

public class Archer : MonoBehaviour {

    public GameObject projectile_prefab;
    public int start_bowstring_count = 5;

    private int current_bowstring_count;
    public int CurrentBowstringCount { get { return current_bowstring_count; } }

    private GameObject arrow_counter;
    private AudioSource shoot_arrow_audio;

    private AudioSourceCollection audio_source_collection;
    private LevelManager level_manager;

    public bool HasArrows { get { return current_bowstring_count > 0; } }

    private void Awake() {
        current_bowstring_count = start_bowstring_count;
        shoot_arrow_audio = GetComponent<AudioSource>();
        audio_source_collection = GetComponent<AudioSourceCollection>();
    }

    private void Start () {
        level_manager = FindObjectOfType<LevelManager>();
    }

    public int GetBowstringCount() {
        return current_bowstring_count;
    }

    public void PunishError() {

        if (current_bowstring_count <= 0) {
            Debug.LogWarning("Attempt to punish for error - But no strings left");
            return;
        } 

        audio_source_collection.PlayClip(AudioSourceCollection.AudioSourceKey.bow_snap);
        current_bowstring_count -= 1;
    }

    public void TextEnteredSuccessfully() {
        audio_source_collection.PlayClip(AudioSourceCollection.AudioSourceKey.key_tap);
    }

    public void ShootArrow() {

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
