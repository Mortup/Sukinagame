using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float animationsSpeed;

    private Animator animator;
    private Rigidbody2D rb;
    private AudioSource audioSource;

    Vector2 destination;
    Vector2 lastPosition;

    List<Vector2> directions;
    int lastDirection;

    private void Awake() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        destination = transform.position + Vector3.left * 7f;
        lastPosition = transform.position;

        animator.speed = animationsSpeed;

        directions = new List<Vector2>();
        directions.Add(Vector2.left);
        directions.Add(Vector2.up);
        directions.Add(Vector2.right);
        directions.Add(Vector2.down);
        lastDirection = Random.Range(0, 3);
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
        SetNewTarget(collision.gameObject.transform.position);
    }

    private void OnCollisionStay2D(Collision2D collision) {
        SetNewTarget(collision.gameObject.transform.position);
    }

    bool targetChanging = false;
    float targetCooldown = 0.5f;
    float currentTargetCooldown = 0f;
    private void SetNewTarget(Vector3 obstaclePosition) {
        if (targetChanging || currentTargetCooldown > 0f)
            return;

        currentTargetCooldown = targetCooldown;
        StartCoroutine(SetRandomTargetCoroutine(obstaclePosition));
    }

    private IEnumerator SetRandomTargetCoroutine(Vector3 obstaclePosition) {
        int newDirectionIndex = (lastDirection + 1) % directions.Count;
        Vector2 newDirection = directions[Random.Range(0,4)];
        Debug.DrawLine(transform.position, transform.position + (Vector3)newDirection * 5f, Color.red, 5f);
        destination = transform.position;
        targetChanging = true;
        if (audioSource.isPlaying == false) {
            audioSource.pitch = Random.Range(0.9f, 1.1f);
            audioSource.panStereo = Random.Range(0.7f, 1.3f);
            audioSource.Play();
        }
        yield return new WaitForSeconds(0.07f);
        destination = (Vector2)transform.position + newDirection * Random.Range(5f, 10f);
        targetChanging = false;
        lastDirection = newDirectionIndex;
    }
}
