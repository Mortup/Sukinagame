using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        GrassEffect effect = other.gameObject.GetComponentInChildren<GrassEffect>();
        if (effect != null) {
            effect.Activate();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        GrassEffect effect = other.gameObject.GetComponentInChildren<GrassEffect>();
        if (effect != null) {
            effect.Deactivate();
        }
    }
}
