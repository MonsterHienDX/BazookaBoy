using System.Collections;
using System.Collections.Generic;
using Destructible2D;
using UnityEngine;

public class Wood : DestructiblePlatform
{
    [SerializeField] private Sprite _woodSprite;
    protected override void OnValidate()
    {
        base.OnValidate();
        this.SetSprite(_woodSprite);
    }

    protected override void Awake()
    {
        base.Awake();
        this.SetSprite(_woodSprite);
    }

    public override void Reset()
    {
        // this._rb2D.velocity = Vector2.zero;
        this._rb2D.drag = 0;
        base.Reset();
        // OptimizeWhenInit();
    }

    public void OptimizeWhenInit()
    {
        this._destructibleSprite.Optimize();
        this._destructibleSprite.Optimize();
    }

    public override void Enable(bool enable)
    {
        base.Enable(enable);
        _rb2D.bodyType = (enable) ? RigidbodyType2D.Dynamic : RigidbodyType2D.Static;
    }

    public override void Init(Vector3 pos)
    {
        base.Init(pos);
        this.name = "WoodLog";
    }

}
