using System.Collections;
using System.Collections.Generic;
using Destructible2D;
using UnityEngine;

public class PlatformBase : MonoBehaviour
{
    [SerializeField] protected Vector2 size = Vector2.one;
    [SerializeField] protected SpriteRenderer _spriteRenderer;
    protected Vector3 cachedSizeVec3;
    [SerializeField] protected Rigidbody2D _rb2D;
    public bool isActive { get; protected set; }
    protected Vector3 _startPos;
    protected Vector3 _startRot;
    protected int _instanceIDInit;

    private void OnEnable()
    {
        EventDispatcher.Instance.RegisterListener(EventID.ResetDataLevel, HandleEventResetDataLevel);
    }

    private void OnDisable()
    {
        EventDispatcher.Instance.RemoveListener(EventID.ResetDataLevel, HandleEventResetDataLevel);
    }

    protected virtual void HandleEventResetDataLevel(object param = null)
    {
        Reset();
        this.Enable(false);
    }

    protected virtual void OnValidate()
    {
        SetSize(size);
    }

    public virtual void SetSize(Vector2 size)
    {
        cachedSizeVec3.Set(size.x, size.y, 1);
        this.transform.localScale = cachedSizeVec3;
    }

    public Vector2 GetSizeSquare() => size;

    public virtual void Enable(bool enable)
    {
        this.isActive = enable;
        _spriteRenderer.enabled = enable;
    }

    public virtual void SetSprite(Sprite sprite) => this._spriteRenderer.sprite = sprite;

    public virtual void SetPosition(Vector3 pos) => this.transform.position = pos;

    public virtual void Init(Vector3 pos)
    {
        this.tag = "DestructibleObjects";
        this.transform.localPosition = pos;
        this._startPos = pos;
        this._startRot = this.transform.localEulerAngles;
        this._instanceIDInit = GetInstanceID();
    }

    public virtual void Reset()
    {
        this.transform.localPosition = _startPos;
        this.transform.localEulerAngles = _startRot;
        if (this.GetInstanceID() != _instanceIDInit) Destroy(this.gameObject);
    }
}
