using System.Collections;
using System.Collections.Generic;
using Destructible2D;
using UnityEngine;

[RequireComponent(typeof(D2dSplitter))]
public class DestructiblePlatform : PlatformBase
{
    [SerializeField] protected D2dSplitter _splitter;

    public virtual void ResetState()
    {
        _destructibleSprite.Rebuild();
    }

    protected virtual void OnSplit()
    {

    }
}
