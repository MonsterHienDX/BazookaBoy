using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObjectManager : MonoBehaviour
{
    private List<Ground> groundList;
    private List<Wood> woodList;
    private List<Stone> stoneList;
    [SerializeField] private Sprite _surfaceSprite;
    [SerializeField] private Sprite _solidSoilSprite;
    [SerializeField] private Ground groundPrefab;
    [SerializeField] private Wood woodPrefab;
    [SerializeField] private Stone stonePrefab;
    [SerializeField] private Transform groundContainer;
    [SerializeField] private Transform woodContainer;
    [SerializeField] private Transform stoneContainer;

    private void Awake()
    {
        groundList = new List<Ground>();
        woodList = new List<Wood>();
        stoneList = new List<Stone>();
    }

    public void SpawnGround(MapObjectInfo groundInfo)
    {
        Vector3 cachedPos = Vector3.zero;
        Sprite cachedSprite = _surfaceSprite;
        for (int y = 0; y < groundInfo.size.y; y++)
        {
            for (int x = 0; x < groundInfo.size.x; x++)
            {
                cachedPos.Set((x - groundInfo.size.x / 2) * 1.28f * 4f, y * 1.28f * 4f, 0);
                cachedSprite = (y < groundInfo.size.y - 1) ? _solidSoilSprite : _surfaceSprite;
                groundList.Add(GetGround(cachedPos, cachedSprite));
            }
        }
        groundContainer.transform.position = groundInfo.centerPos;
    }

    private void SpawnWood(MapObjectInfo woodInfo)
    {
        Debug.Log("SpawnWood at: " + woodInfo.centerPos);
        Vector3 cachedPos = Vector3.zero;
        Wood stone = GetWood(cachedPos);

        stone.SetSize(woodInfo.size);
        stone.SetPosition(woodInfo.centerPos);
    }

    public void SpawnWoods(MapObjectInfo[] woodInfos)
    {
        foreach (MapObjectInfo woodInfo in woodInfos)
        {
            SpawnWood(woodInfo);
        }
    }

    private void SpawnStone(MapObjectInfo stoneInfo)
    {
        Vector3 cachedPos = Vector3.zero;
        Stone stone = GetStone(cachedPos);

        stone.SetSize(stoneInfo.size);
        stone.SetPosition(stoneInfo.centerPos);

        // cachedPos.Set((x - stoneInfo.size.x / 2) * 1.28f, y * 1.28f, 0);
    }

    public void SpawnStones(MapObjectInfo[] stoneInfos)
    {
        foreach (MapObjectInfo stoneInfo in stoneInfos)
        {
            SpawnStone(stoneInfo);
        }
    }

    private Ground GetGround(Vector3 pos, Sprite sprite)
    {
        // foreach (Ground ground in groundList)
        // {
        //     if (!ground.isActive)
        //     {
        //         ground.Enable(true);
        //         ground.SetSprite(sprite);
        //         ground.transform.localPosition = pos;
        //         ground.Reset();
        //         return ground;
        //     }
        // }

        Ground groundNew = Instantiate<Ground>(groundPrefab, this.groundContainer);
        groundNew.name = "Ground";
        groundNew.tag = "DestructibleObjects";
        groundNew.transform.localPosition = pos;
        groundNew.SetSprite(sprite);
        groundList.Add(groundNew);

        return groundNew;
    }

    private Wood GetWood(Vector3 pos)
    {
        // foreach (Wood wood in woodList)
        // {
        //     if (!wood.isActive)
        //     {
        //         wood.Enable(true);
        //         wood.Reset();
        //         return wood;
        //     }
        // }

        Wood woodNew = Instantiate<Wood>(woodPrefab, this.woodContainer);
        woodNew.name = "Wood";
        woodNew.tag = "DestructibleObjects";
        woodNew.transform.localPosition = pos;
        // woodNew.OptimizeWhenInit();
        woodList.Add(woodNew);

        return woodNew;
    }

    private Stone GetStone(Vector3 pos)
    {
        // foreach (Stone stone in stoneList)
        // {
        //     if (!stone.isActive)
        //     {
        //         stone.Enable(true);
        //         return stone;
        //     }
        // }

        Stone stoneNew = Instantiate<Stone>(stonePrefab, this.stoneContainer);
        stoneNew.name = "Stone";
        stoneNew.tag = "DestructibleObjects";
        stoneNew.transform.localPosition = pos;
        stoneList.Add(stoneNew);

        return stoneNew;
    }
}