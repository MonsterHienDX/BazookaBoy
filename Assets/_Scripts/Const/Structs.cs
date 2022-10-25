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
public struct Object3D
{
    public Mesh mesh;
    public Material material;
}

[System.Serializable]
public struct LevelInfo
{
    public LevelType levelType;
    public GroundInfo groundInfo;
    public MapObjectInfo[] stones;
    public MapObjectInfo[] roundStones;
    public MapObjectInfo[] woods;
    public EnemyInfo[] enemies;
    public Vector2[] bombMapPositions;
    public Vector2 playerPos;
}

[System.Serializable]
public struct GroundInfo
{
    public Vector2 centerPos;
    public Sprite groundSpriteShape;
}

[System.Serializable]
public struct MapObjectInfo
{
    public Vector2 centerPos;
    public Vector2 size;
}

[System.Serializable]
public struct EnemyInfo
{
    public EnemyType type;
    public Vector2 pos;
}

public struct GameObjectTag
{
    public const string DestructibleObjects = "DestructibleObjects";
    public const string Bomb = "Bomb";
    public const string Human = "Human";
    public const string Bullet = "Bullet";
}