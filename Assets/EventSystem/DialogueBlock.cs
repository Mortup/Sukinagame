using System.Collections;
using UnityEngine;

public class DialogueBlock : MonoBehaviour, EventBlock
{
    private static bool showInteractPrompt;

    [SerializeField] private string[] texts;

    public IEnumerator Activate() {
        showInteractPrompt = true;
        yield return StartCoroutine(FindObjectOfType<DialogManager>().ShowText(texts));
        showInteractPrompt = false;
    }

    public static bool ShouldShowInteractPrompt() {
        return showInteractPrompt;
    }
}
