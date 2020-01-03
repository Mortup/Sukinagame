using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurbujearAgua : MonoBehaviour
{
    private AudioSource bubbleSource;
    private Animator animator;

    private void Awake() {
        bubbleSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    public void Burbujear() {
        LightManager lightManager = FindObjectOfType<LightManager>();
        if (lightManager.AreLightsOn()) {
            animator.SetTrigger("Burbujas");
            bubbleSource.Play();
        }
    }
}
