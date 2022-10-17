using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPhysicComponent : PhysicComponentBase
{
    public void EnableRagDollState(bool enable)
    {

    }

    public void EnableCollider(bool enable) => _collider2D.enabled = enable;
}
