using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryInteraction : MonoBehaviour
{
    [SerializeField] private GameObject interactionContainer;

    public EventBlock[] GetBlocks() {
        return interactionContainer.GetComponentsInChildren<EventBlock>();
    }
}
