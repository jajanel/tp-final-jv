using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public GameObject[] routes;
    private List<GameObject> routeAjouter = new List<GameObject>();
    public TextMeshProUGUI scoreText;
    public static int score;
    public Vector3 spawnPos;
    private float nextDelay = 5f;
    private float progress;
    private float repeatDelay = 2f;
    private float spawnz = 0f;
    private int scoreMinDeleteRoute = 10;
    public PausePanel pausePanel;
    public GameObject[] characterPrefabs; // Liste des prefabs des personnages
    public Vector3 playerSpawnPoint; // Point d'apparition du joueur
    private string selectedCharacter;
    public GameState gameState;
    public AudioSource gameMusic;

    // Start is called before the first frame update
    void Start()
    {
        GameOverController.Restart();
        playerSpawnPoint = new Vector3(40, 0, -8);
        progress = 0f;
        pausePanel = GetComponent<PausePanel>();
        spawnPos = new Vector3(-45,0, spawnz);
        for (int i = 0; i < 10; i++) {
            SpawnRoute();
        }
        if (SaveSystem.CheckHasSave() && SaveSystem.ContinueGame)
        {
            gameState = SaveSystem.LoadStateFromSave();
            score = gameState.score;
            scoreMinDeleteRoute += score;
        }
        else
        {
            gameState = new GameState();
            score = 0;
        }
        scoreText.text = $"Score:{score}";
        selectedCharacter = PlayerPrefs.GetString("SelectedCharacter");
        Debug.Log($"Personnage sélectionné pour la scène : {selectedCharacter}");

        GameObject characterPrefab = System.Array.Find(characterPrefabs, prefab => prefab.name == selectedCharacter);

        if (characterPrefab != null)
        {
            Instantiate(characterPrefab, playerSpawnPoint, Quaternion.identity);
            Debug.Log($"Personnage instancié : {selectedCharacter}");
        }
        else
        {
            Debug.LogError("Aucun prefab correspondant au personnage sélectionné.");
        }

     
        gameMusic.volume = GameSettings.SoundVolume;

    }

    // Update is called once per frame
    void Update()
    {
        progress += Time.deltaTime;

        if (progress >= nextDelay && !GameOverController.GetGameOver())
        {
            //Spawner un obstacle et reset le progrès
            progress = 0f;
            SpawnRoute();

            //Prochain délai est aléatoire autour de repeatDelay
            nextDelay = Random.Range(0.85f * repeatDelay, 1.15f * repeatDelay);
        }
        else if (GameOverController.GetGameOver())
        {
            pausePanel.GameOver();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !pausePanel.gameIsPause)
        {
            pausePanel.OpenPanel();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pausePanel.gameIsPause)
        {
            pausePanel.ClosePanel();
        }
       

    }

    public void compteScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
        gameState.score = score;
    }

    private void SpawnRoute()
    {
        int indexRouteDelete = 0;
        int index = Random.Range(0, routes.Length);
        GameObject route = routes[index];
        spawnz += route.GetComponent<BoxCollider>().size.z;
        spawnPos = new Vector3(-45, 0, spawnz);
        routeAjouter.Add(Instantiate(route, spawnPos, route.transform.rotation));
        if(score > scoreMinDeleteRoute)
        {
            Destroy(routeAjouter[0]);
            routeAjouter.RemoveAt(0);
            scoreMinDeleteRoute++;
        }
    }
}