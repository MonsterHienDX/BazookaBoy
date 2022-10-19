using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutOfBulletPopup : PopupBase
{
    [SerializeField] private Button _reloadBulletButton;
    [SerializeField] private Button _skipLevelButton;
    [SerializeField] private Button _noThanksButton;
    private IEnumerator waitBulletAffectCO;

    protected override void OnEnable()
    {
        base.OnEnable();
        _reloadBulletButton.onClick.AddListener(ReloadBulletButtonOnClick);
        _skipLevelButton.onClick.AddListener(SkipLevelButtonOnClick);
        _noThanksButton.onClick.AddListener(NoThanksButtonOnClick);
        this.RegisterListener(EventID.OutOfBullet, HandleEventOutOfBullet);
        this.RegisterListener(EventID.ResetDataLevel, HandleEventResetDataLevel);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _reloadBulletButton.onClick.RemoveListener(ReloadBulletButtonOnClick);
        _skipLevelButton.onClick.RemoveListener(SkipLevelButtonOnClick);
        _noThanksButton.onClick.RemoveListener(NoThanksButtonOnClick);
        this.RemoveListener(EventID.OutOfBullet, HandleEventOutOfBullet);
        this.RemoveListener(EventID.ResetDataLevel, HandleEventResetDataLevel);
    }


    private void HandleEventOutOfBullet(object param = null)
    {
        if (waitBulletAffectCO != null) StopCoroutine(waitBulletAffectCO);
        waitBulletAffectCO = WaitThenCheckAfterOutOfBullet(5f);
        StartCoroutine(waitBulletAffectCO);
    }

    private void HandleEventResetDataLevel(object param = null)
    {
        if (waitBulletAffectCO != null) StopCoroutine(waitBulletAffectCO);
    }

    private IEnumerator WaitThenCheckAfterOutOfBullet(float delayWait)
    {
        yield return ExtensionClass.GetWaitForSeconds(delayWait);
        if (GameManager.instance.isPlaying) this.ShowPopup();
    }

    private void ReloadBulletButtonOnClick()
    {
        //  TODO: Show rewarded video 

        GameManager.instance._player.RefillBullet();
        this.HidePopup();

        this.PostEvent(EventID.PlayerReloadBullet);
    }

    private void SkipLevelButtonOnClick()
    {
        //  TODO: Show rewarded video

        GameManager.instance.LoadNextLevel();
        this.HidePopup();
    }

    private void NoThanksButtonOnClick()
    {
        //  TODO: Show interstitial ads

        GameManager.instance.ReplayLevel();
        this.HidePopup();
    }
}
