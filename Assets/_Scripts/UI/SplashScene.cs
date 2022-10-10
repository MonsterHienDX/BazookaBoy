using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScene : MonoBehaviour
{
    // public bool sceneLoading = false;
    // public Image handleWheel;
    // public Slider slider;

    // private string sceneMain = "PersistentScene";

    // private string sceneLoad = "Loading";

    // private void Awake()
    // {
    //     Application.targetFrameRate = 60;
    // }

    // // Start is called before the first frame update
    // private void Start()
    // {
    //     // DontDestroyOnLoad(this);
    //     LoadScene();
    //     handleWheel.transform.DORotate(new Vector3(0, 0, -360), .5f, RotateMode.FastBeyond360).SetLoops(-1).Play();
    // }

    // public void LoadScene()
    // {
    //     StartCoroutine(LoadAyncScene());
    // }

    // IEnumerator LoadAyncScene()
    // {
    //     sceneLoading = true;

    //     float loadCount = 0.05f;
    //     slider.value = loadCount;

    //     // var sizeDelta = slideBar.rectTransform.sizeDelta;
    //     // float maxSize = sizeDelta.x;
    //     WaitForSeconds seconds = new WaitForSeconds(0.01f);
    //     // Vector2 size = new Vector2(loadCount * maxSize, sizeDelta.y);
    //     while (loadCount < 0.7f)
    //     {
    //         loadCount += 0.01f;
    //         // slideBar.rectTransform.sizeDelta = new Vector2(loadCount * maxSize, sizeDelta.y);
    //         slider.value = loadCount;
    //         yield return seconds;
    //     }

    //     AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneMain);
    //     //Don't let the Scene activate until you allow it to
    //     asyncOperation.allowSceneActivation = false;
    //     Debug.Log("Progress :" + asyncOperation.progress);
    //     //When the load is still in progress, output the Text and progress bar

    //     while (asyncOperation.progress < .9f)
    //     {
    //         //Output the current progress
    //         if (loadCount < 1f)
    //         {
    //             loadCount = 1f;
    //             // slideBar.image.fillAmount = loadCount;
    //             slider.value = loadCount;
    //             // slideBar.rectTransform.sizeDelta = new Vector2(loadCount * maxSize, sizeDelta.y);
    //         }

    //         // Check if the load has finished
    //         yield return null;
    //     }

    //     yield return new WaitUntil(AdsController.Instances.IsInitialized);
    //     sceneLoading = false;
    //     asyncOperation.allowSceneActivation = true;
    // }

    // IEnumerator DelayLoadCanvas()
    // {
    //     yield return new WaitUntil(AdsController.Instances.IsInitialized);
    //     sceneLoading = false;
    // }
}