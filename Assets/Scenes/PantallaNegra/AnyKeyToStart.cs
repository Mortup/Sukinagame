using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyKeyToStart : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown) {
            SceneManager.LoadScene(1);
        }
    }
}
