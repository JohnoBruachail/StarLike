using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;

    public void LoadLevel(int sceneIndex){
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    //whenever we clall this coroutine we load the scene asynchronously using the index, then store the current state of the operation
    //then we start a while loop which complete when scene is loaded
    IEnumerator LoadAsynchronously (int sceneIndex){
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        //while the operation is not done.
        while (!operation.isDone){

            float progress = Mathf.Clamp01(operation.progress / .9f); //used to clamp the value from 0.0 - 0.9 to 0.0 - 1.0
            slider.value = progress;

            yield return null; //wait until next frame before continuing
        }
    }
}