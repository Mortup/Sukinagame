using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneBlock : MonoBehaviour, EventBlock {

    [SerializeField] string sceneName;

    public IEnumerator Activate() {
        Fader fader = GameObject.FindObjectOfType<Fader>();
        fader.FadeToBlack();
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(sceneName);
    }
}
