using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelInstance : MonoBehaviour
{
    [field: SerializeField] public LevelInfoSO dataLevel { get; private set; }
    [field: SerializeField] public Vector3 playerPos { get; private set; }
    [field: SerializeField] public LevelType levelType { get; private set; }
    public GroundInfo groundInfo;
    public Ground ground;
    public List<MapObjectInfo> woodInfoList;
    public List<MapObjectInfo> stoneInfoList;
    public List<MapObjectInfo> roundStoneInfoList;
    public List<EnemyInfo> enemyInfoList;
    [SerializeField] private Ground groundPrefab;
    [SerializeField] private Wood woodPrefab;
    [SerializeField] private Stone stonePrefab;
    [SerializeField] private RoundStone roundStonePrefab;
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Sprite _surfaceSprite;
    [SerializeField] private Sprite _solidSoilSprite;
    [SerializeField] private Transform groundContainer;
    [SerializeField] private Transform woodContainer;
    [SerializeField] private Transform stoneContainer;
    [SerializeField] private Transform roundStoneContainer;
    [SerializeField] private Transform enemyContainer;

    [SerializeField] private Player player;

    private void Awake()
    {
        this.gameObject.SetActive(false);
    }

    public void InitCacheObjects()
    {
        ground = Instantiate<Ground>(groundPrefab, groundContainer);
        var cacheWood = Instantiate<Wood>(woodPrefab, woodContainer);
        var cacheStone = Instantiate<Stone>(stonePrefab, stoneContainer);
        var cacheRoundStone = Instantiate<RoundStone>(roundStonePrefab, roundStoneContainer);
        var cacheEnemy = Instantiate<Enemy>(enemyPrefab, enemyContainer);
    }

    public void AddLevelData(LevelInfo levelInfo)
    {
        dataLevel.AddLevelData(levelInfo);
    }

    public void ClearCacheObjects()
    {
        while (groundContainer.childCount > 0) DestroyImmediate(groundContainer.GetChild(0).gameObject);
        while (woodContainer.childCount > 0) DestroyImmediate(woodContainer.GetChild(0).gameObject);
        while (stoneContainer.childCount > 0) DestroyImmediate(stoneContainer.GetChild(0).gameObject);
        while (enemyContainer.childCount > 0) DestroyImmediate(enemyContainer.GetChild(0).gameObject);
        while (roundStoneContainer.childCount > 0) DestroyImmediate(roundStoneContainer.GetChild(0).gameObject);

        woodInfoList.Clear();
        stoneInfoList.Clear();
        enemyInfoList.Clear();
        roundStoneInfoList.Clear();

        groundContainer.transform.position = Vector3.zero;
    }

    public void UpdateObjectsDataToCache()
    {
        this.playerPos = player.transform.position;

        woodInfoList.Clear();
        stoneInfoList.Clear();
        enemyInfoList.Clear();
        roundStoneInfoList.Clear();

        this.groundInfo.groundSpriteShape = ground.spriteShape;
        this.groundInfo.centerPos = ground.transform.position;

        EnemyInfo cacheEnemyInfo = new EnemyInfo();
        foreach (Enemy enemy in enemyContainer.GetComponentsInChildren<Enemy>())
        {
            cacheEnemyInfo.type = enemy.type;
            cacheEnemyInfo.pos = enemy.transform.localPosition;
            if (!enemyInfoList.Contains(cacheEnemyInfo)) enemyInfoList.Add(cacheEnemyInfo);
        }

        MapObjectInfo cacheMapObjectInfo = new MapObjectInfo();
        foreach (Wood wood in woodContainer.GetComponentsInChildren<Wood>())
        {
            cacheMapObjectInfo.centerPos = wood.transform.localPosition;
            cacheMapObjectInfo.size = wood.GetSizeSquare();
            if (!woodInfoList.Contains(cacheMapObjectInfo)) woodInfoList.Add(cacheMapObjectInfo);
        }

        foreach (Stone stone in stoneContainer.GetComponentsInChildren<Stone>())
        {
            cacheMapObjectInfo.centerPos = stone.transform.localPosition;
            cacheMapObjectInfo.size = stone.GetSizeSquare();
            if (!stoneInfoList.Contains(cacheMapObjectInfo)) stoneInfoList.Add(cacheMapObjectInfo);
        }

        foreach (RoundStone roundStone in roundStoneContainer.GetComponentsInChildren<RoundStone>())
        {
            cacheMapObjectInfo.centerPos = roundStone.transform.localPosition;
            cacheMapObjectInfo.size = roundStone.GetSizeSquare();
            if (!roundStoneInfoList.Contains(cacheMapObjectInfo)) roundStoneInfoList.Add(cacheMapObjectInfo);
        }
    }
}
