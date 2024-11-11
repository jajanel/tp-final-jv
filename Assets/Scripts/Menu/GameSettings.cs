
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
        gameState = new GameState();
        if (SaveSystem.CheckHasSave())
            gameState = SaveSystem.LoadStateFromSave();
        else gameState.difficulte = 0.5f;
        sliderDifficulter.value = gameState.difficulte;
    }

    public void SetVolume()
    {
        GameSettings.SoundVolume = sliderVolume.value;
        audioSource.volume = sliderVolume.value;
    }
    public void SetParticule()
    {
        GameSettings.ParticuleBool = toggleParticule.isOn;
    }
    public void SetDifficulter()
    {
        gameState.difficulte = sliderDifficulter.value;
        SaveSystem.SaveGame(gameState);
    }
    public void CloseButton()
    {
        parametreScreen.SetActive(false);
    }
    
}
