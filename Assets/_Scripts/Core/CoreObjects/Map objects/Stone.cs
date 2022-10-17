using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : PlatformBase
{
    public override void Init(Vector3 pos)
    {
        base.Init(pos);
        this.name = "Stone";
    }

    public override void Enable(bool enable)
    {
        base.Enable(enable);
        _rb2D.bodyType = (enable) ? RigidbodyType2D.Dynamic : RigidbodyType2D.Static;
    }

    public override void Reset()
    {
        this._rb2D.velocity = Vector2.zero;
        this._rb2D.drag = 0;

        base.Reset();
    }
}
