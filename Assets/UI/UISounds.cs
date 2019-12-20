using UnityEngine;

public class UISounds : MonoBehaviour
{
    [SerializeField] private AudioSource blipSelectSource;

    private static UISounds _instance;
    public static UISounds instance {
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
    }

    public void PlayBlipSelect() {
        blipSelectSource.Play();
    }
}
