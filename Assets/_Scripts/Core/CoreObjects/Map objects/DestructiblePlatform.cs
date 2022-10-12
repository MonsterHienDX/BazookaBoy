using System.Collections;
using System.Collections.Generic;
using Destructible2D;
using UnityEngine;

[RequireComponent(typeof(D2dSplitter))]
[RequireComponent(typeof(D2dDestructibleSprite))]
public class DestructiblePlatform : PlatformBase
{
    protected D2dDestructibleSprite _destructibleSprite;
    [SerializeField] protected D2dSplitter _splitter;
    protected virtual void Awake()
    {
        this._destructibleSprite = this.GetComponent<D2dDestructibleSprite>();
        this._splitter = this.GetComponent<D2dSplitter>();

    }

    public override void Enable(bool enable)
    {
        // if (!enable) Reset();
        base.Enable(enable);
    }

    public virtual void Reset()
    {
        _destructibleSprite.Rebuild();
        _destructibleSprite.Trim();
    }

    public virtual void ResetState()
    {
        _destructibleSprite.Rebuild();
    }

    protected virtual void OnSplit()
    {

    }
}
