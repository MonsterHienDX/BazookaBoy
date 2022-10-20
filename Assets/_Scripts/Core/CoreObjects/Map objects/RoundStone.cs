using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundStone : PlatformBase
{
    [SerializeField] protected float _radius = 1f;
    [SerializeField] private Collider2D _collider2D;

    public override void SetSize(Vector2 size)
    {
        this._radius = size.x;
        this.transform.localScale = Vector3.one * _radius;
    }

    public float GetSizeRound() => _radius;

    public override void Enable(bool enable)
    {
        base.Enable(enable);
        _collider2D.enabled = enable;
    }
}
