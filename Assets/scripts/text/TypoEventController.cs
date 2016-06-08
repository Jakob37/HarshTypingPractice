using UnityEngine;
using System.Collections;

public class TypoEventController : MonoBehaviour {

    public float fail_lock_time = 1f;
    private float current_lock_time;

    private DisplayText display_text_object;

	private void Start () {
        display_text_object = GameObject.FindObjectOfType<DisplayText>();
        current_lock_time = 0;
	}
	
    public void TypoEvent() {
        current_lock_time = fail_lock_time;
    }

    private void Update() {

    }
}
