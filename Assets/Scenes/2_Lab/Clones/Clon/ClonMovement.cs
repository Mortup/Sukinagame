using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float animationsSpeed;

    private Animator animator;
    private Rigidbody2D rb;

    Vector2 destination;
    Vector2 lastPosition;

    private void Awake() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        destination = transform.position + Vector3.left * 7f;
        lastPosition = transform.position;

        animator.speed = animationsSpeed;
    }

    private void Update() {
        if (currentTargetCooldown > 0f)
            currentTargetCooldown -= Time.deltaTime;
    }

    private void FixedUpdate() {
        if (Vector2.Distance(destination, transform.position) > 1f) {
            Vector2 direction = Vector2.ClampMagnitude((destination - (Vector2)transform.position), 1f);
            rb.MovePosition((Vector2)transform.position + direction * speed * Time.fixedDeltaTime);
            Debug.DrawLine(transform.position,destination, Color.green, 0.1f);

            Vector2 movement = ((Vector2)transform.position - lastPosition) / (Time.fixedDeltaTime * speed);

            animator.SetInteger("xDirection", Mathf.RoundToInt(movement.x));
            animator.SetInteger("yDirection", Mathf.RoundToInt(movement.y));
            animator.SetFloat("speed", movement.magnitude);
        }
        else {
            destination = transform.position;

            animator.SetInteger("xDirection", 0);
            animator.SetInteger("yDirection", 0);
            animator.SetFloat("speed", 0f);
        }

        lastPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        SetRandomTarget();
    }

    private void OnCollisionStay2D(Collision2D collision) {
        SetRandomTarget();
    }

    bool targetChanging = false;
    float targetCooldown = 0.5f;
    float currentTargetCooldown = 0f;
    private void SetRandomTarget() {
        if (targetChanging || currentTargetCooldown > 0f)
            return;

        currentTargetCooldown = targetCooldown;
        StartCoroutine(SetRandomTargetCoroutine());
    }

    private IEnumerator SetRandomTargetCoroutine() {
        destination = transform.position;
        targetChanging = true;
        yield return new WaitForSeconds(0.07f);
        Vector2 direction = Random.insideUnitCircle.normalized;
        destination = (Vector2)transform.position + direction * Random.Range(5f, 10f);
        targetChanging = false;
    }
}
