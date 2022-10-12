using System.Collections;
using System.Collections.Generic;
using Destructible2D;
using UnityEngine;

public class PlatformBase : MonoBehaviour
{
    [SerializeField] protected Vector2 size = Vector2.one;
    [SerializeField] protected SpriteRenderer _spriteRenderer;
    protected Vector3 cachedSizeVec3;
    public bool isActive { get; protected set; }


    private void OnEnable()
    {
        // EventDispatcher.Instance.RegisterListener(EventID.ResetDataLevel, HandleEventResetDataLevel);
    }

    private void OnDisable()
    {
        // EventDispatcher.Instance.RemoveListener(EventID.ResetDataLevel, HandleEventResetDataLevel);
    }

    protected virtual void HandleEventResetDataLevel(object param = null)
    {
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

    public virtual void Enable(bool enable)
    {
        this.isActive = enable;
        this.gameObject.SetActive(enable);
    }

    public virtual void SetSprite(Sprite sprite) => this._spriteRenderer.sprite = sprite;

    public virtual void SetPosition(Vector3 pos) => this.transform.position = pos;
}
