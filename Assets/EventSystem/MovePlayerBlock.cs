using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerBlock : MonoBehaviour, EventBlock
{
    [SerializeField] private Vector2 direction;
    [SerializeField] private float duration;

    PlayerMovement playerMovement;

    private void Awake() {
        playerMovement = FindObjectOfType<PlayerMovement>();

        if (playerMovement == null) {
            Debug.LogError("Cannot find player.");
        }
    }

    public IEnumerator Activate() {
        playerMovement.cinematicInput = direction;
        yield return new WaitForSeconds(duration);
        playerMovement.cinematicInput = Vector2.zero;

        yield return null;
    }
}
