using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HumanPhysicComponent))]
[RequireComponent(typeof(AnimationComponent))]
public class Human : MonoBehaviour
{
    [SerializeField] protected HumanPhysicComponent _physicComponent;
    [SerializeField] protected AnimationComponent _animationComponent;
    [SerializeField] protected float forceCanSuffer;
    [SerializeField] protected ParticleSystem _fx_blood;

    public bool isDie { get; protected set; }

    protected virtual void Start()
    {
        ResetState();
    }

    public virtual void Init()
    {

    }

    public virtual void Death()
    {
        this.isDie = true;
        EnableFXBlood(true);
    }

    public virtual void ChangeAnimState()
    {

    }

    public void ResetState()
    {
        EnableFXBlood(false);
        this.isDie = false;
    }

    public virtual void GetBulletAffect(Vector2 bulletExplodePos, float bulletExplodeRadius, float bulletAffectForce)
    {
        Vector2 direction = (Vector2)this.transform.position - bulletExplodePos;
        float forceRate = CommonFunctions.CalculateForceRateByDistanceToCenter(bulletExplodePos, this.transform.position, bulletExplodeRadius);
        _physicComponent.PushForce(direction.normalized, forceRate * bulletAffectForce);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (!CanSufferForce(collision.relativeVelocity))
        {
            Death();
        }
    }

    private bool CanSufferForce(Vector2 force)
    {
        Debug.Log($"{this.name} suffer force: " + force);
        return (Mathf.Abs(force.x) < forceCanSuffer && Mathf.Abs(force.y) < forceCanSuffer);
    }

    protected virtual void EnableFXBlood(bool enable)
    {
        if (enable) _fx_blood.Play();
        else _fx_blood.Stop();
    }
}
