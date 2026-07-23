using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public sealed class TreeAnimator : MonoBehaviour
{
    private static readonly int HitHash = Animator.StringToHash("Hit");
    private static readonly int DieHash = Animator.StringToHash("Die");

    private Animator animator;
    public event Action DeathAnimationFinished;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void PlayHit()
    {
        animator.SetTrigger(HitHash);
    }

    public void PlayDeath()
    {
        animator.SetTrigger(DieHash);
    }

    public void OnDeathAnimationFinish()
    {
        DeathAnimationFinished?.Invoke();
    }
}
