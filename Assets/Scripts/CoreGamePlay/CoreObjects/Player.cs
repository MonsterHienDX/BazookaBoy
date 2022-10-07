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
    [SerializeField] private BulletManager _bulletManager;

    private void Start()
    {
        _aimSystem.Init(this.transform);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0)) Aim(Input.mousePosition);
    }

    public void Shoot()
    {
        //  TODO: Get bullet

        //  TODO: Add force

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
