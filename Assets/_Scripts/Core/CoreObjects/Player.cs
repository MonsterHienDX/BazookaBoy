using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AimSystem))]
[RequireComponent(typeof(HumanPhysicComponent))]
[RequireComponent(typeof(AnimationComponent))]

public class Player : Human
{
    [SerializeField] private AimSystem _aimSystem;
    [SerializeField] private Transform gunBarrelTransform;
    [SerializeField] private Transform gunMuzzleTransform;
    [SerializeField] private Transform bodyTransform;
    [SerializeField] private Transform neckTransform;
    [SerializeField] private BulletManager _bulletManager;
    [SerializeField] private float fireForce;
    private Vector3 cachedVector3;
    [SerializeField] private int maxBullet;
    public int cachedMaxBullet { get; private set; }
    public bool isAiming { get; private set; }

    private void OnEnable()
    {
        EventDispatcher.Instance.RegisterListener(EventID.ResetDataLevel, HandleEventResetDataLevel);
    }

    private void OnDisable()
    {
        EventDispatcher.Instance.RemoveListener(EventID.ResetDataLevel, HandleEventResetDataLevel);
    }

    protected override void Update()
    {
        base.Update();
        if (!GameManager.instance.isPlaying || GameManager.instance.hasPopupShowing) return;
        if (Input.GetMouseButton(0)) Aim(Input.mousePosition);
        if (Input.GetMouseButtonUp(0)) Shoot();
    }

    private void HandleEventResetDataLevel(object param = null)
    {
        this.Reset();
    }

    public void Shoot()
    {
        if (!isAiming) return;
        this.isAiming = false;

        //  TODO: Check bullet amount
        if (cachedMaxBullet < 1)
            return;
        if (cachedMaxBullet <= 1)
            this.PostEvent(EventID.OutOfBullet);
        cachedMaxBullet -= 1;

        //  TODO: Get bullet
        BulletBaseD2D bullet = _bulletManager.GetBullet();
        bullet.SetInfo(this.gunMuzzleTransform.position, this.gunBarrelTransform.localEulerAngles);
        bullet.EnableBullet(true);

        //  TODO: Calculate direction and add force
        Vector2 direction = (Vector2)this.gunMuzzleTransform.position - (Vector2)this.transform.position;
        bullet.Fire(direction, fireForce);

        //  TODO: FX shoot

        //  TODO: Sound shoot

        //  TODO: PostEventShoot
        this.PostEvent(EventID.PlayerShot, bullet);
    }

    public override void Reset()
    {
        base.Reset();

        //  TODO: Reset aim direction
        this.cachedVector3.Set(gunBarrelTransform.localEulerAngles.x, gunBarrelTransform.localEulerAngles.y, 0f);
        this.gunBarrelTransform.localEulerAngles = cachedVector3;
        cachedMaxBullet = maxBullet;
    }

    private void Aim(Vector2 mousePos)
    {
        gunBarrelTransform.rotation = _aimSystem.GetAimDirection(mousePos);
        // bodyTransform.rotation = _aimSystem.GetAimDirection(mousePos);
        Vector3 cachedRotNeck = neckTransform.localEulerAngles;

        Debug.Log("gunBarrelTransform.localEulerAngles.z: " + gunBarrelTransform.localEulerAngles.z);
        if ((gunBarrelTransform.localEulerAngles.z > 0 && gunBarrelTransform.localEulerAngles.z <= 90)
            || (gunBarrelTransform.localEulerAngles.z > 270 && gunBarrelTransform.localEulerAngles.z <= 360)
        )
        {
            cachedVector3.Set(bodyTransform.localEulerAngles.x, 0, gunBarrelTransform.localEulerAngles.z);
            cachedRotNeck.Set(neckTransform.localEulerAngles.x, 0, neckTransform.localEulerAngles.z);
        }
        else
        {
            cachedVector3.Set(bodyTransform.localEulerAngles.x, 0, gunBarrelTransform.localEulerAngles.z - 180);
            cachedRotNeck.Set(neckTransform.localEulerAngles.x, 180, neckTransform.localEulerAngles.z);
        }
        bodyTransform.localEulerAngles = cachedVector3;
        neckTransform.localEulerAngles = cachedRotNeck;

        // if ((gunBarrelTransform.localEulerAngles.z > -90 && gunBarrelTransform.localEulerAngles.z <= 90)
        //     )
        //     bodyTransform.right = gunBarrelTransform.right;
        // else
        // {
        //     bodyTransform.right = gunBarrelTransform.right;
        // }


        if (!isAiming) isAiming = true;
    }

    public override void Death()
    {
        base.Death();
        _ = GameManager.instance.LoseLevel();
    }

    public void RefillBullet() => cachedMaxBullet = maxBullet;

    public IEnumerator CheckLoseByOutOfBullet(float delayLose)
    {
        yield return ExtensionClass.GetWaitForSeconds(delayLose);
    }
}