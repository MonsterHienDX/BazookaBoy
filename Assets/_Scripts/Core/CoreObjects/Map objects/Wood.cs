using System.Collections;
using System.Collections.Generic;
using Destructible2D;
using UnityEngine;

public class Wood : DestructiblePlatform
{
    [SerializeField] private Sprite _woodSprite;

    protected override void Awake()
    {
        base.Awake();
        this._spriteRenderer.sprite = _woodSprite;
    }
    public void OptimizeWhenInit()
    {
        this._destructibleSprite.Optimize();
        this._destructibleSprite.Optimize();
    }
}
