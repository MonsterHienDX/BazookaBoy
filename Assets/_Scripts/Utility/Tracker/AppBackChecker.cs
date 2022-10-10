using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public enum AppBackgroundState
{
    None,
    AdsShowing,
    IAP,
}

public class AppBackChecker : MonoBehaviour
{
    // //     [SerializeField] private bool hasInterInGame, hasInterAppBack;
    // //     public static AppBackgroundState State = AppBackgroundState.None;
    // //     private float _timeCheckOut, _timeCheckIn;
    // //     private float _timeCounter;
    // //     private IEnumerator _inGameCounter;
    // //     [SerializeField] private AudienceAdsManager _audienceAdsManager;
    // //     private float timeInterval;

    // //     private void OnEnable()
    // //     {
    // //         if (!hasInterInGame) return;
    // //         EventDispatcher.Instance.RegisterListener(EventID.Loadlevel, InGameInterCounter);

    // // #if UNITY_EDITOR
    // //         timeInterval = 25f;
    // // #else
    // //         timeInterval = AudienceAdsManager.Instance.timeIntervalInGame;
    // // #endif
    // //     }

    // //     private void OnDisable()
    // //     {
    // //         if (!hasInterInGame) return;
    // //         EventDispatcher.Instance.RemoveListener(EventID.Loadlevel, InGameInterCounter);
    // //     }

    // //     private void OnApplicationPause(bool appPause)
    // //     {
    // //         if (!hasInterAppBack) return;
    // //         Debug.Log($"On app pause {appPause}");
    // //         if (appPause)
    // //         {
    // //             _timeCheckOut = Time.realtimeSinceStartup;
    // //             _timeCheckIn = 0f;
    // //             Debug.Log($"app pause {_timeCheckOut} - {_timeCheckIn}");
    // //         }
    // //         else
    // //         {
    // //             if (State != AppBackgroundState.None)
    // //             {
    // //                 async void TurnOffAdsShowing()
    // //                 {
    // //                     await Task.Delay(5000);
    // //                     AppBackChecker.State = AppBackgroundState.None;
    // //                     Debug.Log($"Change state DONE to {State}");
    //                 }

    //                 TurnOffAdsShowing();
    //                 InGameInterCounter();
    //                 return;
    //             }


    //             _timeCheckIn = Time.realtimeSinceStartup;
    //             CheckTime();
    //         }
    //     }

    //     private void CheckTime()
    //     {
    //         Debug.Log($"app resume {_timeCheckIn - _timeCheckOut}");
    //         if (_timeCheckIn - _timeCheckOut < AudienceAdsManager.Instance.timeInterval)
    //         {
    //             return;
    //         }

    //         if (_inGameCounter != null)
    //         {
    //             StopCoroutine(_inGameCounter);
    //             _inGameCounter = null;
    //         }

    //         Time.timeScale = 0;
    //         AdsController.Instances.ShowInterstitial(() => { Time.timeScale = 1; },
    //             InterstitialPositionType.AppBack);
    //         StartCoroutine(ResetInterInGame());
    //     }

    //     IEnumerator ResetInterInGame()
    //     {
    //         yield return ExtensionClass.GetWaitForSeconds(15f);
    //         InGameInterCounter();
    //     }

    //     private void InGameInterCounter(object param = null)
    //     {
    //         if (!hasInterInGame) return;
    //         if (_inGameCounter != null)
    //         {
    //             StopCoroutine(_inGameCounter);
    //         }

    //         _inGameCounter = StartInGameCounter();
    //         StartCoroutine(_inGameCounter);
    //     }


    //     private IEnumerator StartInGameCounter()
    //     {
    //         _timeCounter = 0f;

    //         while (_timeCounter < timeInterval)
    //         {
    //             yield return ExtensionClass.GetWaitForSeconds(1);
    //             _timeCounter += 1;
    //         }

    //         // Debug.LogWarning($"Inter In game {_timeCounter}");
    //         if (_timeCounter >= timeInterval && _timeCounter > 0f)
    //         {
    //             // Debug.Log($"time {_timeCounter} - {timeInterval}");
    //             // AdsController.Instances.ShowInterstitial(() =>
    //             // {
    //             //     StopCoroutine(_inGameCounter);
    //             //     _inGameCounter = null;
    //             //     InGameInterCounter();
    //             // }, InterstitialPositionType.InGame);
    //         }
    //     }
}
