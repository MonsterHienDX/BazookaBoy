using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HumanPhysicComponent))]
public class Enemy : Human
{
    [SerializeField] private MeshRenderer _meshRenderer;
    public EnemyType type { get; protected set; }

    private void OnEnable()
    {
        EventDispatcher.Instance.RegisterListener(EventID.ResetDataLevel, HandleEventResetDataLevel);
    }

    private void OnDisable()
    {
        EventDispatcher.Instance.RemoveListener(EventID.ResetDataLevel, HandleEventResetDataLevel);
    }

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

    public override void Enable(bool enable)
    {
        base.Enable(enable);
        _physicComponent.EnablePhysic(enable);
        _meshRenderer.gameObject.SetActive(enable);
    }

    private void HandleEventResetDataLevel(object param = null)
    {
        this.Enable(false);
    }

}
