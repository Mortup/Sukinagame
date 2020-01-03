using UnityEngine;

public class OnTriggerEnterBlockTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        PlayerInteraction playerInteraction = collision.gameObject.GetComponent<PlayerInteraction>();
        if (playerInteraction == null) {
            return;
        }

        EventBlock[] blocks = gameObject.GetComponents<EventBlock>();
        StartCoroutine(playerInteraction.ActivateBlocks(blocks));
    }
}
