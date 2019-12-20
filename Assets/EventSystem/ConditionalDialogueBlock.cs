using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalDialogueBlock : MonoBehaviour, EventBlock {
    [SerializeField] private string[] firstDialogSet;
    [SerializeField] private string[] secondDialogSet;
    [SerializeField] private bool cycleSets;

    private bool firstTime = true;

    public IEnumerator Activate() {
        DialogueBlock.showInteractPrompt = true;

        if (firstTime) {
            firstTime = false;
            yield return StartCoroutine(FindObjectOfType<DialogManager>().ShowText(firstDialogSet));
        }
        else {
            yield return StartCoroutine(FindObjectOfType<DialogManager>().ShowText(secondDialogSet));

            if (cycleSets)
                firstTime = true;
        }

        DialogueBlock.showInteractPrompt = false;
    }

}
