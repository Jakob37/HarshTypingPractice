using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelSpawner : MonoBehaviour {

    public GameObject spawn_object_prefab;

    private List<int> spawn_points;

	private void Start () {
        spawn_points = new List<int>();
        spawn_points.Add(2);
        spawn_points.Add(6);
        spawn_points.Add(11);
        spawn_points.Add(15);
    }
	
	private void Update () {
        float current_time = Time.realtimeSinceStartup;

        while (spawn_points.Count > 0 && current_time > spawn_points[0]) {
            int spawn_point = spawn_points[0];
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
