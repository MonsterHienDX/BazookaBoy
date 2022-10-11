using System.Collections;
using System.Collections.Generic;
using Destructible2D;
using UnityEngine;

[RequireComponent(typeof(D2dDestructibleSprite))]
public class PlatformBase : MonoBehaviour
{
    [SerializeField] protected D2dDestructibleSprite _destructibleSprite;
    [SerializeField] protected Vector2 size = Vector2.one;
    protected Vector3 sizeVec3;

    protected virtual void OnValidate()
    {
        SetSize(size);
    }

    public virtual void SetSize(Vector2 size)
    {
        sizeVec3.Set(size.x, size.y, 1);
        this.transform.localScale = sizeVec3;
    }
}
