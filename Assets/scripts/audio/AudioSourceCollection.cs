using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioSourceCollection : MonoBehaviour {

    public enum AudioSourceKey {
        bow_shoot,
        bow_snap,
        key_tap
    }

    [System.Serializable]
    public class AudioSourceClip {
        public AudioSourceKey audio_key;
        public AudioClip audio_clip;
    }

    public AudioSourceClip[] audio_clips;

    public void PlayClip(AudioSourceKey audio_source_key) {

        foreach(AudioSourceClip audio_clip_pair in audio_clips) {

            if (audio_clip_pair.audio_key == audio_source_key) {
                AudioSource audio_source = GetComponent<AudioSource>();
                audio_source.clip = audio_clip_pair.audio_clip;
                audio_source.Play();
            }
        }
    }
}
