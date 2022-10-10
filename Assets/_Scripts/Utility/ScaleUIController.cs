using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUIController : MonoBehaviour
{
    public Transform[] scaleContainer;
    public Transform[] leftContainer;
    public Transform[] rightContainer;
    public Transform[] bottomContainer;
    public Transform[] topContainer;

    [HideInInspector]
    public float yBottomPosDefault = 0;
    [HideInInspector]
    public float yTopPosDefault = 0;
    [HideInInspector]
    public float xRightPosDefault = 0;
    [HideInInspector]
    public float xLeftPosDefault = 0;

    public void InitUI()
    {
        if (bottomContainer.Length > 0) yBottomPosDefault = bottomContainer[0].transform.position.y;
        if (topContainer.Length > 0) yTopPosDefault = topContainer[0].transform.position.y;
        if (rightContainer.Length > 0) xRightPosDefault = rightContainer[0].transform.position.x;
        if (leftContainer.Length > 0) xLeftPosDefault = leftContainer[0].transform.position.x;

        foreach (Transform transform in scaleContainer)
        {
            transform.localScale = Vector3.zero;
        }
    }

    public void MoveUpUI(float duration, Action onMoveUpSuccessful)
    {
        foreach (Transform transform in topContainer)
        {
            transform.DOMoveY(transform.position.y + 300, duration).SetEase(Ease.InOutSine);
        }
        this.CallWithDelay(() => { onMoveUpSuccessful?.Invoke(); }, duration);
    }

    public void UnMoveUpUI(float duration, Action onUnMoveUpSuccessful)
    {
        foreach (Transform transform in topContainer)
        {
            transform.DOMoveY(yTopPosDefault, duration).SetEase(Ease.InOutSine);
        }
        this.CallWithDelay(() => { onUnMoveUpSuccessful?.Invoke(); }, duration);
    }

    public void MoveDownUI(float duration, Action onMoveDownSuccessful)
    {
        foreach (Transform transform in bottomContainer)
        {
            transform.DOMoveY(-1200f, duration).SetEase(Ease.InOutSine);
        }
        this.CallWithDelay(() => { onMoveDownSuccessful?.Invoke(); }, duration);
    }

    public void UnMoveDownUI(float duration, Action onUnMoveDownSuccessful)
    {
        foreach (Transform transform in bottomContainer)
        {
            transform.DOMoveY(yBottomPosDefault, duration).SetEase(Ease.InOutSine);
        }
        this.CallWithDelay(() => { onUnMoveDownSuccessful?.Invoke(); }, duration);
    }

    public void MoveRightUI(float duration, Action onMoveRightSuccessful)
    {
        foreach (Transform transform in rightContainer)
        {
            transform.DOMoveX(transform.position.x + 300, duration).SetEase(Ease.InOutSine);
        }
        this.CallWithDelay(() => { onMoveRightSuccessful?.Invoke(); }, duration);
    }

    public void UnMoveRightUI(float duration, Action onUnMoveRightSuccessful)
    {
        foreach (Transform transform in rightContainer)
        {
            transform.DOMoveX(xRightPosDefault, duration).SetEase(Ease.InOutSine);
        }
        this.CallWithDelay(() => { onUnMoveRightSuccessful?.Invoke(); }, duration);
    }

    public void MoveLeftUI(float duration, Action onMoveLeftSuccessful)
    {
        foreach (Transform transform in leftContainer)
        {
            transform.DOMoveX(transform.position.x - 300, duration).SetEase(Ease.InOutSine);
        }
        this.CallWithDelay(() => { onMoveLeftSuccessful?.Invoke(); }, duration);
    }

    public void UnMoveLeftUI(float duration, Action onUnMoveLeftSuccessful)
    {
        foreach (Transform transform in leftContainer)
        {
            transform.DOMoveX(xLeftPosDefault, duration).SetEase(Ease.InOutSine);
        }
        this.CallWithDelay(() => { onUnMoveLeftSuccessful?.Invoke(); }, duration);
    }

    public void ScaleUI(float target,  float duration, Action OnScaleUISuccessfull)
    {
        foreach (Transform transform in scaleContainer)
        {
            transform.DOScale(target, duration).SetEase(Ease.InOutSine);
        }
        this.CallWithDelay(() => { OnScaleUISuccessfull?.Invoke(); }, duration);
    }

    public void ScaleUIElement(Transform transform, float target, float duration, float delay, Action OnScaleUIElementSuccessfull)
    {
        transform.DOScale(target, duration).SetDelay(delay).SetEase(Ease.InOutSine).OnComplete(() => {
            OnScaleUIElementSuccessfull?.Invoke();
        });
    }

    public void MoveXUI(Transform transform, float target, float duration, Action OnMoveXUIElementSuccessfull)
    {
        transform.DOMoveX(transform.position.x + target, duration).SetEase(Ease.InOutSine).OnComplete(() => {
            OnMoveXUIElementSuccessfull?.Invoke();
        });
    }
    public void MoveResetXUI(Transform transform, float target, float duration, Action OnMoveXUIElementSuccessfull)
    {
        transform.DOMoveX(target, duration).SetEase(Ease.InOutSine).OnComplete(() => {
            OnMoveXUIElementSuccessfull?.Invoke();
        });
    }
    public void MoveYUI(Transform transform, float target, float duration, Action OnMoveYElementSuccessfull)
    {
        transform.DOMoveY(transform.position.y + target, duration).SetEase(Ease.InOutSine).OnComplete(() => {
            OnMoveYElementSuccessfull?.Invoke();
        });
    }
    public void MoveResetYUI(Transform transform, float target, float duration, Action OnMoveYElementSuccessfull)
    {
        transform.DOMoveY(target, duration).SetEase(Ease.InOutSine).OnComplete(()=> {
            OnMoveYElementSuccessfull?.Invoke();
        });
    }
}
