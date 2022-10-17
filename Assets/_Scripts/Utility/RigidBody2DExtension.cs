using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RigidBody2DExtension
{
    public static void AddForceWithAction(this Rigidbody2D rigidbody2D, Vector2 force, Action action = null)
    {
        rigidbody2D.AddForce(force);
        action?.Invoke();
    }

}
