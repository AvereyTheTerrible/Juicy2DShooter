using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AgentAnimationManager : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private void Awake()
    {
        if (!animator)
            animator = GetComponent<Animator>();
    }
    
    public void SetRunAnimation(bool val)
    {
        animator.SetBool("Run", val);
    }

    public void AnimateMovement(float velocity)
    {
        SetRunAnimation(velocity > 0);
    }

    public void AnimateShoot()
    {
        animator.SetBool("Fire", true);
    }

    public void AnimateStopShoot()
    {
        animator.SetBool("Fire", false);
    }

    public void AnimateHit()
    {
        animator.SetTrigger("Hit");
    }

    public void AnimateDeath()
    {
        animator.SetTrigger("Die");
    }

    public void SetWalkSpeed(int val)
    {
        animator.SetFloat("RunMultiplier", val);
    }
}