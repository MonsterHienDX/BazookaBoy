using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicComponentBase : MonoBehaviour
{
    [field: SerializeField] public Collider2D _collider2D { get; private set; }
    [field: SerializeField] public Rigidbody2D _rb2D { get; private set; }

    public virtual void PushForce(Vector2 direction, float force)
    {
        this._rb2D.AddForce(direction.normalized * force, ForceMode2D.Impulse);
    }

    public void EnablePhysic(bool enable)
    {
        _collider2D.enabled = enable;
        _rb2D.bodyType = (enable) ? RigidbodyType2D.Dynamic : RigidbodyType2D.Static;
    }

    public void ResetVelocity()
    {
        if (_rb2D.bodyType == RigidbodyType2D.Static) return;
        this._rb2D.velocity = Vector2.zero;
    }
}