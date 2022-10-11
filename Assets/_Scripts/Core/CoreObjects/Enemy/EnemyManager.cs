using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [field: SerializeField] public Material dieMaterial { get; private set; }
    private List<Enemy> enemyList;
    private int enemyAmount;

    private void OnEnable()
    {
        EventDispatcher.Instance.RegisterListener(EventID.EnemyDie, HandleEventEnemyDie);
    }

    private void OnDisable()
    {
        EventDispatcher.Instance.RemoveListener(EventID.EnemyDie, HandleEventEnemyDie);
    }

    private void Awake()
    {
        enemyList = new List<Enemy>();
    }

    private void Start()
    {

    }

    public void Init()
    {

    }


    public void Reset()
    {

    }

    private void HandleEventEnemyDie(object param)
    {
        Enemy enemy = (Enemy)param;
        if (!enemy || enemy.isDie) return;
        Debug.Log("HandleEventEnemyDie");
        enemy.ChangeDieMaterial(dieMaterial);
        enemyAmount--;
        if (enemyAmount <= 0) _ = GameManager.instance.WinLevel();
    }
}
