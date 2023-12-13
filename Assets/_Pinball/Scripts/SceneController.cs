using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void MainMenuScene()
    {
        SceneManager.LoadScene("Main Menu");
    }
    
    public void PlayGameScene()
    {
        SceneManager.LoadScene("Pinball");
    }

    public void CreditScene()
    {
        SceneManager.LoadScene("Credit");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void TestButton(string text)
    {
        Debug.Log(text);
    }
}
