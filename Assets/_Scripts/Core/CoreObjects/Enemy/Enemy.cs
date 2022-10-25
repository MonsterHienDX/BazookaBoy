using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HumanPhysicComponent))]
public class Enemy : Human
{
    public EnemyType type { get; protected set; }

    private void OnEnable()
    {
        this.RegisterListener(EventID.ResetDataLevel, HandleEventResetDataLevel);
        this.RegisterListener(EventID.EndLevel, HandleEventEndLevel);
    }

    private void OnDisable()
    {
        this.RemoveListener(EventID.ResetDataLevel, HandleEventResetDataLevel);
        this.RemoveListener(EventID.EndLevel, HandleEventEndLevel);
    }

    public override void Death()
    {
        this.PostEvent(EventID.EnemyDie, this);
        base.Death();
    }

    public void Init(EnemyType type)
    {
        this.type = type;
    }

    public override void Enable(bool enable)
    {
        base.Enable(enable);
        _physicComponent.EnablePhysic(enable);
    }

    public override void Reset()
    {
        base.Reset();
    }

    private void HandleEventResetDataLevel(object param = null)
    {
        this.Enable(false);
    }

    private void HandleEventEndLevel(object param = null)
    {
        if (isDie) return;
        this._animationComponent.PlayAnimEndLevel();
    }

}
