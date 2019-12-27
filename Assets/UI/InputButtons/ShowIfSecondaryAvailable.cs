using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowIfSecondaryAvailable : MonoBehaviour {
    [SerializeField] private Image image;
    [SerializeField] private PlayerInteraction playerInteraction;
    [SerializeField] Sprite regularSprite;
    [SerializeField] Sprite pushedSprite;

    private void Update() {
        image.enabled = playerInteraction.IsSecondaryInteracionAvailable();
        image.sprite = Input.GetButton("InteractSecondary") ? pushedSprite : regularSprite;
    }

}
