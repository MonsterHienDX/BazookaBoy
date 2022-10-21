using System.Collections;
using System.Collections.Generic;
using Destructible2D;
using UnityEngine;

[RequireComponent(typeof(D2dSplitter))]
[RequireComponent(typeof(D2dDestructibleSprite))]
public class DestructiblePlatform : PlatformBase
{
    [SerializeField] protected D2dDestructibleSprite _destructibleSprite;
    [SerializeField] protected D2dSplitter _splitter;
    [SerializeField] protected D2dCollider _d2DCollider;

    protected virtual void Awake()
    {
    }

    public override void Enable(bool enable)
    {
        base.Enable(enable);
        _d2DCollider.enabled = enable;
    }

    public override void Reset()
    {
        base.Reset();
        _destructibleSprite.Clear();
        _destructibleSprite.Rebuild();
        _destructibleSprite.Trim();
    }
}
