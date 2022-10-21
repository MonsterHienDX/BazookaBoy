using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundStone : PlatformBase
{
    protected float _radius = 0.5f;
    [SerializeField] private CircleCollider2D _collider2D;

    public override void SetSize(Vector2 size)
    {
        this._radius = size.x;
        this.transform.localScale = Vector3.one * _radius;
        // _collider2D.radius = (0.5f * _radius / 2);
    }

    public override void Init(Vector3 pos, Vector3 groundCenterPos)
    {
        base.Init(pos, groundCenterPos);
        this.name = "Round Stone";
    }

    public float GetSizeRound() => _radius;

    public override void Enable(bool enable)
    {
        base.Enable(enable);
        _collider2D.enabled = enable;
    }

    public override void Reset()
    {
        base.Reset();
        _rb2D.drag = 0;
        _rb2D.velocity = Vector2.zero;
    }
}
