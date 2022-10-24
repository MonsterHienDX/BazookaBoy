using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectBase : MonoBehaviour
{
    public bool isActive { get; protected set; }

    private void OnEnable()
    {
        EventDispatcher.Instance.RegisterListener(EventID.ResetDataLevel, HandleEventResetDataLevel);
    }

    private void OnDisable()
    {
        EventDispatcher.Instance.RemoveListener(EventID.ResetDataLevel, HandleEventResetDataLevel);
    }

    protected virtual void HandleEventResetDataLevel(object param = null)
    {
        Reset();
        this.Enable(false);
    }

    public virtual void Enable(bool enable)
    {
        this.isActive = enable;
    }

    public abstract void Reset();

}
