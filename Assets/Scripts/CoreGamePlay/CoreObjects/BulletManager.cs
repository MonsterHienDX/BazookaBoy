using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private List<BulletBase> bulletBaseList;
    [SerializeField] private BulletBase bulletPrefab;

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

        BulletBase bulletNew = Instantiate<BulletBase>(bulletPrefab);
        return null;
    }
}
