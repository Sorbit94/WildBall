using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private List<string> animationNames;

    [SerializeField] private void PlayRandomAnimation()
    {
        string randomAnimationName = animationNames[Random.Range(0, 3)];

        animator.Play(randomAnimationName);

        animator.SetTrigger("Random");
    }
}
