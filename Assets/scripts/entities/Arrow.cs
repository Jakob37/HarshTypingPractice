using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

    public float speed = 100;
    public float damage = 50;

	void Start () {
	
	}
	
	void Update () {
        transform.position += Vector3.right * speed * Time.deltaTime;
	}

    public void OnTriggerEnter2D(Collider2D collider) {

    }
}
