using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static bool GetChecked(string menuPath)
    {
        throw new NotImplementedException();
    }

    public static void SetChecked(string menuPath, bool flag)
    {
        throw new NotImplementedException();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("CharacterUI");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}

