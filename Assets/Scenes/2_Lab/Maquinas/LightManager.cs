using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] private AudioSource turnOnAudio;
    [SerializeField] private AudioSource turnOffAudio;
    bool lightsOn;

    public void TurnOnLights() {
        if (turnOnAudio != null)
            turnOnAudio.Play();

        lightsOn = true;

        AffectedByLight[] targets = FindObjectsOfType<AffectedByLight>();
        for (int i = 0; i < targets.Length; i++) {
            targets[i].TurnOnLight();
        }
    }

    public void TurnOffLights() {
        if (turnOffAudio != null)
            turnOffAudio.Play();

        lightsOn = false;

        AffectedByLight[] targets = FindObjectsOfType<AffectedByLight>();
        for (int i = 0; i < targets.Length; i++) {
            targets[i].TurnOffLight();
        }
    }

    public void SwitchLights() {
        if (lightsOn) {
            TurnOffLights();
        }
        else {
            TurnOnLights();
        }
    }

    public bool AreLightsOn() {
        return lightsOn;
    }

    private void Start() {
        TurnOffLights();
    }
}
