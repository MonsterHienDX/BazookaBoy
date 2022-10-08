using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AimSystem))]
[RequireComponent(typeof(HumanPhysicComponent))]
[RequireComponent(typeof(AnimationComponent))]

public class Player : MonoBehaviour
{
    [SerializeField] private AimSystem _aimSystem;
    [SerializeField] private HumanPhysicComponent _physicComponent;
    [SerializeField] private AnimationComponent _animationComponent;
    [SerializeField] private Transform gunBarrelTransform;
    [SerializeField] private Transform gunMuzzleTransform;
    [SerializeField] private BulletManager _bulletManager;

    private void Start()
    {
        _aimSystem.Init(this.transform);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0)) Aim(Input.mousePosition);
        if (Input.GetMouseButtonUp(0)) Shoot();
    }

    public void Shoot()
    {
        //  TODO: Get bullet
        BulletBase bullet = _bulletManager.GetBullet();
        bullet.EnableBullet(true);
        bullet.SetInfo(this.gunMuzzleTransform.position);

        //  TODO: Calculate direction and add force
        Vector2 direction = (Vector2)this.gunMuzzleTransform.position - (Vector2)this.transform.position;

        bullet.Fire(direction, 10f);

        //  TODO: FX shoot

        //  TODO: Sound shoot
    }

    private void Aim(Vector2 mousePos)
    {
        gunBarrelTransform.rotation = _aimSystem.GetAimDirection(mousePos);
    }

    private void OnCollide()
    {

    }
}
