using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float animationsSpeed;
    [SerializeField] private Animator secondaryAnimator;
    [SerializeField] private AudioSource stepsSource;

    private Animator animator;
    private Rigidbody2D rb;

    public Vector2 cinematicInput;
    public bool movementLocked;

    private void Awake() {
        animator = GetComponent<Animator>();
        animator.speed = animationsSpeed;
        movementLocked = false;
        cinematicInput = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();

        if (secondaryAnimator != null) {
            secondaryAnimator.speed = animationsSpeed;
        }
    }

    private void Update() {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (movementLocked) {
            input = cinematicInput;
        }

        int xDir = 0;
        int yDir = 0;

        if (input.x > 0)
            xDir = 1;
        else if (input.x < 0)
            xDir = -1;

        if (input.y > 0)
            yDir = 1;
        else if (input.y < 0)
            yDir = -1;

        animator.SetInteger("xDirection", xDir);
        animator.SetInteger("yDirection", yDir);

        rb.MovePosition((Vector2)transform.position + input.normalized * Time.deltaTime * speed);
        animator.SetFloat("speed", input.magnitude);
        stepsSource.volume = Mathf.Clamp01(input.magnitude);

        if (secondaryAnimator != null) {
            secondaryAnimator.SetInteger("xDirection", xDir);
            secondaryAnimator.SetInteger("yDirection", yDir);
            secondaryAnimator.SetFloat("speed", input.magnitude);
        }
    }

}
