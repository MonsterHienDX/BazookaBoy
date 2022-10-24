using System.Collections;
using System.Collections.Generic;
using Destructible2D;
using UnityEngine;

public class PlatformBase : ObjectBase
{
    [SerializeField] protected Vector2 size = Vector2.one;
    [SerializeField] protected SpriteRenderer _spriteRenderer;
    protected Vector3 cachedSizeVec3;
    [SerializeField] protected Rigidbody2D _rb2D;
    protected Vector3 _startPos;
    protected Vector3 _startRot;
    protected int _instanceIDInit;

    protected virtual void OnValidate()
    {
        SetSize(size);
    }

    public virtual void SetSize(Vector2 size)
    {
        cachedSizeVec3.Set(size.x, size.y, 1);
        this.transform.localScale = cachedSizeVec3;
    }

    public void SetPosition(Vector3 centerPos)
    {
        this.transform.localPosition = centerPos;
        this._startPos = centerPos;
    }

    public Vector2 GetSizeSquare() => size;

    public override void Enable(bool enable)
    {
        base.Enable(enable);
        _spriteRenderer.enabled = enable;
    }

    public virtual void SetSprite(Sprite sprite) => this._spriteRenderer.sprite = sprite;


    public virtual void Init(Vector3 centerPos, Vector3 groundCenterPos)
    {
        this.tag = GameObjectTag.DestructibleObjects;
        cachedSizeVec3.Set(centerPos.x + groundCenterPos.x, centerPos.y + groundCenterPos.y, centerPos.z + groundCenterPos.z);
        // this.transform.localPosition = cachedSizeVec3;
        this.SetPosition(centerPos);
        // this.transform.localPosition = centerPos;
        // this._startPos = cachedSizeVec3;
        this._startRot = this.transform.localEulerAngles;
        this._instanceIDInit = GetInstanceID();
    }

    public override void Reset()
    {
        this.transform.localPosition = _startPos;
        this.transform.localEulerAngles = _startRot;
        if (this.GetInstanceID() != _instanceIDInit) Destroy(this.gameObject);
    }
}
