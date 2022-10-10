using System;
using System.Globalization;
using UnityEngine;

[Serializable]
public class GameplayTracking : MonoBehaviour
{
    // [SerializeField] private UserAnalyticParam _userParam;
    // private float _timePlayInLevel, _timeStart;
    // private GameMode _currentMode;

    // private void OnEnable()
    // {
    //     EventDispatcher.Instance.RegisterListener(EventID.Loadlevel, InitParam);
    //     EventDispatcher.Instance.RegisterListener(EventID.WinLevel, LogWin);
    //     EventDispatcher.Instance.RegisterListener(EventID.LoseLevel, LogLose);

    //     EventDispatcher.Instance.RegisterListener(EventID.SkipLevel, LogSkip);
    //     EventDispatcher.Instance.RegisterListener(EventID.UseUndo, UseUndo);
    //     EventDispatcher.Instance.RegisterListener(EventID.ReplayLevel, LogReplay);
    // }

    // private void OnDisable()
    // {
    //     EventDispatcher.Instance.RemoveListener(EventID.Loadlevel, InitParam);
    //     EventDispatcher.Instance.RemoveListener(EventID.WinLevel, LogWin);
    //     EventDispatcher.Instance.RemoveListener(EventID.LoseLevel, LogLose);
    //     EventDispatcher.Instance.RemoveListener(EventID.SkipLevel, LogSkip);
    //     EventDispatcher.Instance.RemoveListener(EventID.UseUndo, UseUndo);
    //     EventDispatcher.Instance.RemoveListener(EventID.ReplayLevel, LogReplay);
    // }

    // // private void EndLevel(object param = null)
    // // {
    // //     bool win = (bool)param;
    // //     if (win)
    // //     {
    // //         LogWin(null);
    // //     }
    // //     else
    // //     {
    // //         LogLose(null);
    // //     }
    // // }

    // private void UseUndo(object param)
    // {
    //     // int undo = (int)param;
    //     GameAnalytics.LogUseUndoButton(GameManager.instance.currentLevel, GameManager.instance.currentMode);
    //     _userParam.structParam.undoInLevel++;
    //     SetUserParam();
    // }

    // private void SetUserParam()
    // {
    //     // RecalculateTimePlay();
    //     _userParam.Save();
    // }

    // private void RecalculateTimePlay()
    // {
    //     // float timeTotal = Time.realtimeSinceStartup + timeBuffer - timePlay;
    //     // _userParam.structParam.timePlay = timeTotal;
    // }

    // private void LogSkip(object obj)
    // {
    //     SetUserParam();
    //     _timePlayInLevel = Time.realtimeSinceStartup - _timeStart;
    //     GameAnalytics.LogGamePlayData(GameManager.instance.currentLevel, GAMEPLAY_STATE.SKIP, _userParam,
    //         _timePlayInLevel.ToString("0.0000"), _currentMode);
    // }

    // private void LogLose(object obj = null)
    // {
    //     SetUserParam();
    //     _timePlayInLevel = Time.realtimeSinceStartup - _timeStart;
    //     GameAnalytics.LogGamePlayData(GameManager.instance.currentLevel, GAMEPLAY_STATE.LOSE, _userParam,
    //         _timePlayInLevel.ToString("0.0000"), _currentMode);
    // }

    // private void LogWin(object obj = null)
    // {
    //     SetUserParam();
    //     _timePlayInLevel = Time.realtimeSinceStartup - _timeStart;
    //     GameAnalytics.LogGamePlayData(GameManager.instance.currentLevel, GAMEPLAY_STATE.WIN, _userParam,
    //         _timePlayInLevel.ToString("0.0000"), _currentMode);
    //     if (_currentMode == GameMode.SortMode)
    //     {
    //         GameAnalytics.LogStepPlaySortMode(GameManager.instance.currentLevel, SortModeManager.instance.userStepUsed);
    //     }
    // }

    // private void LogReplay(object obj = null)
    // {
    //     SetUserParam();
    //     _timePlayInLevel = Time.realtimeSinceStartup - _timeStart;
    //     GameAnalytics.LogUseReplayButton(GameManager.instance.currentLevel, _currentMode);
    //     GameAnalytics.LogGamePlayData(GameManager.instance.currentLevel, GAMEPLAY_STATE.REPLAY, _userParam,
    //         _timePlayInLevel.ToString("0.0000"), _currentMode);
    // }

    // private void InitParam(object param = null)
    // {
    //     _userParam = new UserAnalyticParam();
    //     Debug.Log($"load user tracking load level");

    //     _userParam.structParam.currentLevel = UserData.LevelNumber;
    //     _timeStart = Time.realtimeSinceStartup;

    //     _currentMode = GameManager.instance.currentMode;

    //     GameAnalytics.LogGamePlayData(GameManager.instance.currentLevel, GAMEPLAY_STATE.START_LEVEL, _userParam,
    //         _timeStart.ToString("0.0000"), _currentMode);

    //     SetUserParam();
    // }
}