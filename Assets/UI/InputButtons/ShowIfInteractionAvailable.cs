using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowIfInteractionAvailable : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private PlayerInteraction playerInteraction;
    [SerializeField] Sprite regularSprite;
    [SerializeField] Sprite pushedSprite;

    private void Update() {
        image.enabled = playerInteraction.IsInteractionAvailable() || DialogueBlock.ShouldShowInteractPrompt();
        image.sprite = Input.GetButton("Interact") ? pushedSprite : regularSprite;
    }

}
