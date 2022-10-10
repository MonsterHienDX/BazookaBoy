using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using DG.Tweening;
using System.Threading.Tasks;

public class InternetConnectionChecking : PopupBase
{
    [SerializeField] private Button closeButton;
    [SerializeField] private Transform errorTextTransform;
    private bool _connected;
    public bool connected => _connected;
    private Sequence fxErrorsequence;

    protected override void OnEnable()
    {
        base.OnEnable();
        closeButton.onClick.AddListener(CloseButtonOnClick);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        closeButton.onClick.RemoveListener(CloseButtonOnClick);
    }

    private void Start()
    {
        _ = InternetConnectionChecking_Loop();
    }

    private void CloseButtonOnClick()
    {
        PlayFXText();
    }

    private void PlayFXText()
    {
        if (fxErrorsequence != null) fxErrorsequence.Kill();
        fxErrorsequence = DOTween.Sequence();
        errorTextTransform.localScale = Vector3.one;

        fxErrorsequence
            .Append(errorTextTransform.DOScale(Vector3.one * 1.2f, 0.15f))
            .Append(errorTextTransform.DOScale(Vector3.one * 0.9f, 0.2f))
            .Append(errorTextTransform.DOScale(Vector3.one, 0.1f));
        fxErrorsequence.Play();
    }

    private async UniTaskVoid InternetConnectionChecking_Loop()
    {
        while (true)
        {
            _ = SendRequest2((isConnected) =>
            {
                _connected = isConnected;

                if (isConnected) HidePopup();
                else ShowPopupWithValidate();
            });
            await UniTask.Delay(5000);
        }
    }

    private void ShowPopupWithValidate()
    {
        base.ShowPopup();
    }

    private async UniTask SendRequest(Action<bool> action)
    {
        UnityWebRequest request = new UnityWebRequest("https://www.google.com/");
        CancellationTokenSource token = new CancellationTokenSource();
        token.CancelAfterSlim(TimeSpan.FromSeconds(2f), DelayType.Realtime);
        try
        {
            await request.SendWebRequest().WithCancellation(token.Token);
            action.Invoke(true);
        }
        catch (Exception ex)
        {
            if ((ex as OperationCanceledException).CancellationToken == token.Token
                || (ex as System.Threading.Tasks.TaskCanceledException).CancellationToken == token.Token
            )
            {
                //  Case request is canceled and no result
                action?.Invoke(false);
            }
            else
            {
                switch (request.result)
                {
                    case UnityWebRequest.Result.Success:
                        action?.Invoke(true);
                        break;
                    case UnityWebRequest.Result.InProgress:
                    case UnityWebRequest.Result.ConnectionError:
                    case UnityWebRequest.Result.DataProcessingError:
                    case UnityWebRequest.Result.ProtocolError:
                        action?.Invoke(false);
                        break;
                    default: break;
                }
            }
        }
    }

    public static async Task SendRequest2(Action<bool> action)
    {
        UnityWebRequest request = new UnityWebRequest("https://www.google.com/");
        using (var cancellationTokenSource = new CancellationTokenSource(new TimeSpan(1000)))
        {
            try
            {
                // Debug.LogWarning("_IC2: Start send request");
                await request.SendWebRequest();
                switch (request.result)
                {
                    case UnityWebRequest.Result.Success:
                        action?.Invoke(true);
                        break;
                    case UnityWebRequest.Result.InProgress:
                    case UnityWebRequest.Result.ConnectionError:
                    case UnityWebRequest.Result.DataProcessingError:
                    case UnityWebRequest.Result.ProtocolError:
                        action?.Invoke(false);
                        break;
                    default: break;
                }
                // Debug.LogWarning("_IC2: Request done");
            }
            catch (Exception)
            {
                action?.Invoke(false);
            }
        }
    }
}
