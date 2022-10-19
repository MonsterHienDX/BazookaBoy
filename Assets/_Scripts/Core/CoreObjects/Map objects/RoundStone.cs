using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundStone : PlatformBase
{
    [SerializeField] protected float _radius = 1f;

    public override void SetSize(Vector2 size)
    {
        this._radius = size.x;
        this.transform.localScale = Vector3.one * _radius;
    }

    public float GetSizeRound() => _radius;
}
