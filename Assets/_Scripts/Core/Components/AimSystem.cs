using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimSystem : MonoBehaviour
{
    private Transform pivotTransform;


    public void Init(Transform pivotTransform)
    {
        this.pivotTransform = pivotTransform;
    }

    public Quaternion GetAimDirection(Vector2 playerInput)
    {
        Vector2 dir = (Vector2)GameManager.mainCamera.WorldToScreenPoint(pivotTransform.position) - playerInput;

        float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        var result = Quaternion.Euler(0f, 0f, rot_z);
        return result;
    }


}
