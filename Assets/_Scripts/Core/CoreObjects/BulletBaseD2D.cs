using System.Collections;
using System.Collections.Generic;
using Destructible2D;
using Destructible2D.Examples;
using UnityEngine;

[RequireComponent(typeof(BulletPhysicComponent))]
[RequireComponent(typeof(BulletFXComponent))]
public class BulletBaseD2D : MonoBehaviour
{
    [SerializeField] private BulletPhysicComponent _physicComponent;
    [SerializeField] private BulletFXComponent _fxComponent;
    public bool isActive { get; private set; }
    [SerializeField] private MeshRenderer _renderer;
    private IEnumerator explodeWithDelayCO;
    [SerializeField] private D2dExplosion explosion;
    private Vector3 posVec3;
    private bool hasExploded;

    private void OnValidate()
    {
        _fxComponent.UpdateFXSize(explosion.StampSize);
    }

    public void EnableBullet(bool enable)
    {
        this._physicComponent.EnablePhysic(enable);
        isActive = enable;
        _renderer.enabled = enable;
        hasExploded = !enable;
        _fxComponent.KillFX();
    }

    public void Explode(Vector2 position)
    {
        //  TODO: push force to all objects around


        //  TODO: Destruct map
        explosion.Explode(position);
        hasExploded = true;

        //  Turn off bullet
        EnableBullet(false);

        //  TODO: Play FX Explode
        _fxComponent.PlayExplodeFX();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("DestructibleObjects"))
        {
            HandleCollideWithGround(collision);
        }

        if (collision.gameObject.tag.Equals("Human"))
        {
            HandleCollideWithHuman(collision);
        }
    }

    public void Init()
    {
    }

    public void SetInfo(Vector2 startPos, Vector3 startRot)
    {
        posVec3.Set(startPos.x, startPos.y, 0);
        this.transform.position = posVec3;
        this.transform.localEulerAngles = startRot;
    }

    public void Fire(Vector2 direction, float force)
    {
        this._physicComponent.PushForce(direction, force);

        if (explodeWithDelayCO != null) StopCoroutine(explodeWithDelayCO);
        explodeWithDelayCO = ExplodeWithDelay(5f);
        StartCoroutine(explodeWithDelayCO);
    }

    private IEnumerator ExplodeWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (!hasExploded) Explode(this.transform.position);
    }

    private void HandleCollideWithHuman(Collision2D collision)
    {
        Explode(collision.GetContact(0).point);
        Human enemy = collision.gameObject.GetComponent<Human>();
        enemy.GetBulletAffect(this.transform.position, this.explosion.StampSize.x, this.explosion.ForcePerRay);
        enemy.Death();
    }

    private void HandleCollideWithGround(Collision2D collision)
    {
        Explode(collision.GetContact(0).point);
    }
}
