using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float animationsSpeed;

    private Animator animator;
    private CircleCollider2D collider;
    private Rigidbody2D rb;

    public Vector2 cinematicInput;
    public bool movementLocked;

    private void Awake() {
        animator = GetComponent<Animator>();
        animator.speed = animationsSpeed;
        collider = GetComponent<CircleCollider2D>();
        movementLocked = false;
        cinematicInput = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();
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

        Vector3 colliderCenter = transform.position + transform.TransformVector(collider.offset);
        RaycastHit2D[] hit = Physics2D.CircleCastAll(colliderCenter, collider.radius / 2f, input.normalized, collider.radius / 2f);

        bool canWalk = true;
        /**
        for (int i = 0; i < hit.Length; i++) {
            if (hit[i].transform.gameObject != gameObject) {
                canWalk = false;
                break;
            }
        }**/
        if (canWalk == false) {
            animator.SetFloat("speed", 0f);
        }
        else {
            rb.MovePosition((Vector2)transform.position + input.normalized * Time.deltaTime * speed);
            animator.SetFloat("speed", input.magnitude);
        }
    }

}
