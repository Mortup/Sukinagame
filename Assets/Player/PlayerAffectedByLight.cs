using UnityEngine;

public class PlayerAffectedByLight : AffectedByLight
{
    [SerializeField] private SpriteRenderer lightsOnSr;
    [SerializeField] private SpriteRenderer lightsOffSr;

    public override void TurnOnLight() {
        lightsOffSr.enabled = false;
        lightsOnSr.enabled = true;
    }

    public override void TurnOffLight() {
        lightsOffSr.enabled = true;
        lightsOnSr.enabled = false;
    }
}
