using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimSystem : MonoBehaviour
{
    private Vector2 rootPos;
    [SerializeField] private RectTransform rootUI;
    private void Start()
    {
        rootPos = new Vector2(Screen.width * 0.4f, Screen.height * 0.35f);
        rootUI.anchoredPosition = rootPos;
    }

    public Quaternion GetAimDirection(Vector2 playerInput)
    {
        Vector2 dir = rootPos - playerInput;

        float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        var result = Quaternion.Euler(0f, 0f, rot_z);

        Debug.DrawRay(playerInput, dir.normalized * 50, Color.yellow);
        return result;
    }


}
