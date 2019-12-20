using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CustomEventBlock : MonoBehaviour, EventBlock {
    [SerializeField] private UnityEvent action;

    public IEnumerator Activate() {
        action.Invoke();
        yield return null;
    }
}
