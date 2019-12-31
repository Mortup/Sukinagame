using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurbujearAgua : MonoBehaviour
{
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void Burbujear() {
        LightManager lightManager = FindObjectOfType<LightManager>();
        if (lightManager.AreLightsOn()) {
            animator.SetTrigger("Burbujas");
        }
    }
}
