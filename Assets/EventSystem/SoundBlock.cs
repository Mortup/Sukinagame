using System.Collections;
using UnityEngine;

public class SoundBlock : MonoBehaviour, EventBlock
{
    [SerializeField] AudioClip sound;
    [SerializeField] [Range (0,1)] float volume;

    private AudioSource source;

    private void Awake() {
        source = GetComponent<AudioSource>();

        if (source == null) {
            source = gameObject.AddComponent<AudioSource>();
            source.playOnAwake = false;
        }
    }

    public IEnumerator Activate() {
        source.volume = volume;
        source.clip = sound;
        source.Play();
        yield return null;
    }
}
