using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scritable objects/Level data")]
public class LevelInfoSO : ScriptableObject
{
    [field: SerializeField] public LevelInfo[] levelInfos { get; private set; }
}
