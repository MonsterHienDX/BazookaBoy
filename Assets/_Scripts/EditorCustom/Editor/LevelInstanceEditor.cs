using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR 
using UnityEditor;
#endif


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

        levelInfo.roundStones = levelInstance.roundStoneInfoList.ToArray();

        levelInfo.woods = levelInstance.woodInfoList.ToArray();

        levelInstance.AddLevelData(levelInfo);


        EditorUtility.SetDirty(levelInstance.dataLevel);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
#endif