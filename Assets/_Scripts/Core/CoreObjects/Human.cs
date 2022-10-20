using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
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
    private HumanState _humanState => _animationComponent.humanState;

    private void OnEnable()
    {
        EventDispatcher.Instance.RegisterListener(EventID.ResetDataLevel, HandleEventResetDataLevel);
    }

    private void OnDisable()
    {
        EventDispatcher.Instance.RemoveListener(EventID.ResetDataLevel, HandleEventResetDataLevel);
    }

    private void HandleEventResetDataLevel(object param = null)
    {
        Reset();
    }

    protected virtual void Update()
    {
        if (!GameManager.instance.isPlaying || this.isDie || !GameManager.instance.delayAfterLoadLevelDone) return;
        if (this._physicComponent.GetCurrentVelocity() != Vector2.zero)
        {
            CheckDeathByForce(_physicComponent.GetCurrentVelocity());
        }
    }

    public virtual void Death()
    {
        if (isDie) return;
        this.isDie = true;
        EnableFXBlood(true);

        //  TODO: turn on rag doll
        _animationComponent.ChangeHumanState(HumanState.Die);
        _physicComponent.EnablePhysic(false);
    }

    public virtual void GetBulletAffect(Vector2 bulletExplodePos, float bulletExplodeRadius, float bulletAffectForce)
    {
        Vector2 direction = (Vector2)this.transform.position - bulletExplodePos;
        float forceRate = CommonFunctions.CalculateForceRateByDistanceToCenter(bulletExplodePos, this.transform.position, bulletExplodeRadius);
        _physicComponent.PushForce(direction.normalized, forceRate * bulletAffectForce);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (!GameManager.instance.delayAfterLoadLevelDone) return;

        CheckDeathByForce(this._physicComponent.GetCurrentVelocity());

        if (collision.gameObject.tag == "DestructibleObjects"
            || ((collision.transform.parent) && collision.transform.parent.gameObject.tag.Equals("DestructibleObjects"))
            )
        {
            CheckDieByMapObjects();
        }
    }

    public void CheckDeathByForce(Vector2 force)
    {
        if (!CanSufferForce(force))
        {
            Death();
        }
    }

    private void CheckDieByMapObjects()
    {
        if (Mathf.Abs(this._physicComponent.GetCurrentVelocity().x) > 0.4f
            || Mathf.Abs(this._physicComponent.GetCurrentVelocity().y) > 0.4f
        )
            Death();
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
        this._animationComponent.ResetState();
        this._animationComponent.ChangeHumanState(HumanState.Idle);

        //  TODO: Reset physic
        this._physicComponent.ResetVelocity();
        this._physicComponent.EnablePhysic(true);


        //  TODO: Reset transform
        this.transform.localPosition = _startPos;
        this.transform.localEulerAngles = _startRot;

        this.isDie = false;
    }

    public virtual void InitTransform(Vector3 pos)
    {
        this.transform.localPosition = pos;
        this._startPos = pos;
        this._startRot = this.transform.localEulerAngles;
    }
}