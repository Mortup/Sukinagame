using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSelections : MonoBehaviour
{
    [SerializeField] private Sprite[] selections;
    [SerializeField] private AudioSource startSource;
    [SerializeField] private AudioSource blipSelectSource;

    private int currentIndex = 0;

    private Image image;

    private void Awake() {
        image = GetComponent<Image>();
    }

    private void Update() {
        image.sprite = selections[currentIndex];

        if (Input.GetButtonDown("Up")) {
            currentIndex--;
            blipSelectSource.Play();
        }
        if (Input.GetButtonDown("Down")) {
            currentIndex++;
            blipSelectSource.Play();
        }

        currentIndex = (3 + currentIndex) % 3;
		
		if (Input.GetButtonDown("Interact")) {
			if (currentIndex == 0) {
                FindObjectOfType<Fader>().FadeToBlack();
                startSource.Play();
                StartCoroutine(ChangeSceneCoroutine("1_Outside", 3f));
			}
		}
    }

    public IEnumerator ChangeSceneCoroutine(string sceneName, float seconds) {
        GameObject introMusicGO = GameObject.FindGameObjectWithTag("IntroMusic");
        if (introMusicGO != null) {
            AudioSource musicSource = introMusicGO.GetComponent<AudioSource>();
            float totalSeconds = seconds;


            while (seconds > 0f) {
                musicSource.volume = seconds / totalSeconds;
                seconds -= Time.deltaTime;
                yield return null;
            }

            Destroy(musicSource.gameObject);
        }
        else {
            yield return new WaitForSeconds(seconds);
        }
        
        SceneManager.LoadScene(sceneName);
    }
}
