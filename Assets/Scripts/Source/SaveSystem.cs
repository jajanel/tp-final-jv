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
}
public class GameState
{
    public int score;
    public float difficulte;
    public int personnage;
}
