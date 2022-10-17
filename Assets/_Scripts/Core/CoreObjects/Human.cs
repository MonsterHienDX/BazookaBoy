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
    public bool isActive { get; private set; }
    public bool isDie { get; protected set; }
    protected Vector3 _startPos;
    protected Vector3 _startRot;

    protected virtual void Start()
    {
        ResetState();
    }

    public virtual void Death()
    {
        this.isDie = true;
        EnableFXBlood(true);

        //  TODO: turn on rag doll
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
        // Debug.Log($"{this.name} suffer force: " + force);
        return (Mathf.Abs(force.x) < forceCanSuffer && Mathf.Abs(force.y) < forceCanSuffer);
    }

    protected virtual void EnableFXBlood(bool enable)
    {
        if (enable) _fx_blood.Play();
        else _fx_blood.Stop();
    }

    public virtual void Enable(bool enable)
    {
        this.isActive = enable;
        Reset();
    }

    public virtual void Reset()
    {
        //  TODO: Turn off blood FX
        EnableFXBlood(false);

        //  TODO: Turn off rag doll

        //  TODO: Reset physic
        this._physicComponent.ResetVelocity();

        //  TODO: Reset transform
        this.transform.localPosition = _startPos;
        this.transform.localEulerAngles = _startRot;
    }

    public virtual void InitTransform(Vector3 pos)
    {
        this.transform.localPosition = pos;
        this._startPos = pos;
        this._startRot = this.transform.localEulerAngles;
    }
}
