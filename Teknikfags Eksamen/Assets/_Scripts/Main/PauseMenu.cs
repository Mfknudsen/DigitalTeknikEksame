#region Systems
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using UnityEngine.UI;
using TMPro;
#endregion

public class PauseMenu : MonoBehaviour
{
    #region Public Data
    [Header("Menu Screens")]
    public GameObject Background;
    public GameObject MenuScreen;
    public GameObject OptionsScreen;
    public GameObject LoadingScreen;
    [Header("Settings Input")]
    public Settings Settings;
    [Header("Text Boxes")]
    public TextMeshProUGUI VolumeText;
    [Header("Scrooller")]
    public Scrollbar Scrollbar;
    #endregion

    #region Private Data
    bool IsGamePaused = false;
    float Temp_SoundVolume;
    #endregion

    private void Start()
    {
        if (MenuScreen != null && OptionsScreen != null && LoadingScreen != null && Background != null)
        {
            Background.SetActive(false);
            MenuScreen.SetActive(false);
            OptionsScreen.SetActive(false);
            LoadingScreen.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused)
            {
                UnpauseGame();
                IsGamePaused = false;
                Cursor.visible = false;
            }
            else
            {
                PauseGame();
                IsGamePaused = true;
                Cursor.visible = true;
            }
        }
    }

    public void PauseGame()
    {
        MenuScreen.SetActive(true);
        Background.SetActive(true);
    }

    public void UnpauseGame()
    {
        Background.SetActive(false);
        MenuScreen.SetActive(false);
        OptionsScreen.SetActive(false);
        LoadingScreen.SetActive(false);
    }

    public void Options()
    {
        OptionsScreen.SetActive(true);
        MenuScreen.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Apply()
    {
        OptionsScreen.SetActive(false);
        MenuScreen.SetActive(true);
    }

    public void SetVolume(float newVolume)
    {
        Temp_SoundVolume = newVolume;
        Settings.VolumeSetting = Temp_SoundVolume;
        VolumeText.text = Mathf.Floor(Settings.VolumeSetting * 100) + "%";
    }
}
