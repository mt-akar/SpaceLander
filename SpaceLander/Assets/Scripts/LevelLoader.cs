﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            Debug.Log(operation.progress * 10 / 9f);

            yield return null;
        }
    }
}
