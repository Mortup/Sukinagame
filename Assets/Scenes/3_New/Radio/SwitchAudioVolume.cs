using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAudioVolume : MonoBehaviour
{
    [SerializeField] private bool startOn = false;
    private AudioSource audioSource;

    private float maxVolume;
    private float targetVolume;
    private bool isOn;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
        maxVolume = audioSource.volume;

        targetVolume = startOn ? maxVolume : 0f;
        isOn = startOn;
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

    public void TurnOn() {
        targetVolume = maxVolume;
        isOn = true;
    }

    public void TurnOff() {
        targetVolume = 0f;
        isOn = false;
    }
}
