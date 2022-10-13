using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : PlatformBase
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) Reset();
    }

    public override void Init(Vector3 pos)
    {
        base.Init(pos);
        this.name = "Stone";
    }

    public override void Reset()
    {
        base.Reset();
        this._rb2D.velocity = Vector2.zero;
    }
}
