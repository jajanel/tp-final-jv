using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static bool ContinueGame = true;
    public static void SaveGame(GameState save) {
        var serializedSave = JsonUtility.ToJson(save);

        var path = Path.Combine(Application.persistentDataPath, $"game.boxSave");
        File.WriteAllText(path, serializedSave);
    }
    public static bool CheckHasSave()
    {
        var path = Path.Combine(Application.persistentDataPath, $"game.boxSave");
        if (File.Exists(path))
        {
            return true;
        }
        else return false;
    }
    public static GameState LoadStateFromSave()
    {
        var path = Path.Combine(Application.persistentDataPath, $"game.boxSave");
        if (CheckHasSave())
        {
            var serializedSave = File.ReadAllText(path);
            return JsonUtility.FromJson<GameState>(serializedSave);
        }
        else return null;
    }


    //Meilleur Score
    public static void SaveGameMeilleurScore(GameStateMeilleurScore save)
    {
        var serializedSave = JsonUtility.ToJson(save);

        var path = Path.Combine(Application.persistentDataPath, $"game.MeilleurScoreSave");
        File.WriteAllText(path, serializedSave);
    }
    public static bool CheckHasSaveMeilleurScore()
    {
        var path = Path.Combine(Application.persistentDataPath, $"game.MeilleurScoreSave");
        if (File.Exists(path))
        {
            return true;
        }
        else return false;
    }
    public static GameStateMeilleurScore LoadStateFromSaveMeilleurScore()
    {
        var path = Path.Combine(Application.persistentDataPath, $"game.MeilleurScoreSave");
        if (CheckHasSaveMeilleurScore())
        {
            var serializedSave = File.ReadAllText(path);
            return JsonUtility.FromJson<GameStateMeilleurScore>(serializedSave);
        }
        else return null;
    }
}
public class GameState
{
    public int score;
    public int personnage;
}
public class GameStateMeilleurScore
{
    public int meilleurScore;
}
