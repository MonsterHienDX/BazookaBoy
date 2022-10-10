using System;
using UnityEngine;

[System.Serializable]
public class UserAnalyticParam
{
    public const string fileName = "TrackingParam";
    public UserParam structParam;

    public UserAnalyticParam()
    {
        structParam = new UserParam
        { 
            undoInLevel = 0,
            // skipInLevel = 0,
        };
    }

    public void Save()
    {
        SaveHelper.Save(structParam, fileName);
    }

    public void Load()
    {
        structParam = SaveHelper.Load<UserParam>(fileName);
    }

    [Serializable]
    public struct UserParam
    {
        public int currentLevel;
        public int undoInLevel, skipInLevel;
    }
}