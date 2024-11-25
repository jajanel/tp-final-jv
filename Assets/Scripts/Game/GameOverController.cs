using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    private static bool gameOver = false;
    public static void GameOver()
    {
        gameOver = true;
    }
    public static void Restart()
    {
        gameOver = false;
    }
    public static bool GetGameOver()
    {
        return gameOver;
    }
}
