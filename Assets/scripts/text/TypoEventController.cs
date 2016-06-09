using UnityEngine;
using System.Collections;

public class TypoEventController : MonoBehaviour {

    public float fail_lock_time = 1f;
    private float current_lock_time;
    public bool GetTypoLockActive { get { return current_lock_time > 0; } }

    private DisplayText display_text_object;

	private void Start () {
        display_text_object = GameObject.FindObjectOfType<DisplayText>();
        current_lock_time = 0;
	}
	
    public void StartTypoLock() {
        current_lock_time = fail_lock_time;
    }

    private void Update() {
        if (current_lock_time > 0) {
            current_lock_time -= Time.deltaTime;

            float red_tint = current_lock_time / fail_lock_time;
            display_text_object.SetRedTint(red_tint);
            display_text_object.SetText("Error!");
        }
        else {
            display_text_object.SetText("Type");
        }
    }
}
