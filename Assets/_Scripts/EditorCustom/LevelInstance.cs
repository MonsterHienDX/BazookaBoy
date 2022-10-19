using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelInstance : MonoBehaviour
{
    [SerializeField] private LevelInfoSO dataLevel;
    [field: SerializeField] public Vector3 playerPos { get; private set; }
    [field: SerializeField] public LevelType levelType { get; private set; }
    public MapObjectInfo groundInfo;
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
        var cacheGround = Instantiate<Ground>(groundPrefab, groundContainer);
        var cacheWood = Instantiate<Wood>(woodPrefab, woodContainer);
        var cacheStone = Instantiate<Stone>(stonePrefab, stoneContainer);
        var cacheRoundStone = Instantiate<RoundStone>(roundStonePrefab, roundStoneContainer);
        var cacheEnemy = Instantiate<Enemy>(enemyPrefab, enemyContainer);
    }

    public void AddLevelData(LevelInfo levelInfo)
    {
        dataLevel.AddLevelData(levelInfo);

        EditorUtility.SetDirty(dataLevel);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
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

        Vector2 cacheVector2 = Vector2.zero;
        this.groundInfo.centerPos = groundContainer.transform.localPosition;
        cacheVector2.Set(groundContainer.childCount, 1);
        this.groundInfo.size = cacheVector2;

        EnemyInfo cacheEnemyInfo = new EnemyInfo();
        foreach (Enemy enemy in enemyContainer.GetComponentsInChildren<Enemy>())
        {
            cacheEnemyInfo.type = enemy.type;
            cacheEnemyInfo.pos = enemy.transform.localPosition;
            if (!enemyInfoList.Contains(cacheEnemyInfo)) enemyInfoList.Add(cacheEnemyInfo);
        }

        MapObjectInfo cacheWoodInfo = new MapObjectInfo();
        foreach (Wood wood in woodContainer.GetComponentsInChildren<Wood>())
        {
            cacheWoodInfo.centerPos = wood.transform.localPosition;
            cacheWoodInfo.size = wood.GetSizeSquare();
            if (!woodInfoList.Contains(cacheWoodInfo)) woodInfoList.Add(cacheWoodInfo);
        }

        MapObjectInfo cacheStoneInfo = new MapObjectInfo();
        foreach (Stone stone in stoneContainer.GetComponentsInChildren<Stone>())
        {
            cacheStoneInfo.centerPos = stone.transform.localPosition;
            cacheStoneInfo.size = stone.GetSizeSquare();
            if (!stoneInfoList.Contains(cacheStoneInfo)) stoneInfoList.Add(cacheStoneInfo);
        }

        MapObjectInfo cacheRoundStoneInfo = new MapObjectInfo();
        foreach (RoundStone roundStone in roundStoneContainer.GetComponentsInChildren<RoundStone>())
        {
            cacheRoundStoneInfo.centerPos = roundStone.transform.localPosition;
            cacheRoundStoneInfo.size = roundStone.GetSizeSquare();
            if (!roundStoneInfoList.Contains(cacheRoundStoneInfo)) roundStoneInfoList.Add(cacheRoundStoneInfo);
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(LevelInstance))]
public class LevelInstanceEditor : Editor
{
    LevelInstance levelInstance;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        levelInstance = (LevelInstance)target;

        if (GUILayout.Button("Spawn objects"))
        {
            levelInstance.InitCacheObjects();
        }

        if (GUILayout.Button("Update data level to cache"))
        {
            levelInstance.UpdateObjectsDataToCache();
        }

        if (GUILayout.Button("Save data level"))
        {
            SaveLevelData();
        }

        if (GUILayout.Button("Clear objects"))
        {
            levelInstance.ClearCacheObjects();
        }

    }

    private void SaveLevelData()
    {
        LevelInfo levelInfo = new LevelInfo();

        levelInfo.enemies = levelInstance.enemyInfoList.ToArray();

        levelInfo.playerPos = levelInstance.playerPos;

        levelInfo.groundInfo = levelInstance.groundInfo;

        levelInfo.levelType = levelInstance.levelType;

        levelInfo.stones = levelInstance.stoneInfoList.ToArray();

        levelInfo.woods = levelInstance.woodInfoList.ToArray();

        levelInstance.AddLevelData(levelInfo);
    }


}
#endif