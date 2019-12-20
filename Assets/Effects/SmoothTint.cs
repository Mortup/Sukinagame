using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothTint : MonoBehaviour
{
    [SerializeField] [Range(0,1)] private float colorTransitionSpeed;
    private SpriteRenderer spriteRenderer;
    private Color targetColor;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        targetColor = spriteRenderer.color;
    }

    public void SetTargetColor(Color color) {
        targetColor = color;
    }

    private void Update() {
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, targetColor, colorTransitionSpeed);
    }
}
