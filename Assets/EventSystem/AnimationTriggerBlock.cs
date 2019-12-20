using System.Collections;
using UnityEngine;

public class AnimationTriggerBlock : MonoBehaviour, EventBlock
{
    [SerializeField] private string triggerName;
    [SerializeField] private Animator animator;

    private void Awake() {
        if (animator == null)
            animator = GetComponent<Animator>();
    }

    public IEnumerator Activate() {
        animator.SetTrigger(triggerName);
        yield return null;
    }
}
