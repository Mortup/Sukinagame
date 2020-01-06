using System.Collections;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogContainer;
    [SerializeField] private TMP_Text text;
    [SerializeField] private float textSpeed;
    [SerializeField] private AudioSource bipbipSource;

    

    public IEnumerator ShowText(string[] texts, bool autoContinue = false, float timeToContinue=0f) {
        UISounds.instance.PlayBlipSelect();
        dialogContainer.SetActive(true);
        text.text = "";
        yield return new WaitForSeconds(0.05f);

        for (int i = 0; i < texts.Length; i++) {
            float remainingAutoTime = timeToContinue;
            bipbipSource.volume = 1f;

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
                    if (Input.GetButtonDown("Interact") && autoContinue == false) {
                        UISounds.instance.PlayBlipSelect();
                        yield return null;
                        j = currentDialog.Length;
                    }

                    remainingTime -= Time.deltaTime;
                    yield return null;
                }
            }
            text.text = currentDialog;

            bipbipSource.volume = 0f;
            while (true) {
                if (autoContinue) {
                    if (remainingAutoTime <= 0f) {
                        break;
                    }
                    else {
                        remainingAutoTime -= Time.deltaTime;
                    }
                }

                if (Input.GetButtonDown("Interact")) {
                    UISounds.instance.PlayBlipSelect();
                    yield return null;
                    break;
                }

                yield return null;
            }
        }

        bipbipSource.volume = 0f;
        dialogContainer.SetActive(false);
    }
}
