using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObjectManager : MonoBehaviour
{
    private List<Ground> groundList;
    private List<Wood> woodList;
    private List<Stone> stoneList;
    private List<RoundStone> roundStoneList;
    private List<BombMap> bombMapList;
    [SerializeField] private Sprite _surfaceSprite;
    [SerializeField] private Sprite _solidSoilSprite;
    [SerializeField] private Ground groundPrefab;
    [SerializeField] private Wood woodPrefab;
    [SerializeField] private Stone stonePrefab;
    [SerializeField] private RoundStone roundStonePrefab;
    [SerializeField] private BombMap bombMapPrefab;
    [SerializeField] private Transform groundContainer;
    [SerializeField] private Transform woodContainer;
    [SerializeField] private Transform stoneContainer;
    [SerializeField] private Transform roundStoneContainer;
    [SerializeField] private Transform bombMapContainer;
    private Vector3 groundCenterPos;

    private void Awake()
    {
        groundList = new List<Ground>();
        woodList = new List<Wood>();
        stoneList = new List<Stone>();
        roundStoneList = new List<RoundStone>();
        bombMapList = new List<BombMap>();
    }

    public void LoadObjectsInMap(LevelInfo levelInfo)
    {
        this.groundCenterPos = levelInfo.groundInfo.centerPos;

        Debug.Log("groundCenterPos when load map: " + groundCenterPos);
        SpawnGround(levelInfo.groundInfo);
        SpawnWoods(levelInfo.woods);
        SpawnStones(levelInfo.stones);
        SpawnRoundStones(levelInfo.roundStones);
        SpawnBombMaps(levelInfo.bombMapPositions);
    }

    public void SpawnGround(GroundInfo groundInfo)
    {
        GetGround(groundInfo.centerPos, groundInfo.groundSpriteShape);
        // GetGroundWithOutPool(groundInfo.centerPos, groundInfo.groundSpriteShape);
    }

    private void SpawnWood(MapObjectInfo woodInfo)
    {
        Wood wood = GetWood(woodInfo.centerPos);
        wood.SetSize(woodInfo.size);
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
                ground.SetShape(sprite);
                ground.Init(pos, Vector3.zero);
                return ground;
            }
        }

        Ground groundNew = Instantiate<Ground>(groundPrefab, this.groundContainer);
        groundNew.Init(pos, Vector3.zero);
        groundNew.Enable(true);
        groundNew.SetShape(sprite);

        groundList.Add(groundNew);

        return groundNew;
    }

    // private T GetObject<T>(List<T> tList, Vector3 pos)
    // {
    //     foreach (T t in tList)
    //     {
    //         if (t.)
    //     }
    //     return t;
    // }

    private Wood GetWood(Vector3 pos)
    {
        foreach (Wood wood in woodList)
        {
            if (!wood.isActive)
            {
                wood.Enable(true);
                wood.SetPosition(pos);
                wood.Reset();
                return wood;
            }
        }
        Wood woodNew = Instantiate<Wood>(woodPrefab, this.woodContainer);
        woodNew.Enable(true);
        woodNew.Init(pos, groundCenterPos);
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
                stone.SetPosition(pos);
                stone.Reset();
                return stone;
            }
        }

        Stone stoneNew = Instantiate<Stone>(stonePrefab, this.stoneContainer);
        stoneNew.Enable(true);
        stoneNew.Init(pos, groundCenterPos);
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
                roundStone.SetPosition(pos);
                roundStone.Reset();
                return roundStone;
            }
        }

        RoundStone roundStoneNew = Instantiate<RoundStone>(roundStonePrefab, this.roundStoneContainer);
        roundStoneNew.Enable(true);
        roundStoneNew.Init(pos, groundCenterPos);
        roundStoneList.Add(roundStoneNew);

        return roundStoneNew;
    }

    private void SpawnRoundStone(MapObjectInfo roundStoneInfo)
    {
        RoundStone roundStone = GetRoundStone(roundStoneInfo.centerPos);
        roundStone.SetSize(roundStoneInfo.size);
    }

    public void SpawnRoundStones(MapObjectInfo[] roundStoneInfos)
    {
        foreach (MapObjectInfo roundStoneInfo in roundStoneInfos)
        {
            SpawnRoundStone(roundStoneInfo);
        }
    }

    private BombMap GetBombMap(Vector3 pos)
    {
        foreach (BombMap bombMap in bombMapList)
        {
            if (!bombMap.isActive)
            {
                bombMap.Enable(true);
                bombMap.SetPosition(pos);
                bombMap.Reset();
                return bombMap;
            }
        }

        BombMap bombMapNew = Instantiate<BombMap>(bombMapPrefab, this.bombMapContainer);
        bombMapNew.Enable(true);
        bombMapNew.Init(pos);
        bombMapList.Add(bombMapNew);

        return bombMapNew;
    }

    private void SpawnBombMap(Vector3 pos)
    {
        BombMap bombMap = GetBombMap(pos);
    }

    private void SpawnBombMaps(Vector2[] positions)
    {
        foreach (Vector2 pos in positions)
        {
            SpawnBombMap(pos);
        }
    }
}
