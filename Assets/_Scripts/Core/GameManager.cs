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
    [field: SerializeField] public Player _player { get; private set; }
    public int levelAmount { get; private set; }
    public bool hasPopupShowing { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        Application.targetFrameRate = Const.FPS;
        mainCamera = Camera.main;
        levelAmount = dataLevel.levelInfos.Count;
    }

    private void OnEnable()
    {
        reloadSceneButton.onClick.AddListener(ReLoadScene);
        this.RegisterListener(EventID.ShowPopup, HandleEventHasPopupShowing);
    }

    private void OnDisable()
    {
        reloadSceneButton.onClick.RemoveListener(ReLoadScene);
        this.RemoveListener(EventID.ShowPopup, HandleEventHasPopupShowing);
    }

    private void Start()
    {
        LoadLevel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) LoadLevel();

    }

    public void LoadLevel()
    {
        //  TODO: Clear level data

        ResetDataLevel();

        //  TODO: Load new level
        int indexLevelNumberToLoad =
            (UserData.LevelNumber > levelAmount) ? UnityEngine.Random.Range(0, levelAmount) : UserData.LevelNumber - 1;
        LevelInfo levelInfo = dataLevel.levelInfos[indexLevelNumberToLoad];

        _mapObjectManager.SpawnGround(levelInfo.groundInfo);
        _mapObjectManager.SpawnStones(levelInfo.stones);
        _mapObjectManager.SpawnWoods(levelInfo.woods);
        _player.InitTransform(levelInfo.playerPos);
        _enemyManager.Init(levelInfo.enemies);

        this.isPlaying = true;

        this.PostEvent(EventID.LoadLevel);
    }

    public void LoadLevelByLevelIndex(int indexLevel)
    {
        EndLevel();
        UserData.LevelNumber = indexLevel;
        LoadLevel();
    }

    public void LoadNextLevel()
    {
        EndLevel();
        UserData.LevelNumber++;
        LoadLevel();
    }

    public void ReplayLevel()
    {
        EndLevel();
        LoadLevel();
    }

    public async UniTask WinLevel()
    {
        if (!isPlaying) return;
        EndLevel();
        UserData.LevelNumber++;
        Debug.Log("Win level");

        //  TODO: Summary resources

        //  TODO: Show popup win
        await UniTask.Delay(3000);
        _endLevelPanel.ShowPopupEndLevel(true);
        await UniTask.WaitUntil(() => !_endLevelPanel.isShowing);

        LoadLevel();
    }

    public async UniTask LoseLevel()
    {
        if (!isPlaying) return;
        Debug.Log("Lose level");
        EndLevel();

        await UniTask.Delay(3000);
        _endLevelPanel.ShowPopupEndLevel(false);
        await UniTask.WaitUntil(() => !_endLevelPanel.isShowing);

        LoadLevel();
    }

    private void EndLevel()
    {
        //  TODO: Stop checking physic

        this.isPlaying = false;

        this.PostEvent(EventID.EndLevel);
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

    private void HandleEventHasPopupShowing(object param = null) => hasPopupShowing = (bool)param;
}
