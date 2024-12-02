
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static float SoundVolume
    {
        get => PlayerPrefs.GetFloat("SoundVolume", defaultValue: 1f);
        set => PlayerPrefs.SetFloat("SoundVolume", value);
    }
    public static bool ParticuleBool
    {
        get => PlayerPrefs.GetInt("ParticuleBool", defaultValue: 1) == 1 ? true : false;
        set => PlayerPrefs.SetInt("ParticuleBool", value ? 1 : 0);
    }
    public static float Difficulter
    {
        get => PlayerPrefs.GetFloat("Difficulter", defaultValue: 0.5f);
        set => PlayerPrefs.SetFloat("Difficulter", value);
    }


}
