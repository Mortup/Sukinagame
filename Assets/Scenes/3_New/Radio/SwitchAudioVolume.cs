using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAudioVolume : MonoBehaviour
{
    private AudioSource audioSource;

    private float maxVolume;
    private float targetVolume = 0f;
    private bool isOn = false;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
        maxVolume = audioSource.volume;
    }

    private void Start() {
        audioSource.volume = targetVolume;
    }

    private void Update() {
        audioSource.volume = Mathf.Lerp(audioSource.volume, targetVolume, 0.2f);
    }

    public void SwitchVolume() {
        if (isOn) {
            targetVolume = 0f;
        }
        else {
            targetVolume = maxVolume;
        }

        isOn = !isOn;
    }
}
