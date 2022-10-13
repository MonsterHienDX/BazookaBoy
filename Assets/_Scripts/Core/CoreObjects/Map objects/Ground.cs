using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : DestructiblePlatform
{
    public override void Init(Vector3 pos)
    {
        base.Init(pos);
        this.name = "Ground";
    }
}
