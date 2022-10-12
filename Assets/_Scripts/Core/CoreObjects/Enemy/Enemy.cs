using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HumanPhysicComponent))]
public class Enemy : Human
{
    [SerializeField] private MeshRenderer _meshRenderer;
    public EnemyType type { get; protected set; }

    public override void Death()
    {
        EventDispatcher.Instance.PostEvent(EventID.EnemyDie, this);
        base.Death();
    }

    public void ChangeDieMaterial(Material material) => this._meshRenderer.material = material;

    public void Init(EnemyType type)
    {
        this.type = type;
    }

}
