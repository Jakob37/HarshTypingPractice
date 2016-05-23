using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float health = 100f;
    public float speed = 10;

	private void Start () {
	
	}
	
	private void Update () {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D collider) {

        GameObject other_obj = collider.gameObject;

        if (other_obj.GetComponent<Arrow>()) {
            Arrow arrow = other_obj.GetComponent<Arrow>();
            InflictDamage(arrow);
        }
    }

    private void InflictDamage(Arrow arrow) {
        health -= arrow.damage;
        Destroy(arrow.gameObject);
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
