using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSelections : MonoBehaviour
{
    [SerializeField] private Sprite[] selections;

    private int currentIndex = 0;

    private Image image;

    private void Awake() {
        image = GetComponent<Image>();
    }

    private void Update() {
        image.sprite = selections[currentIndex];

        if (Input.GetButtonDown("Up")) {
            currentIndex--;
        }
        if (Input.GetButtonDown("Down")) {
            currentIndex++;
        }

        currentIndex = (3 + currentIndex) % 3;
		
		if (Input.GetButtonDown("Interact")) {
			if (currentIndex == 0) {
                FindObjectOfType<Fader>().FadeToBlack();
                StartCoroutine(ChangeSceneCoroutine("Intro", 3f));
			}
		}
    }

    public IEnumerator ChangeSceneCoroutine(string sceneName, float seconds) {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(sceneName);
    }
}
