using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RagDollComponent))]
public class AnimationComponent : MonoBehaviour
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

    private void SetIdleState()
    {
        normalRenderObject.SetActive(true);
        animAndRagdollRenderObject.SetActive(false);
    }

    private void SetWinState()
    {
        normalRenderObject.SetActive(false);
        animAndRagdollRenderObject.SetActive(true);
        _ragDollComponent.EnableRagdollState(false);
        EnableAnimation(true);


        //  TODO: Play dancing anim
    }

    private void SetDieState()
    {
        normalRenderObject.SetActive(false);
        animAndRagdollRenderObject.SetActive(true);
        _ragDollComponent.EnableRagdollState(true);
        EnableAnimation(false);
    }

    public void ChangeAnimState()
    {

    }

    public void ResetState()
    {
        _ragDollComponent.ResetState();
    }
}
