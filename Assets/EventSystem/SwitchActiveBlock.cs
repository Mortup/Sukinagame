using System.Collections;
using UnityEngine;

public class SwitchActiveBlock : MonoBehaviour, EventBlock
{
    [SerializeField] private GameObject target;

    public IEnumerator Activate() {
        target.SetActive(!target.activeSelf);
        yield return null;
    }
}
