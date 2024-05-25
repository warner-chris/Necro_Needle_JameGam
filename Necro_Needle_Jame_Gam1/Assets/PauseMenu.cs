using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameOptions : MonoBehaviour
{
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
