using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HumanPhysicComponent))]
public class Enemy : Human
{
    [SerializeField] private MeshRenderer _meshRenderer;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) Death();
    }

    public override void Death()
    {
        base.Death();
        EventDispatcher.Instance.PostEvent(EventID.EnemyDie, this);
    }

    public void ChangeDieMaterial(Material material) => this._meshRenderer.material = material;

}
