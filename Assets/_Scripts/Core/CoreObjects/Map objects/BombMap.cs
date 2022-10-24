using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMap : ObjectBase
{
    [SerializeField] private BulletFXComponent _fXComponent;

    [SerializeField] private PhysicComponentBase _physicComponent;

    [SerializeField] private float _forceCanSuffer;
    [SerializeField] private ExplodeComponent _explodeComponent;
    [SerializeField] private Renderer _renderer;
    private Vector3 _startPos;
    private Vector3 _startRot;
    private Vector2 _cachedVector2;
    private IEnumerator _explodeCO;

    protected override void HandleEventResetDataLevel(object param = null)
    {
        base.HandleEventResetDataLevel(param);
        if (_explodeCO != null) StopCoroutine(_explodeCO);
    }

    public void Explode(Vector2 explodePos)
    {
        Debug.Log($"{this.name} explode! Current velocity: {_physicComponent.GetCurrentVelocity()}");
        _fXComponent.PlayExplodeFX();
        _explodeComponent.Explode(explodePos);
        Enable(false);
    }

    private IEnumerator ExplodeWithDelay(float delay, Vector2 pos)
    {
        _cachedVector2.Set(CommonFunctions.RandomRange(-0.5f, 0.5f), 1f);
        _physicComponent.PushForce(_cachedVector2, 1.7f);
        yield return ExtensionClass.GetWaitForSeconds(delay);
        Explode(pos);
    }

    public void Init(Vector3 pos)
    {
        this.SetPosition(pos);
        this._startRot = transform.localEulerAngles;
    }

    public override void Enable(bool enable)
    {
        base.Enable(enable);

        _physicComponent.EnablePhysic(enable);

        _renderer.enabled = enable;
    }

    public override void Reset()
    {
        _physicComponent.Reset();
        _explodeComponent.Reset();
        this.transform.localPosition = _startPos;
        this.transform.localEulerAngles = _startRot;
    }

    public void SetPosition(Vector3 pos)
    {
        this.transform.localPosition = pos;
        this._startPos = pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckExplode(this._physicComponent.GetCurrentVelocity());

        Rigidbody2D rb2DOfCollision = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rb2DOfCollision) CheckExplode(rb2DOfCollision.velocity);
    }

    private void CheckExplode(Vector2 force)
    {
        Debug.Log($"{this.name} current velocity: {_physicComponent.GetCurrentVelocity()}");
        if (!CanSufferForce(force))
        {
            // this.Explode(this.transform.position);
            if (_explodeCO != null) StopCoroutine(_explodeCO);
            _explodeCO = ExplodeWithDelay(0.35f, this.transform.position);
            StartCoroutine(_explodeCO);
        }
    }

    private bool CanSufferForce(Vector2 force)
    {
        return (Mathf.Abs(force.x) < _forceCanSuffer && Mathf.Abs(force.y) < _forceCanSuffer);
    }
}
