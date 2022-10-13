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

    public void Init()
    {

    }


    public void Reset()
    {

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
        Enemy enemy = Instantiate<Enemy>(enemyPrefab, enemyContainer);
        enemy.Enable(true);
        enemy.InitTransform(enemyInfo.pos);
        enemy.Init(enemyInfo.type);
        this.enemyList.Add(enemy);
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
