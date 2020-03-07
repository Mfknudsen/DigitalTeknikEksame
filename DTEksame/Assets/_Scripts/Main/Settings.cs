#region Systems
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion

public class Settings : MonoBehaviour
{
    #region Public Data
    public float VolumeSetting = 0.0f;
    [HideInInspector]
    public List<AudioSource> AudioSources = new List<AudioSource>();
    #endregion

    #region Private Data
    bool GameReady = false;
    #endregion

    void Start()
    {
        GameObject G = GameObject.FindGameObjectWithTag("Login");
        G.GetComponent<Login>().GetOptions(this);

        GameObject[] GetSources = GameObject.FindGameObjectsWithTag("AudioPlayers");

        foreach (GameObject GO in GetSources)
        {
            if (GO.GetComponent<AudioSource>() != null)
            {
                AudioSources.Add(GO.GetComponent<AudioSource>());
            }
        }

        foreach (AudioSource AS in AudioSources)
        {
            AS.volume = VolumeSetting;
        }
    }

    void Update()
    {
        if (AudioSources.Count != 0)
        {
            if (AudioSources[0].volume != VolumeSetting)
            {
                foreach (AudioSource AS in AudioSources)
                {
                    AS.volume = VolumeSetting;
                }
            }
        }

        Debug.Log(VolumeSetting);
    }

    public void SetSettingsByOptions(float VolumeOption)
    {
        VolumeSetting = VolumeOption;
    }
}
