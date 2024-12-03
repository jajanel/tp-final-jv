using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private AudioSource audioSource;
    public Button bouttonContinuer;
    public Button chooseYourCharacterContinue;
    public Button chooseYourCharacterCancel;

    public GameObject parametreScreen;
    public GameObject chooseYourCharacter;
    public GameObject[] characterPrefabs; // Liste des prefabs de personnages

    private string selectedCharacter;

    private Dictionary<string, string> characterMap; // Associe les noms des boutons aux noms des prefabs

    void Start()
    {

        if (SaveSystem.CheckHasSave())
        {
            bouttonContinuer.gameObject.SetActive(true);
        }
        else
        {
            bouttonContinuer.gameObject.SetActive(false);
        }

        parametreScreen.SetActive(false);
        audioSource = GetComponent<AudioSource>();

        // Initialisation de la map des personnages
        characterMap = new Dictionary<string, string>();
        foreach (var prefab in characterPrefabs)
        {
            characterMap[prefab.name] = prefab.name; // Associe les noms
        }
    }

    public void OnCharacterSelected(Button button)
    {
        if (characterMap.ContainsKey(button.name))
        {
            selectedCharacter = characterMap[button.name];
            Debug.Log($"Personnage sélectionné : {selectedCharacter}");
        }
        else
        {

            Debug.LogWarning(button.name + "Le bouton sélectionné n'est pas associé à un personnage.");
        }
    }


    public void onCancelCharacterSelection()
    {
        chooseYourCharacter.SetActive(false);
    }

    public void OnStartButtonClicked()
    {
        if (!string.IsNullOrEmpty(selectedCharacter))
        {
            PlayerPrefs.SetString("SelectedCharacter", selectedCharacter);
            SceneManager.LoadScene("Game");
            chooseYourCharacter.SetActive(false);
        }
        else
        {
            Debug.Log("Veuillez sélectionner un personnage avant de commencer.");
        }
    }
    public void OuvrirParametres()
    {
        parametreScreen.SetActive(true);
    }


    public void NouvellePartie()
    {
        chooseYourCharacter.SetActive(true);
        SaveSystem.ContinueGame = false;
        Debug.Log("Nouvelle partie");
    }

    public void Continuer()
    {
        SceneNavigator.StartGame();
        audioSource.Stop();
        SaveSystem.ContinueGame = true;
        Debug.Log("Continuer la partie");
    }

    public void Quitter()
    {
        SceneNavigator.ExitApp();
        Debug.Log("Fermeture de l'application");
    }
}