using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameManager gameManager;
    public bool gameIsPause;
    public GameObject gameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        pauseScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        gameManager = GetComponent<GameManager>();
        gameIsPause = false;
    }
    public void OpenPanel()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
        gameIsPause = true;
    }

    public void ClosePanel()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
        gameIsPause = false;
    }
    public void QuitGame()
    {
        SceneNavigator.ExitApp();
    }
    public void SaveGame()
    {
        //SaveSystem.SaveGame(gameManager.gameState);
        //Debug.Log(SaveSystem.CheckHasSave());
    }
    public void ReturnToMenu()
    {
        SceneNavigator.GoToMenu();
    }
    public void RestartGame()
    {
        gameOverScreen.SetActive(false);
        GameOverController.Restart();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
       
    }
}

