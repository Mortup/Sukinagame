using UnityEngine;

public class OnStartBlockTrigger : MonoBehaviour
{
    private void Start() {
        PlayerInteraction playerInteraction = FindObjectOfType<PlayerInteraction>();
        if (playerInteraction == null) {
            Debug.LogError("Parece que no hay player en la escena.");
        }

        EventBlock[] blocks = gameObject.GetComponents<EventBlock>();
        StartCoroutine(playerInteraction.ActivateBlocks(blocks));
    }
}
