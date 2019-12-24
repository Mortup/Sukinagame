using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogosCinematica : MonoBehaviour
{
    [SerializeField] private string[] texts;
    [SerializeField] private float[] times;
    [SerializeField] private float timeToChangeScene;
    private DialogManager dialogManager;

    private void Start() {
        dialogManager = FindObjectOfType<DialogManager>();

        if (texts.Length != times.Length) {
            Debug.LogError("Tiene que haber la misma cantidad de tiempos que de textos.");
        }

        StartCoroutine(ShowTexts());
    }

    private IEnumerator ShowTexts() {
        for (int i = 0; i < texts.Length; i++) {
            yield return StartCoroutine(dialogManager.ShowText(new string[] { texts[i] }, true, 1f));
        }
    }

    public void ChangeScene() {
        FindObjectOfType<Fader>().FadeToBlack();
    }

    private void Update() {
        if (timeToChangeScene > 0f) {
            timeToChangeScene -= Time.deltaTime;
        }
        else {
            SceneManager.LoadScene("1_Outside");
        }
    }
}
