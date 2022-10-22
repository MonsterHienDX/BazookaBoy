using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimSystem : MonoBehaviour
{
    private Vector2 rootPos;
    [SerializeField] private RectTransform rootUI;
    [SerializeField] private BulletBaseD2D ghostBullet;
    [SerializeField] private LineRenderer lineRenderer;

    private void OnEnable()
    {
        this.RegisterListener(EventID.EndLevel, HideTrajectoryLine);
        this.RegisterListener(EventID.PlayerReloadBullet, HideTrajectoryLine);
    }

    private void OnDisable()
    {
        this.RemoveListener(EventID.EndLevel, HideTrajectoryLine);
        this.RemoveListener(EventID.PlayerReloadBullet, HideTrajectoryLine);
    }

    private void Start()
    {
        rootPos = new Vector2(Screen.width * 0.4f, Screen.height * 0.35f);
        // rootPos = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
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

    public void ShowTrajectoryLine(Vector3 muzzlePos, Vector2 force)
    {
        lineRenderer.positionCount = 750;
        lineRenderer.SetPositions(GetLinePos(muzzlePos, force));
    }

    public void HideTrajectoryLine(object param = null)
    {
        lineRenderer.positionCount = 0;
    }
    private Vector3[] GetLinePos(Vector2 pos, Vector2 velocity, int steps = 750)
    {
        Rigidbody2D rb2D = ghostBullet.GetComponent<Rigidbody2D>();

        Vector3[] results = new Vector3[steps];

        float timeStep = Time.fixedDeltaTime / Physics2D.velocityIterations;
        Vector2 gravityAccel = Physics2D.gravity * rb2D.gravityScale * timeStep * timeStep;

        float drag = 1f - timeStep * rb2D.drag;
        Vector2 moveStep = velocity * timeStep / rb2D.mass;

        for (int i = 0; i < steps; i++)
        {
            moveStep += gravityAccel;
            moveStep *= drag;
            pos += moveStep;
            results[i] = pos;
        }

        return results;
    }
}
