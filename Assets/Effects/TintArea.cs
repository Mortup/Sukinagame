using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TintArea : MonoBehaviour
{
    [SerializeField] private Color color;

    private void OnTriggerEnter2D(Collider2D collision) {
        SmoothTint receiver = collision.gameObject.GetComponent<SmoothTint>();

        if (receiver == null)
            return;

        receiver.SetTargetColor(color);
    }

    private void OnTriggerExit2D(Collider2D collision) {
        SmoothTint receiver = collision.gameObject.GetComponent<SmoothTint>();

        if (receiver == null)
            return;

        receiver.SetTargetColor(Color.white);
    }
}
