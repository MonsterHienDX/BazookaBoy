using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicComponentBase : MonoBehaviour
{

    [SerializeField] protected Collider2D _collider2D;
    [SerializeField] protected Rigidbody2D _rb2D;


    public virtual void PushForce(Vector2 direction, float force)
    {
        this._rb2D.AddForce(direction.normalized * force, ForceMode2D.Impulse);
    }

    public void EnablePhysic(bool enable)
    {
        _collider2D.enabled = enable;
        _rb2D.bodyType = (enable) ? RigidbodyType2D.Dynamic : RigidbodyType2D.Static;
    }

}
