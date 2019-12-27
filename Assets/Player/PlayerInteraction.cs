using System.Collections;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
    private PlayerMovement playerMovement;
    private CircleCollider2D collider;

    private Vector2 facingDirection;
    private bool isEventActive;

    private void Awake() {
        playerMovement = GetComponent<PlayerMovement>();
        collider = GetComponent<CircleCollider2D>();
        isEventActive = false;
    }

    private void Update() {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (input.magnitude > 0.3f) {
            facingDirection = input.normalized;
        }

        if (isEventActive)
            return;

        if (Input.GetButtonDown("Interact")) {
            EventBlock[] blocks = GetTargetedBlocks();
            if (blocks.Length > 0) {
                StartCoroutine(ActivateBlocks(blocks));
            }
        }

        if (Input.GetButtonDown("InteractSecondary")) {
            EventBlock[] blocks = GetSecondaryBlocks();
            if (blocks.Length > 0) {
                StartCoroutine(ActivateBlocks(blocks));
            }
        }

    }

    private RaycastHit2D[] GetCollidersInFront() {
        Vector3 colliderCenter = transform.position + transform.TransformVector(collider.offset);
        RaycastHit2D[] hits = Physics2D.CircleCastAll(colliderCenter, collider.radius / 2f, facingDirection, collider.radius * 2f);
        return hits;
    }

    private EventBlock[] GetTargetedBlocks() {
        RaycastHit2D[] hits = GetCollidersInFront();
        for (int i = 0; i < hits.Length; i++) {
            RaycastHit2D hit = hits[i];

            if (hit.collider.gameObject == gameObject) {
                continue;
            }

            EventBlock[] blocks = hit.collider.gameObject.GetComponents<EventBlock>();
            if (blocks.Length > 0) {
                return blocks;
            }
        }

        return new EventBlock[0];
    }

    private EventBlock[] GetSecondaryBlocks() {
        RaycastHit2D[] hits = GetCollidersInFront();
        for (int i = 0; i < hits.Length; i++) {
            RaycastHit2D hit = hits[i];

            if (hit.collider.gameObject == gameObject) {
                continue;
            }

            SecondaryInteraction secondary = hit.collider.gameObject.GetComponent<SecondaryInteraction>();
            if (secondary == null)
                continue;

            EventBlock[] blocks = secondary.GetBlocks();
            if (blocks.Length > 0) {
                return blocks;
            }
        }

        return new EventBlock[0];
    }

    public bool IsInteractionAvailable() {
        return GetTargetedBlocks().Length > 0;
    }

    public bool IsSecondaryInteracionAvailable() {
        return GetSecondaryBlocks().Length > 0;
    }

    public IEnumerator ActivateBlocks(EventBlock[] blocks) {
        isEventActive = true;
        playerMovement.movementLocked = true;
        
        for (int j = 0; j < blocks.Length; j++) {
            EventBlock block = blocks[j];
            yield return StartCoroutine(block.Activate());
        }

        isEventActive = false;
        playerMovement.movementLocked = false;
        yield return null;
    }
}
