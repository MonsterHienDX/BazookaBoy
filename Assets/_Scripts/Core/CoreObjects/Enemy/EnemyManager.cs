using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [field: SerializeField] public Material dieMaterial { get; private set; }
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Transform enemyContainer;
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

    public void Init(EnemyInfo[] enemyInfos)
    {
        enemyAmount = enemyInfos.Length;
        SpawnEnemies(enemyInfos);
    }

    public void SpawnEnemies(EnemyInfo[] enemyInfos)
    {
        for (int i = 0; i < enemyInfos.Length; i++)
        {
            SpawnEnemy(enemyInfos[i]);
        }
    }

    private void SpawnEnemy(EnemyInfo enemyInfo)
    {
        foreach (Enemy enemy in enemyList)
        {
            if (!enemy.isActive)
            {
                enemy.Enable(true);
                enemy.InitTransform(enemyInfo.pos);
                enemy.Init(enemyInfo.type);
                return;
            }
        }

        Enemy enemyNew = Instantiate<Enemy>(enemyPrefab, enemyContainer);
        enemyNew.Enable(true);
        enemyNew.InitTransform(enemyInfo.pos);
        enemyNew.Init(enemyInfo.type);
        this.enemyList.Add(enemyNew);
    }

    private void HandleEventEnemyDie(object param)
    {
        Enemy enemy = (Enemy)param;
        if (!enemy || enemy.isDie) return;
        enemy.ChangeDieMaterial(dieMaterial);
        enemyAmount--;
        if (enemyAmount <= 0) _ = GameManager.instance.WinLevel();
    }
}
