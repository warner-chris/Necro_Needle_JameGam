using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void GoToOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
    public void OnRestart()
    {
        SceneManager.LoadScene("Level1");
    }
    public void OnMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void OnBack()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
    }

}