using UnityEngine;
using TMPro;

public class Clonadora : MonoBehaviour
{
    [SerializeField] private TMP_Text screen;

    private void OnTriggerEnter2D(Collider2D collision) {
        IClonable clonable = collision.gameObject.GetComponent<IClonable>();
        if (clonable == null)
            return;

        screen.text = clonable.getName();
    }
}
