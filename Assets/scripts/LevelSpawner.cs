using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.scripts.story;

public class LevelSpawner : MonoBehaviour {

    public GameObject spawn_object_prefab;

    private List<float> spawn_points;

	private void Start () {
        spawn_points = new List<float>();
        // spawn_points.Add(2);
        // spawn_points.Add(6);
        // spawn_points.Add(11);
        // spawn_points.Add(15);
    }

    public void AddStoryEntry(StoryEntry story_entry) {
        int enemy_count = story_entry.GetEnemyCount();
        GenerateNewSpawnPoints(enemy_count);
    }

    private void GenerateNewSpawnPoints(int count, float time_base = 2, float time_spread = 3) {

        for (int i = 0; i < count; i++) {
            float new_point = Time.timeSinceLevelLoad + Random.Range(time_base, time_base + time_spread);
            spawn_points.Add(new_point);
        }
        spawn_points.Sort();
    }
	
	private void Update () {
        float current_time = Time.realtimeSinceStartup;

        while (spawn_points.Count > 0 && current_time > spawn_points[0]) {
            float spawn_point = spawn_points[0];
            spawn_points.RemoveAt(0);

            Spawn();
        }
	}

    private void Spawn() {
        var spawned_obj = Instantiate(spawn_object_prefab);
        spawned_obj.transform.parent = transform;
        spawned_obj.transform.position = transform.position;
    }
}
