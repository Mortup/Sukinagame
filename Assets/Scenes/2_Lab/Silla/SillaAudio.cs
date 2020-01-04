using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SillaAudio : MonoBehaviour
{
    [SerializeField] AudioSource source;

    private void OnCollisionEnter2D(Collision2D collision) {
        source.Play();
    }
}
