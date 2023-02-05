using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    [SerializeField] private Object fightScene;

    public void StartGame() 
    {
        SceneManager.LoadSceneAsync("Fight");
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
