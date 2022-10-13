using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scritable objects/Level data")]
public class LevelInfoSO : ScriptableObject
{
    [field: SerializeField] public List<LevelInfo> levelInfos { get; private set; }

    public void AddLevelData(LevelInfo levelInfo) => levelInfos.Add(levelInfo);
}
