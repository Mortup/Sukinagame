using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOnSpeed : MonoBehaviour
{
    [SerializeField] private float animationSpeedMultiplier = 1;
    [SerializeField] private float drag = 0.95f;
    private Animator animator;

    Vector3 lastPosition;
    Vector3 velocity;

    private void Awake() {
        animator = GetComponent<Animator>();
        lastPosition = transform.position;
    }

    private void Update() {
        Vector3 movementVelocity = (transform.position - lastPosition) / Time.deltaTime;

        if (movementVelocity.magnitude > velocity.magnitude)
            velocity = movementVelocity;
        else {
            transform.Translate(velocity * Time.deltaTime);
            velocity = velocity * drag;
        }

        animator.speed = velocity.magnitude * animationSpeedMultiplier;
        lastPosition = transform.position;
    }
}
