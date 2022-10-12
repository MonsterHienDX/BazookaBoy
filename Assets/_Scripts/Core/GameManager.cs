using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : SingletonMonobehaviour<GameManager>
{
    public bool isPlaying { get; private set; }
    public static Camera mainCamera { get; private set; }
    [SerializeField] private EndLevelPanel _endLevelPanel;
    [SerializeField] private Button reloadSceneButton;
    [SerializeField] private LevelInfoSO dataLevel;
    [SerializeField] private MapObjectManager _mapObjectManager;
    [SerializeField] private EnemyManager _enemyManager;
    [SerializeField] private Player _player;

    protected override void Awake()
    {
        base.Awake();
        Application.targetFrameRate = Const.FPS;
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        reloadSceneButton.onClick.AddListener(ReLoadScene);
    }

    private void OnDisable()
    {
        reloadSceneButton.onClick.RemoveListener(ReLoadScene);
    }

    private void Start()
    {
        LoadLevel();
    }

    public void LoadLevel()
    {
        //  TODO: Clear level data

        ResetDataLevel();

        //  TODO: Load new level
        LevelInfo levelInfo = dataLevel.levelInfos[0];

        _mapObjectManager.SpawnGround(levelInfo.groundInfo);
        _mapObjectManager.SpawnStones(levelInfo.stones);
        _mapObjectManager.SpawnWoods(levelInfo.woods);
        _enemyManager.SpawnEnemies(levelInfo.enemies);
        _player.SetPosition(levelInfo.playerPos);

        this.isPlaying = true;
    }

    public async UniTask WinLevel()
    {
        // EndLevel();

        //  TODO: Summary resources

        //  TODO: Show popup win
        // _endLevelPanel.ShowPopupEndLevel(true);
        await UniTask.Delay(0);
        Debug.Log("Win level");
        // await UniTask.WaitUntil(() => !_endLevelPanel.isShowing);

        // LoadLevel();
    }

    public async UniTask LoseLevel()
    {
        // EndLevel();

        // _endLevelPanel.ShowPopupEndLevel(false);
        await UniTask.Delay(0);
        Debug.Log("Lose level");
        // await UniTask.WaitUntil(() => !_endLevelPanel.isShowing);

        // LoadLevel();
    }

    private void EndLevel()
    {
        //  TODO: Stop checking physic

        this.isPlaying = false;

    }

    private void ReLoadScene()
    {
        SceneManager.LoadScene("DemoDestructible2D");
    }

    private void ResetDataLevel()
    {
        //  TODO: Reset data level
        EventDispatcher.Instance.PostEvent(EventID.ResetDataLevel);
    }
}
