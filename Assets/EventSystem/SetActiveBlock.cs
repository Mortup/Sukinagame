using System.Collections;
using UnityEngine;

public class SetActiveBlock : MonoBehaviour, EventBlock
{
    [SerializeField] private bool setActive;
    [SerializeField] private GameObject target;

    public IEnumerator Activate() {
        target.SetActive(setActive);
        yield return null;
    }
}
