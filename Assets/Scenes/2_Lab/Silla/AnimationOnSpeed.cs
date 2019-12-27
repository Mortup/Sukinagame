using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOnSpeed : MonoBehaviour
{
    [SerializeField] private float animationSpeedMultiplier = 1;
    [SerializeField] private float drag = 0.95f;
    private Animator animator;
    private Rigidbody2D rb;

    private void Awake() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        animator.speed = rb.velocity.magnitude * animationSpeedMultiplier;
    }
}
