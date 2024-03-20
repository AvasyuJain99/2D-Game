using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("Game");
    }
    public void QuitApplication()
    {
        Application.Quit();
    }
    public void OpenMenu()
    {

    }
}
