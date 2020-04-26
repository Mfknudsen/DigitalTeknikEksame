#region Systems
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#endregion

public class Login : MonoBehaviour
{
    #region Public Data
    [Header("Resources")]
    public MP MP;
    [HideInInspector]
    public bool MPLoadComplete = false;
    [Header("Screens")]
    public GameObject MenuScreen;
    public GameObject OptionsScreen;
    public GameObject LoadingScreen;
    [Header("TextFields")]
    public TextMeshProUGUI VolumeText;
    public TextMeshProUGUI LoadingProgressText;
    [Header("Camera")]
    public GameObject Cam;
    public bool VRCHECK = false;
    #endregion

    #region Private Data
    private float SoundLevel = 1.0f;
    private AsyncOperation asyncLoad = null;
    #endregion

    void Start()
    {
        if (MP == null)
        {
            MP = GetComponent<MP>();

            if (MP == null)
            {
                MP = gameObject.AddComponent<MP>();
            }
        }

        OptionsScreen.SetActive(false);
        MenuScreen.SetActive(true);
        LoadingScreen.SetActive(false);

        VolumeText.text = (SoundLevel * 100) + "%";
    }

    void Update()
    {
        if (asyncLoad != null)
        {
            LoadingProgressText.text = Mathf.Floor(asyncLoad.progress * 100) + "%";
        }
    }

    public void LoginNow()
    {
        MenuScreen.SetActive(false);
        LoadingScreen.SetActive(true);

        MP.StartConnection();

        StartCoroutine(LoadMain());
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
        SoundLevel = newVolume;
        VolumeText.text = Mathf.Floor(SoundLevel * 100) + "%";
    }

    public void GetOptions(Settings S)
    {
        S.VolumeSetting = SoundLevel;
    }

    public IEnumerator LoadMain()
    {
        asyncLoad = SceneManager.LoadSceneAsync("Main", LoadSceneMode.Additive);

        Cam.GetComponent<AudioListener>().enabled = false;

        while (!asyncLoad.isDone)
            yield return null;

        while (!MPLoadComplete)
            yield return null;

        GameObject G_Temp = GameObject.FindGameObjectWithTag("SettingsManager");

        if (G_Temp != null)
            G_Temp.GetComponent<Settings>().SetSettingsByOptions(this);

        GameObject.FindGameObjectWithTag("UI_Counter").GetComponent<Player1UI>().startNow = true;

        Cursor.lockState = CursorLockMode.None;
        asyncLoad = null;
    }
}