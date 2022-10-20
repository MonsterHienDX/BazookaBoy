using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private List<BulletBaseD2D> bulletBaseList;
    [SerializeField] private BulletBaseD2D bulletPrefab;

    private void OnEnable()
    {
        EventDispatcher.Instance.RegisterListener(EventID.ResetDataLevel, HandleEventResetDataLevel);
    }

    private void OnDisable()
    {
        EventDispatcher.Instance.RemoveListener(EventID.ResetDataLevel, HandleEventResetDataLevel);
    }

    private void Awake()
    {
        bulletBaseList = new List<BulletBaseD2D>();
    }

    public BulletBaseD2D GetBullet()
    {
        foreach (BulletBaseD2D bullet in bulletBaseList)
        {
            if (!bullet.isActive) return bullet;
        }

        BulletBaseD2D bulletNew = Instantiate<BulletBaseD2D>(bulletPrefab, this.transform);
        bulletNew.name = $"Bullet {bulletBaseList.Count}";
        bulletNew.Init();
        bulletBaseList.Add(bulletNew);
        return bulletNew;
    }

    private void HandleEventResetDataLevel(object param = null)
    {
        foreach (BulletBaseD2D bullet in bulletBaseList)
        {
            bullet.EnableBullet(false);
        }
    }
}
