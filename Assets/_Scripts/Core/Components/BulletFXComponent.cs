using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BulletFXComponent : FXComponentBase
{
    [SerializeField] private SpriteRenderer _spriteBg;
    [SerializeField] private SpriteRenderer _spriteInner;
    private Color _startColorBg;
    private Color _startColorInner;
    [SerializeField] private ParticleSystem _fxStar;
    private Sequence fxSequence;

    private void Awake()
    {
        this._startColorBg = _spriteBg.color;
        this._startColorInner = _spriteInner.color;
    }

    private void Start()
    {
        HideFXSprite();
    }

    public void PlayExplodeFX()
    {
        if (fxSequence != null) fxSequence.Kill();
        fxSequence = DOTween.Sequence();

        fxSequence
            .Append(_spriteBg.transform.DOScale(Vector3.one, 0.15f))
            .Join(_spriteBg.DOFade(0f, 0.25f))
            .Join(_spriteInner.DOFade(0f, 0.25f))
            .OnComplete(() =>
            {
                _fxStar.Stop();
                HideFXSprite();
            })
            .OnPlay(() =>
            {
                _spriteInner.color = _startColorInner;
                _spriteBg.color = _startColorBg;
            }
        );
        fxSequence.Play();
        _fxStar.Play();
    }

    private void HideFXSprite() => _spriteBg.transform.localScale = Vector3.zero;

    public void UpdateFXSize(Vector2 size)
    {
        _spriteBg.transform.localScale = new Vector3(size.x, size.y, 1);
    }

    public void KillFX()
    {
        if (fxSequence != null)
        {
            fxSequence.Complete();
            fxSequence.Kill();
        }
        _fxStar.Stop();
    }
}
