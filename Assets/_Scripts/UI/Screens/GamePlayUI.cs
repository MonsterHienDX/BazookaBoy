using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayUI : MonoBehaviour
{
    [SerializeField] private Image[] _bulletImages;
    private Player _player => GameManager.instance._player;
    [SerializeField] private Color normalColor;
    [SerializeField] private Color disableColor;
    [SerializeField] private Text _levelText;

    private void OnEnable()
    {
        this.RegisterListener(EventID.PlayerShot, UpdateBulletUI);
        this.RegisterListener(EventID.PlayerReloadBullet, UpdateBulletUI);
        this.RegisterListener(EventID.ResetDataLevel, HandleEventResetDataLevel);
        this.RegisterListener(EventID.LoadLevel, HandleEventLoadLevel);
    }

    private void OnDisable()
    {
        this.RemoveListener(EventID.PlayerShot, UpdateBulletUI);
        this.RemoveListener(EventID.PlayerReloadBullet, UpdateBulletUI);
        this.RemoveListener(EventID.ResetDataLevel, HandleEventResetDataLevel);
        this.RemoveListener(EventID.LoadLevel, HandleEventLoadLevel);
    }

    private void HandleEventResetDataLevel(object param = null)
    {
        foreach (var bulletImage in _bulletImages)
        {
            bulletImage.color = normalColor;
        }
    }

    private void HandleEventLoadLevel(object param = null)
    {
        UpdateLevelText(param);
    }

    private void UpdateBulletUI(object param = null)
    {
        for (int i = 0; i < _bulletImages.Length; i++)
        {
            _bulletImages[i].color = (i < _player.cachedMaxBullet) ? normalColor : disableColor;
        }
    }

    private void UpdateLevelText(object param = null)
    {
        _levelText.text = $"LEVEL {UserData.LevelNumber}";
    }
}
