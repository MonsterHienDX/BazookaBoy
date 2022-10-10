using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private List<BulletBase> bulletBaseList;
    [SerializeField] private BulletBase bulletPrefab;
    [SerializeField] private DestructibleTerrain terrain;

    private void Awake()
    {
        bulletBaseList = new List<BulletBase>();
    }

    public BulletBase GetBullet()
    {
        foreach (BulletBase bullet in bulletBaseList)
        {
            if (!bullet.isActive) return bullet;
        }

        BulletBase bulletNew = Instantiate<BulletBase>(bulletPrefab, this.transform);
        bulletNew.Init(terrain);
        bulletBaseList.Add(bulletNew);
        return bulletNew;
    }
}
