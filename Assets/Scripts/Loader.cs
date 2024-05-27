using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public void StartLevel1()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void LoadLevelSelect()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void LoadVictory()
    {
        SceneManager.LoadSceneAsync(3);
    }

}
