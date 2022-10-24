using System.Collections;
using System.Collections.Generic;
using Destructible2D.Examples;
using UnityEngine;

[RequireComponent(typeof(D2dExplosion))]
public class ExplodeComponent : MonoBehaviour
{
    [SerializeField] private D2dExplosion _explosion;
    public bool hasExploded { get; protected set; }

    public void Explode(Vector2 explodePos)
    {
        if (hasExploded) return;
        _explosion.Explode(explodePos);
        hasExploded = true;
    }

    public void Reset()
    {
        hasExploded = false;
    }

}
