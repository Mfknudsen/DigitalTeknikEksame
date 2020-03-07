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
    public GameObject MenuScreen;
    public GameObject OptionsScreen;
    public GameObject LoadingScreen;
    [Header("Settings Input")]
    public Settings Settings;
    [Header("Text Boxes")]
    public TextMeshProUGUI VolumeText;
    #endregion

    #region Private Data
    bool IsGamePaused = false;
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused)
            {
                UnpauseGame();
                IsGamePaused = false;
            } else
            {
                PauseGame();
                IsGamePaused = true;
            }
        }
    }

    public void PauseGame()
    {
        MenuScreen.SetActive(true);
    }

    public void UnpauseGame()
    {
        MenuScreen.SetActive(false);
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
        Settings.VolumeSetting = newVolume;
        VolumeText.text = Mathf.Floor(Settings.VolumeSetting * 100) + "%";
    }
}
