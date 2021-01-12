﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer mixer;
    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;
    public Dropdown textureDropdown;
    public Dropdown aaDropdown;
    public Slider volumeSlider;
    public Slider slider;
    public GameObject UI;
    Resolution[] resolutions;

    // Start is called before the first frame update
    void Start()
    {

        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;


        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " +
                     resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width
                  && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
        slider.value = PlayerPrefs.GetFloat("MasterVol", 0.75f);
        Scene scene = SceneManager.GetActiveScene();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    // Settings
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MasterVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MasterVol", sliderValue);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,
                  resolution.height, Screen.fullScreen);
    }
    public void SetTextureQuality(int textureIndex)
    {
        QualitySettings.masterTextureLimit = textureIndex;
        qualityDropdown.value = 4;
    }
    public void SetAntiAliasing(int aaIndex)
    {
        QualitySettings.antiAliasing = aaIndex;
        qualityDropdown.value = 4;
    }
    public void SetQuality(int qualityIndex)
    {
        if (qualityIndex != 4) // if the user is not using 
                               //any of the presets
            QualitySettings.SetQualityLevel(qualityIndex);
        switch (qualityIndex)
        {
            case 0: // quality level - low
                textureDropdown.value = 1;
                aaDropdown.value = 0;
                break;
            case 1: // quality level - medium
                textureDropdown.value = 1;
                aaDropdown.value = 1;
                break;
            case 2: // quality level - high
                textureDropdown.value = 0;
                aaDropdown.value = 2;
                break;
            case 3: // quality level - ultra
                textureDropdown.value = 0;
                aaDropdown.value = 2;
                break;
        }

        qualityDropdown.value = qualityIndex;
    }

    public void ExitGame() // Exit game
    {
        Application.Quit();
    }
    public void SaveSettings() // Player Preferences
    {
        PlayerPrefs.SetInt("QualitySettingPreference",
                   qualityDropdown.value);
        PlayerPrefs.SetInt("ResolutionPreference",
                   resolutionDropdown.value);
        PlayerPrefs.SetInt("TextureQualityPreference",
           textureDropdown.value);
        PlayerPrefs.SetInt("AntiAliasingPreference",
                   aaDropdown.value);
        PlayerPrefs.SetInt("FullscreenPreference",
                   Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetFloat("VolumePreference",
                   slider.value);
    }
    public void LoadSettings(int currentResolutionIndex) // Load preferences
    {
        if (PlayerPrefs.HasKey("QualitySettingPreference"))
            qualityDropdown.value =
                         PlayerPrefs.GetInt("QualitySettingPreference");
        else
            qualityDropdown.value = 3;
        if (PlayerPrefs.HasKey("ResolutionPreference"))
            resolutionDropdown.value =
                         PlayerPrefs.GetInt("ResolutionPreference");
        else
            resolutionDropdown.value = currentResolutionIndex;
        if (PlayerPrefs.HasKey("TextureQualityPreference"))
            textureDropdown.value =
                         PlayerPrefs.GetInt("TextureQualityPreference");
        else
            textureDropdown.value = 0;
        if (PlayerPrefs.HasKey("AntiAliasingPreference"))
            aaDropdown.value =
                         PlayerPrefs.GetInt("AntiAliasingPreference");
        else
            aaDropdown.value = 1;
        if (PlayerPrefs.HasKey("FullscreenPreference"))
            Screen.fullScreen =
            Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        else
            Screen.fullScreen = true;
        if (PlayerPrefs.HasKey("VolumePreference"))
            volumeSlider.value =
                        PlayerPrefs.GetFloat("VolumePreference");
        else
            volumeSlider.value =
                        PlayerPrefs.GetFloat("VolumePreference");
    }

    // Load game scene
    public void GameScene()
    {
        SceneManager.LoadScene("Game");
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Game")
        {
            UI.SetActive(false);
        }
        if (scene.name == "Intro Video")
        {
            UI.SetActive(false);
        }
    }


}
