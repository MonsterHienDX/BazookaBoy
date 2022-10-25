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
    private Vector3 groundCenterPos;
    private Vector3 cachedVector3;

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

    public void Init(EnemyInfo[] enemyInfos, Vector3 groundCenterPos)
    {
        this.groundCenterPos = groundCenterPos;
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
                enemy.InitTransform(enemyInfo.pos, groundCenterPos);
                enemy.Init(enemyInfo.type);
                enemy.Reset();
                return;
            }
        }

        Enemy enemyNew = Instantiate<Enemy>(enemyPrefab, enemyContainer);
        enemyNew.name = $"Enemy {enemyList.Count}";
        enemyNew.Enable(true);
        enemyNew.InitTransform(enemyInfo.pos, groundCenterPos);
        enemyNew.Init(enemyInfo.type);
        this.enemyList.Add(enemyNew);
    }

    private void HandleEventEnemyDie(object param)
    {
        Enemy enemy = (Enemy)param;
        if (!enemy || enemy.isDie) return;
        enemyAmount--;
        if (enemyAmount <= 0) _ = GameManager.instance.WinLevel();
    }
}
