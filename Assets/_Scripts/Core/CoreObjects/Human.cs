using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HumanPhysicComponent))]
[RequireComponent(typeof(AnimationComponent))]
public class Human : MonoBehaviour
{
    [SerializeField] protected HumanPhysicComponent _physicComponent;
    [SerializeField] private AnimationComponent _animationComponent;

    public virtual void Init()
    {

    }

    public virtual void Death()
    {

    }

    public virtual void ChangeAnimState()
    {

    }

    public void ResetState()
    {

    }

    public virtual void OnCollideWithObjects()
    {

    }

    public virtual void GetBulletAffect(Vector2 bulletExplodePos, float bulletExplodeRadius, float bulletAffectForce)
    {
        Vector2 direction = (Vector2)this.transform.position - bulletExplodePos;
        float forceRate = CommonFunctions.CalculateForceRateByDistanceToCenter(bulletExplodePos, this.transform.position, bulletExplodeRadius);
        _physicComponent.PushForce(direction.normalized, forceRate * bulletAffectForce);
    }
}
