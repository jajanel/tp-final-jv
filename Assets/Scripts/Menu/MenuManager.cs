using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private AudioSource audioSource;
    public Button bouttonContinuer;
    public Button chooseYourCharacterContinue;
    public Button chooseYourCharacterCancel;

    public GameObject parametreScreen;
    public GameObject chooseYourCharacter;

    // Start is called before the first frame update
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
    }

    public void OpenSetting()
    {
        parametreScreen.SetActive(true);
    }

    public void CancelChooseYourCharacter()
    {
        chooseYourCharacter.SetActive(false);

    }


    public void StartChooseYourCharacter()
    {

    }


    public void NouvellePartie()
    {
        //Ici ouvrir la fenêtre qui permet de choisir son personnage
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
