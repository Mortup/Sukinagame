using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    [SerializeField] private Color startColor = Color.clear;
    [SerializeField] private bool fadeFromBlackAtStart = false;

    private Image image;
    private const float defaultFadeTime = 2f;

    private static Fader _instance;
    public static Fader instance {
        get {
            if (_instance == null) {
                Debug.LogError("Trying to access UISounds while not initializated.");
            }
            return _instance;
        }
    }

    private void Awake() {
        if (_instance != null) {
            Debug.LogError("Breaking singleton pattern.");
        }
        _instance = this;
        image = GetComponent<Image>();
        image.color = startColor;
    }

    private void Start() {
        if (fadeFromBlackAtStart) {
            FadeFromBlack();
        }
    }

    public void Fade(Color startColor, Color endColor, float time) {
        StartCoroutine(FadeCoroutine(startColor, endColor, time));
    }

    public void FadeToBlack() {
        Fade(new Color(0f, 0f, 0f, 0f), Color.black, defaultFadeTime);
    }

    public void FadeFromBlack() {
        Fade(Color.black, new Color(0f, 0f, 0f, 0f), defaultFadeTime);
    }

    private IEnumerator FadeCoroutine(Color startColor, Color endColor, float time) {
        image.color = startColor;

        float elapsedTime = 0f;
        while (elapsedTime < time) {
            image.color = Color.Lerp(startColor, endColor, elapsedTime / time);

            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        image.color = endColor;
    }
}
