using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPicker : MonoBehaviour
{
    [SerializeField] private InputField levelInput;
    [SerializeField] private Button loadLevelButton;

    private void OnEnable()
    {
        loadLevelButton.onClick.AddListener(LoadLevel);
    }

    private void OnDisable()
    {
        loadLevelButton.onClick.RemoveListener(LoadLevel);
    }

    private void LoadLevel()
    {
        int levelIndex = GetLevelNumberInput(levelInput);
        GameManager.instance.LoadLevelByLevelIndex(levelIndex);
    }


    protected virtual int GetLevelNumberInput(InputField inputField)
    {
        int.TryParse(inputField.text, out int levelNumber);
        if (levelNumber <= 0 || levelNumber > GameManager.instance.levelAmount)
        {
            Debug.LogError("IGE: Level number to load is invalid!");
            return -1;
        }

        Debug.Log("IGE: load level number: " + levelNumber);
        return levelNumber;
    }
}
