using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPhysicComponent : PhysicComponentBase
{
    private void FixedUpdate()
    {
        this.transform.right = _rb2D.velocity;
    }

    private float LookAt2D(Vector2 target)
    {
        Vector2 dir = (Vector2)GameManager.mainCamera.WorldToScreenPoint(this.transform.position) - target;

        return Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; ;
    }
}
