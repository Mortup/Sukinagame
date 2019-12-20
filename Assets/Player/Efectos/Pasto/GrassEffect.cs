using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassEffect : MonoBehaviour
{
    [SerializeField] private SpriteRenderer iroRenderer;
    [SerializeField] private float animationSpeed;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private Vector3 lastPosition;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void LateUpdate() {
        spriteRenderer.sortingOrder = iroRenderer.sortingOrder + 1;

        if (Vector3.Distance(lastPosition, transform.position) > 0.1f) {
            animator.speed = animationSpeed;
        }
        else {
            animator.speed = 0f;
        }
        lastPosition = transform.position;
    }

    public void Activate() {
        spriteRenderer.enabled = true;
    }

    public void Deactivate() {
        spriteRenderer.enabled = false;
    }
}
