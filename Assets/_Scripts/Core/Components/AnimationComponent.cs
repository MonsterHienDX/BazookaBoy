using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RagDollComponent))]
public abstract class AnimationComponent : MonoBehaviour
{
    [SerializeField] protected Animator _animator;
    public HumanState humanState { get; private set; }
    [SerializeField] protected GameObject normalRenderObject;
    [SerializeField] protected GameObject animAndRagdollRenderObject;
    [SerializeField] protected RagDollComponent _ragDollComponent;

    public void EnableAnimation(bool enable) => this._animator.enabled = enable;

    public virtual void ChangeHumanState(HumanState state)
    {
        this.humanState = state;
        switch (humanState)
        {
            case HumanState.Idle:
                SetIdleState();
                break;
            case HumanState.Win:
                SetWinState();
                break;
            case HumanState.Die:
                SetDieState();
                break;
            default:
                SetIdleState();
                break;
        }
    }

    protected virtual void SetIdleState()
    {
        normalRenderObject.SetActive(true);
        animAndRagdollRenderObject.SetActive(false);
        EnableAnimation(true);
        ChangeAnimState(EnemyTriggerKey.idle);
    }

    protected virtual void SetWinState(string animatorTriggerKey = EnemyTriggerKey.dancing_win)
    {
        normalRenderObject.SetActive(true);
        animAndRagdollRenderObject.SetActive(false);
        // _ragDollComponent.EnableRagdollState(false);
        EnableAnimation(true);

        //  TODO: Play dancing anim
        ChangeAnimState(animatorTriggerKey);
    }

    protected virtual void SetDieState()
    {
        normalRenderObject.SetActive(false);
        animAndRagdollRenderObject.SetActive(true);
        _ragDollComponent.EnableRagdollState(true);
        EnableAnimation(false);
    }

    public void ChangeAnimState(string triggerKey) => this._animator.SetTrigger(triggerKey);

    public virtual void ResetState()
    {
        _ragDollComponent.ResetState();
    }

    public void AddContinueForceToAnimBody(Vector2 force) => _ragDollComponent.AddForceMainBody(force);

    public abstract void PlayAnimEndLevel();
}
