using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clonadora : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Entro algo");
        IClonable clonable = collision.gameObject.GetComponent<IClonable>();
        if (clonable == null)
            return;

        Debug.Log(clonable.getName());
    }
}
