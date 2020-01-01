﻿using UnityEngine;

public class AffectedByLight : MonoBehaviour
{
    [SerializeField] Sprite lightsOnSprite;
    [SerializeField] Sprite lightsOffSprite;

    [SerializeField] bool changesAnimator;
    [SerializeField] RuntimeAnimatorController lightsOnAnimator;
    [SerializeField] RuntimeAnimatorController lightsOffAnimator;

    protected SpriteRenderer sr;
    protected Animator animator;

    private void Awake() {
        sr = GetComponent<SpriteRenderer>();

        if (changesAnimator)
            animator = GetComponent<Animator>();
    }

    public virtual void TurnOnLight() {
        if (changesAnimator) {
            float animTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            animator.runtimeAnimatorController = lightsOnAnimator;
            animator.Play("DefaultState", 0, animTime);
        }
        else {
            sr.sprite = lightsOnSprite;
        }
    }

    public virtual void TurnOffLight() {
        if (changesAnimator) {
            float animTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            animator.runtimeAnimatorController = lightsOffAnimator;
            animator.Play("DefaultState", 0, animTime);
        }
        else {
            sr.sprite = lightsOffSprite;
        }
    }
}
