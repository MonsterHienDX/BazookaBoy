using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPlaying { get; private set; }
    public static Camera mainCamera { get; private set; }

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        mainCamera = Camera.main;
    }

    public void LoadLevel()
    {
        //  TODO: Clear level data

        ResetDataLevel();

        //  TODO: Load new level
    }

    public void WinLevel()
    {
        EndLevel();

        //  TODO: Summary resources

        //  TODO: Show popup win

        LoadLevel();
    }

    public void LoseLevel()
    {
        EndLevel();

        LoadLevel();
    }

    private void EndLevel()
    {
        //  TODO: Stop checking physic

    }

    private void ResetDataLevel()
    {
        //  TODO: Reset data level
    }
}
