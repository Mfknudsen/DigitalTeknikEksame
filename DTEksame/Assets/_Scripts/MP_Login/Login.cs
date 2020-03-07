#region Systems
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#endregion

public class Login : MonoBehaviour {
    #region Public Data
    [Header("Screens")]
    public GameObject MenuScreen;
    public GameObject OptionsScreen;
    [Header("TextFields")]
    public TextMeshProUGUI VolumeText;
    #endregion

    #region Private Data
    private float SoundLevel = 1.0f;
    #endregion

    void Start () {
        OptionsScreen.SetActive (false);
        MenuScreen.SetActive (true);

        VolumeText.text = (SoundLevel*100)+"%";
    }
    
    public void LoginNow () {
        StartCoroutine (LoadMainAsync ());
    }

    public void Options () {
        OptionsScreen.SetActive (true);
        MenuScreen.SetActive (false);
    }

    public void Exit () {
        Application.Quit ();
    }

    public void Apply () {
        OptionsScreen.SetActive (false);
        MenuScreen.SetActive (true);
    }

    public void SetVolume(float newVolume)
    {
        SoundLevel = newVolume;
        VolumeText.text = Mathf.Floor(SoundLevel * 100) + "%";
    }

    public void GetOptions(Settings S)
    {
        S.VolumeSetting = SoundLevel;
    }

    IEnumerator LoadMainAsync () {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync ("Main");
        
        while (!asyncLoad.isDone) {
            yield return null;
        }
    }
}