using System.Collections;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogContainer;
    [SerializeField] private TMP_Text text;
    [SerializeField] private float textSpeed;

    

    public IEnumerator ShowText(string[] texts) {
        UISounds.instance.PlayBlipSelect();
        dialogContainer.SetActive(true);
        text.text = "";
        yield return new WaitForSeconds(0.05f);

        for (int i = 0; i < texts.Length; i++) {

            string currentDialog = texts[i];
            for (int j = 0; j < currentDialog.Length; j++) {
                float remainingTime = 1f / textSpeed;

                char currentChar = currentDialog[j];
                while (currentChar == '<')
                {
                    while (currentChar != '>')
                    {
                        j++;
                        currentChar = currentDialog[j];
                    }
                    j++;
                    if (j >= currentDialog.Length)
                    {
                        break;
                    }
                    currentChar = currentDialog[j];
                }
                text.text = currentDialog.Substring(0, j);

                while (remainingTime > 0f) {
                    if (Input.GetButtonDown("Interact")) {
                        UISounds.instance.PlayBlipSelect();
                        yield return null;
                        j = currentDialog.Length;
                    }

                    remainingTime -= Time.deltaTime;
                    yield return null;
                }
            }
            text.text = currentDialog;

            while (true) {
                if (Input.GetButtonDown("Interact")) {
                    UISounds.instance.PlayBlipSelect();
                    yield return null;
                    break;
                }

                yield return null;
            }
        }

        dialogContainer.SetActive(false);
    }
}
