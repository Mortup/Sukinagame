using UnityEngine;

public class PlayerAffectedByLight : AffectedByLight
{
    [SerializeField] private SpriteRenderer lightsOffSr;

    public override void TurnOnLight() {
        lightsOffSr.enabled = false;
    }

    public override void TurnOffLight() {
        lightsOffSr.enabled = true;
    }
}
