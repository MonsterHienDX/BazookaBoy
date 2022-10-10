using System.Collections;
using System.Collections.Generic;
using Destructible2D;
using Destructible2D.Examples;
using UnityEngine;

[RequireComponent(typeof(BulletPhysicComponent))]
public class BulletBaseD2D : MonoBehaviour
{
    [SerializeField] private BulletPhysicComponent _physicComponent;
    public bool isActive { get; private set; }
    [SerializeField] private MeshRenderer _renderer;
    private IEnumerator explodeWithDelayCO;
    [SerializeField] private D2dExplosion explosion;
    private Vector3 posVec3;

    public void EnableBullet(bool enable)
    {
        this._physicComponent.EnablePhysic(enable);
        isActive = enable;
        _renderer.enabled = enable;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            D2dStamp.All(D2dDestructible.PaintType.Cut, this.transform.position, Vector2.one * 2, 90f, Texture2D.blackTexture, Color.blue);
    }

    public void Explode(Vector2 position)
    {
        //  TODO: push force to all objects around

        //  TODO: Destruct map
        // D2dExplosion explosion = Instantiate<D2dExplosion>(explosionPrefab, this.transform.position, Quaternion.identity, this.transform);
        explosion.Explode(position);


        //  Turn off bullet
        EnableBullet(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            Explode(collision.GetContact(0).point);
        }
    }

    public void Init()
    {
    }

    public void SetInfo(Vector2 startPos)
    {
        posVec3.Set(startPos.x, startPos.y, 0);
        this.transform.position = posVec3;
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
        Explode(this.transform.position);
    }
}
