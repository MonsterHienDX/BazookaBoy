using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PopupBase : MonoBehaviour
{
    [SerializeField] protected Button xButton;
    protected CanvasGroup canvasGroup;
    protected bool _isShowing;
    public bool isShowing => _isShowing;

    protected virtual void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    protected virtual void OnEnable()
    {
        xButton?.onClick.AddListener(CloseButtonOnClick);
    }
    protected virtual void OnDisable()
    {
        xButton?.onClick.RemoveListener(CloseButtonOnClick);
    }

    public virtual void ShowPopup()
    {
        if (isShowing) return;
        canvasGroup.DOFade(1, Const.PANEL_SLIDE_SPEED).Play();
        canvasGroup.blocksRaycasts = true;
        EventDispatcher.Instance.PostEvent(EventID.ShowPopup, true);
        _isShowing = true;
    }

    private void CloseButtonOnClick()
    {
        HidePopup();
        AudioManager.instance.PlayManagerSound(SoundName.ButtonClick);
    }

    public virtual void HidePopup()
    {
        if (!isShowing) return;
        canvasGroup.DOFade(0, Const.PANEL_SLIDE_SPEED).Play();
        canvasGroup.blocksRaycasts = false;
        EventDispatcher.Instance.PostEvent(EventID.ShowPopup, false);
        _isShowing = false;
    }
}
