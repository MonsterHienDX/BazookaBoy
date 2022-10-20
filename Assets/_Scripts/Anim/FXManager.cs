using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    private Vector3 _cachedVector3;
    private Tween _moveCamTween;

    private void OnEnable()
    {
        this.RegisterListener(EventID.LoadLevel, HandleEventLoadLevel);
    }

    private void OnDisable()
    {
        this.RemoveListener(EventID.LoadLevel, HandleEventLoadLevel);
    }

    private void HandleEventLoadLevel(object param = null)
    {
        _moveCamTween?.Complete();
        _moveCamTween = CamZoomOut();
        _moveCamTween.Play();
    }

    private Tween CamZoomOut()
    {
        Vector3 startCamPos = GameManager.mainCamera.transform.position;
        _cachedVector3.Set(startCamPos.x, startCamPos.y, startCamPos.z - 13f);

        return GameManager.mainCamera.transform.DOMove(startCamPos, Const.DELAY_AFTER_LOAD_LEVEL)
            .OnPlay(() =>
            {
                GameManager.mainCamera.transform.position = _cachedVector3;
            })
            .OnComplete(() =>
            {
                GameManager.mainCamera.transform.position = startCamPos;
            }
            )
        ;
    }
}
