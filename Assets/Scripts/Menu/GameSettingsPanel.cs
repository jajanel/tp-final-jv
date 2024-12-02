
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettingsPanel : MonoBehaviour
{
    private AudioSource audioSource;
    public Slider sliderVolume;
    public Toggle toggleParticule;
    public Slider sliderDifficulter;
    public GameObject parametreScreen;
    private GameState gameState;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = GameSettings.SoundVolume;
        sliderVolume.value = GameSettings.SoundVolume;
        toggleParticule.isOn = GameSettings.ParticuleBool;
        sliderDifficulter.value = GameSettings.Difficulter;
    }

    public void SetVolume()
    {
        GameSettings.SoundVolume = sliderVolume.value;
        audioSource.volume = sliderVolume.value;
        Debug.Log("Volume : " + GameSettings.SoundVolume);
    }
    public void SetParticule()
    {
        GameSettings.ParticuleBool = toggleParticule.isOn;
        Debug.Log("Particule : " + GameSettings.ParticuleBool);
    }
    public void SetDifficulter()
    {
        GameSettings.Difficulter = sliderDifficulter.value;
    }
    public void CloseButton()
    {
        parametreScreen.SetActive(false);
        Debug.Log("Fermeture des paramètres");
    }
    
}
