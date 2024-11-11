using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GoToMenu();
    }

    public static void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public static void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public static void ExitApp()
    {
        Application.Quit();
    }
}
