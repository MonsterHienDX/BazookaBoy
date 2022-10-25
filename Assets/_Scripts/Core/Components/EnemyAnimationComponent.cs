using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EnemyTriggerKey
{
    public const string dodge_left = "dodge_left";
    public const string dodge_right = "dodge_right";
    public const string idle = "idle";
    public const string happy_idle = "happy_idle";
    public const string dancing_win = "dancing_win";
}

public class EnemyAnimationComponent : AnimationComponent
{
    [SerializeField] protected CircleCollider2D _dogdeRangeCollider;
    [SerializeField] protected Transform _bodyTransform;
    protected IEnumerator changeAnimIdleSometimesCO;
    [SerializeField] protected string[] winAnimNames;

    private void OnEnable()
    {
        this.RegisterListener(EventID.LoadLevel, HandleEventLoadLevel);
    }

    private void OnDisable()
    {
        this.RemoveListener(EventID.LoadLevel, HandleEventLoadLevel);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals(GameObjectTag.Bullet))
        {
            CheckBulletComeInRange(collider.transform);
        }
    }

    private void CheckBulletComeInRange(Transform bulletTransform)
    {
        bool isBulletComeFromLeft = bulletTransform.position.x < _bodyTransform.position.x;
        string triggerKey = (isBulletComeFromLeft) ? EnemyTriggerKey.dodge_left : EnemyTriggerKey.dodge_right;
        // ChangeAnimState(triggerKey);
        _animator.Play("Dodge Ducking");
    }


    private IEnumerator ChangeIdleAnimSometimes()
    {
        while (true)
        {
            yield return ExtensionClass.GetWaitForSeconds(CommonFunctions.RandomRange(1f, 15f));
            ChangeAnimState(EnemyTriggerKey.happy_idle);
        }
    }

    public override void ResetState()
    {
        base.ResetState();
        if (changeAnimIdleSometimesCO != null) StopCoroutine(changeAnimIdleSometimesCO);
        changeAnimIdleSometimesCO = ChangeIdleAnimSometimes();
        StartCoroutine(changeAnimIdleSometimesCO);
    }

    protected virtual void HandleEventLoadLevel(object param = null)
    {
        RandomAnimWhenStartLevel();
    }

    private void RandomAnimWhenStartLevel()
    {
        if (CommonFunctions.RandomRange(1, 3) == 1)
        {
            ChangeAnimState(EnemyTriggerKey.happy_idle);
        }
    }

    protected override void SetWinState(string animatorTriggerKey = EnemyTriggerKey.dancing_win)
    {
        base.SetWinState(animatorTriggerKey);
        this._animator.Play(winAnimNames.PickRandom());
    }

    public override void PlayAnimEndLevel()
    {
        ChangeHumanState(HumanState.Win);
        if (changeAnimIdleSometimesCO != null) StopCoroutine(changeAnimIdleSometimesCO);
    }
}
