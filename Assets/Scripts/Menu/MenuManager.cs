using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private AudioSource audioSource;
    public Button bouttonContinuer;
    public GameObject parametreScreen;
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
    public void NouvellePartie()
    {
        SceneNavigator.StartGame();
        audioSource.Stop();
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
