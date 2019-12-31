using UnityEngine;

public class LightManager : MonoBehaviour
{
    bool lightsOn;

    public void TurnOnLights() {
        lightsOn = true;

        AffectedByLight[] targets = FindObjectsOfType<AffectedByLight>();
        for (int i = 0; i < targets.Length; i++) {
            targets[i].TurnOnLight();
        }
    }

    public void TurnOffLights() {
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
