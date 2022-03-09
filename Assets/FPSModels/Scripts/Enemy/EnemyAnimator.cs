using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PerformWalk(bool walk)
    {
        _animator.SetBool(AnimationTags.WALK_PARAMETER, walk);
    }

    public void PerformRun(bool run)
    {
        _animator.SetBool(AnimationTags.RUN_PARAMETER, run);
    }

    public void PerformAttack()
    {
        _animator.SetTrigger(AnimationTags.ATTACK_TRIGGER);
    }

    public void PerformDying()
    {
        _animator.SetTrigger(AnimationTags.DEAD_TRIGGER);
    }
}
