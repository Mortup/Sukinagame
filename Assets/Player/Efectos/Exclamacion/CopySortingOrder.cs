using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopySortingOrder : MonoBehaviour
{
    [SerializeField] SpriteRenderer target;
    [SerializeField] int offset;

    private SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate() {
        spriteRenderer.sortingOrder = target.sortingOrder + offset;
    }
}
