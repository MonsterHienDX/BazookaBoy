using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObjectManager : MonoBehaviour
{
    private List<Ground> groundList;
    private List<Wood> woodList;
    private List<Stone> stoneList;
    private List<RoundStone> roundStoneList;
    [SerializeField] private Sprite _surfaceSprite;
    [SerializeField] private Sprite _solidSoilSprite;
    [SerializeField] private Ground groundPrefab;
    [SerializeField] private Wood woodPrefab;
    [SerializeField] private Stone stonePrefab;
    [SerializeField] private RoundStone roundStonePrefab;
    [SerializeField] private Transform groundContainer;
    [SerializeField] private Transform woodContainer;
    [SerializeField] private Transform stoneContainer;
    [SerializeField] private Transform roundStoneContainer;


    private void Awake()
    {
        groundList = new List<Ground>();
        woodList = new List<Wood>();
        stoneList = new List<Stone>();
        roundStoneList = new List<RoundStone>();
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
        Wood wood = GetWood(woodInfo.centerPos);
        wood.SetSize(woodInfo.size);
        wood.SetPosition(woodInfo.centerPos);
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
        Stone stone = GetStone(stoneInfo.centerPos);
        stone.SetSize(stoneInfo.size);
        stone.SetPosition(stoneInfo.centerPos);
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
        foreach (Ground ground in groundList)
        {
            if (!ground.isActive)
            {
                ground.Enable(true);
                ground.SetSprite(sprite);
                ground.Init(pos);
                return ground;
            }
        }

        Ground groundNew = Instantiate<Ground>(groundPrefab, this.groundContainer);
        groundNew.Init(pos);
        groundNew.Enable(true);

        groundNew.SetSprite(sprite);

        groundList.Add(groundNew);

        return groundNew;
    }

    private Wood GetWood(Vector3 pos)
    {
        foreach (Wood wood in woodList)
        {
            if (!wood.isActive)
            {
                wood.Enable(true);
                wood.Reset();
                return wood;
            }
        }
        Wood woodNew = Instantiate<Wood>(woodPrefab, this.woodContainer);
        woodNew.Enable(true);
        woodNew.Init(pos);
        woodList.Add(woodNew);

        return woodNew;
    }

    private Stone GetStone(Vector3 pos)
    {
        foreach (Stone stone in stoneList)
        {
            if (!stone.isActive)
            {
                stone.Enable(true);
                stone.Reset();
                return stone;
            }
        }

        Stone stoneNew = Instantiate<Stone>(stonePrefab, this.stoneContainer);
        stoneNew.Enable(true);
        stoneNew.Init(pos);
        stoneList.Add(stoneNew);

        return stoneNew;
    }

    private RoundStone GetRoundStone(Vector3 pos)
    {
        foreach (RoundStone roundStone in roundStoneList)
        {
            if (!roundStone.isActive)
            {
                roundStone.Enable(true);
                roundStone.Reset();
                return roundStone;
            }
        }

        RoundStone roundStoneNew = Instantiate<RoundStone>(roundStonePrefab, this.roundStoneContainer);
        roundStoneNew.Enable(true);
        roundStoneNew.Init(pos);
        roundStoneList.Add(roundStoneNew);

        return roundStoneNew;
    }

    private void SpawnRoundStone(MapObjectInfo roundStoneInfo)
    {
        RoundStone roundStone = GetRoundStone(roundStoneInfo.centerPos);
        roundStone.SetSize(roundStoneInfo.size);
        roundStone.SetPosition(roundStoneInfo.centerPos);
    }

    public void SpawnRoundStones(MapObjectInfo[] roundStoneInfos)
    {
        foreach (MapObjectInfo roundStoneInfo in roundStoneInfos)
        {
            SpawnRoundStone(roundStoneInfo);
        }
    }
}