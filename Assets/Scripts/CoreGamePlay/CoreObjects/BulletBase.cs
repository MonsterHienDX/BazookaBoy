using System.Collections;
using System.Collections.Generic;
using ClipperLib;
using UnityEngine;
using Vector2i = ClipperLib.IntPoint;

[RequireComponent(typeof(BulletPhysicComponent))]
public class BulletBase : MonoBehaviour, IClip
{
    [SerializeField] private float radius;
    [SerializeField] private int segmentCount;
    private Vector2 clipPosition;
    private Vector3 clipPositionVec3;
    [SerializeField] private BulletPhysicComponent _physicComponent;
    public bool isActive { get; private set; }
    [SerializeField] private MeshRenderer _renderer;
    private DestructibleTerrain terrain;


    private void Start()
    {
        Vector2 positionWorldSpace = transform.position;
        clipPosition = positionWorldSpace - terrain.GetPositionOffset();
    }

    private void Update()
    {
        if (!isActive) return;
        clipPosition = (Vector2)this.transform.position - terrain.GetPositionOffset();
        // clipPosition = this.transform.position;
        // clipPositionVec3.Set(clipPosition.x, clipPosition.y, -4.5f);
        // this.transform.position = clipPositionVec3;
        // clipPosition = (Vector2)this.transform.position;
    }

    public bool CheckBlockOverlapping(Vector2 p, float size)
    {
        float dx = Mathf.Abs(clipPosition.x - p.x) - radius - size / 2;
        float dy = Mathf.Abs(clipPosition.y - p.y) - radius - size / 2;

        return dx < 0f && dy < 0f;
    }

    public ClipBounds GetBounds()
    {
        return new ClipBounds
        {
            lowerPoint = new Vector2(clipPosition.x - radius, clipPosition.y - radius),
            upperPoint = new Vector2(clipPosition.x + radius, clipPosition.y + radius)
        };
    }

    public List<Vector2i> GetVertices()
    {
        List<Vector2i> vertices = new List<Vector2i>();
        for (int i = 0; i < segmentCount; i++)
        {
            float angle = Mathf.Deg2Rad * (-90f - 360f / segmentCount * i);

            Vector2 point = new Vector2(clipPosition.x + radius * Mathf.Cos(angle), clipPosition.y + radius * Mathf.Sin(angle));
            Vector2i point_i64 = point.ToVector2i();
            vertices.Add(point_i64);
        }
        return vertices;
    }

    public void EnableBullet(bool enable)
    {
        this._physicComponent.EnablePhysic(enable);
        isActive = enable;
        _renderer.enabled = enable;
    }

    public void Explode()
    {
        //  TODO: push force to all objects around

        //  TODO: Destruct map
        terrain.ExecuteClip(this);

        //  Turn off bullet
        EnableBullet(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            Explode();
        }
    }

    public void Init(DestructibleTerrain terrain)
    {
        this.terrain = terrain;
    }

    public void SetInfo(Vector2 startPos)
    {
        this.clipPosition = startPos - terrain.GetPositionOffset();
        this.transform.position = startPos;
    }

    public void Fire(Vector2 direction, float force)
    {
        this._physicComponent.PushForce(direction, force);
    }

}

