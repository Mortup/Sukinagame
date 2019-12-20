using System.Collections;
using UnityEngine;

public class WaitForSecondsBlock : MonoBehaviour, EventBlock
{
    [SerializeField] private float seconds;

    public IEnumerator Activate() {
        yield return new WaitForSeconds(seconds);
        yield return null;
    }
}
