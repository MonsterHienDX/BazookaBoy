using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLevelPanel : PopupBase
{
    [SerializeField] private CanvasGroup winCanvasGroup;
    [SerializeField] private CanvasGroup loseCanvasGroup;

    [SerializeField] private Button getX2Button;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button tryAgainButton;
    [SerializeField] private Button skipLevelButton;

    protected override void OnEnable()
    {
        base.OnEnable();
        getX2Button.onClick.AddListener(GetX2ButtonOnClick);
        continueButton.onClick.AddListener(ContinueButtonOnClick);
        tryAgainButton.onClick.AddListener(TryAgainButtonOnClick);
        skipLevelButton.onClick.AddListener(SkipLevelButtonOnClick);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        getX2Button.onClick.RemoveListener(GetX2ButtonOnClick);
        continueButton.onClick.RemoveListener(ContinueButtonOnClick);
        tryAgainButton.onClick.RemoveListener(TryAgainButtonOnClick);
        skipLevelButton.onClick.RemoveListener(SkipLevelButtonOnClick);
    }


    public void ShowPopupEndLevel(bool isWin)
    {
        SetUpWinPanel(isWin);
        this.ShowPopup();
    }

    private void SetUpWinPanel(bool isWin)
    {
        winCanvasGroup.alpha = (isWin) ? 1f : 0f;
        winCanvasGroup.blocksRaycasts = isWin;
        loseCanvasGroup.alpha = (!isWin) ? 1f : 0f;
        loseCanvasGroup.blocksRaycasts = !isWin;
    }

    private void GetX2ButtonOnClick()
    {
        //  TODO: Show rewarded

        //  TODO: Summary then x2 coins player

        //  TODO: Hide pop up
        this.HidePopup();

        //  TODO: Reset data level

        //  TODO: Load next level
    }

    private void ContinueButtonOnClick()
    {
        //  TODO: Show interstitial

        //  TODO: Summary coins player

        //  TODO: Hide pop up
        this.HidePopup();

        //  TODO: Reset data level

        //  TODO: Load next level
    }

    private void TryAgainButtonOnClick()
    {
        //  TODO: Show interstitial

        //  TODO: Hide pop up
        this.HidePopup();

        //  TODO: Reset data level

        //  TODO: Load current level
    }


    private void SkipLevelButtonOnClick()
    {
        //  TODO: Show rewarded

        //  TODO: Hide pop up
        this.HidePopup();

        //  TODO: Reset data level

        //  TODO: Load next level
    }
}
