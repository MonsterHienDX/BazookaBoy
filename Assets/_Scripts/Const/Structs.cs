using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SoundInfo
{
    public SoundName soundName;
    public AudioClip sound;
    [Range(0f, 1f)] public float volume;
}

[System.Serializable]
public struct MapInfo
{
    public MapSize size;
    public Transform parkPlanePivot;
}

[System.Serializable]
public struct CamInfo
{
    public Vector3 mainCamPos;
    public Vector3 mainCamRot;
}

[System.Serializable]
public struct TrailInfo
{
    public TrailType trailType;
    public string trailName;
    public Sprite sprite;
    public Transform smoke;
    public Transform trail;
}

[System.Serializable]
public struct Object3D
{
    public Mesh mesh;
    public Material material;
}

[System.Serializable]
public struct HiddenGiftInfo
{
    public RewardType rewardType;
    public string giftName;
    public Sprite sprite;
    public Mesh mesh;
}

[System.Serializable]
public struct CarSortModeInfo
{
    public CarColor color;
    public Object3D skin;
}

[System.Serializable]
public struct LevelSortModeInfo
{
    public int levelNumber;
    public int columnAmount;
    public int maxCarPerColumnAmount;
    public List<int> colorIntDataList;
    public int colorAmount;
    public int standartStep;
}

[System.Serializable]
public struct LevelHardModeInfo
{
    public int levelNumber;
    public int slotAmount;
    public int barrierAmount;
    public int verticalSlotAmount;
    public int horizontalSlotAmount;
    public int playTime;
    public int hard;
}

[System.Serializable]
public struct LevelModeRequireInfo
{
    public int levelNumber;
    public int levelNumberRequire;
    public int spend;
    public int earn;
}

[System.Serializable]
public struct LevelModeUserProgressState
{
    public int levelNumber;
    public int starReachedAmount;
    public ModeLevelButtonState state;
}

[System.Serializable]
public struct LevelModeBGColor
{
    public ModeLevelButtonState state;
    public Color color;
}