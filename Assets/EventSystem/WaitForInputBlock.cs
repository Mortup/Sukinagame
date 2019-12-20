using System.Collections;
using UnityEngine;

public class WaitForInputBlock : MonoBehaviour, EventBlock
{
    [Tooltip ("Si esta marcado, solo continua cuando se apreta el boton de interaccion.")]
    [SerializeField] private bool mustBeInteractionButton = false;
    [Tooltip("Si esta marcado, reproduce el sonido select de la ui al continuar (el mismo sonido de cuando se avanza en los dialogos).")]
    [SerializeField] private bool playSelectSound = true;

    public IEnumerator Activate() {
        while (true) {
            if (Input.anyKeyDown && mustBeInteractionButton == false)
                break;
            if (Input.GetButtonDown("Interact"))
                break;

            yield return null;
        }

        if (playSelectSound)
            UISounds.instance.PlayBlipSelect();

        yield return null;
    }
}
