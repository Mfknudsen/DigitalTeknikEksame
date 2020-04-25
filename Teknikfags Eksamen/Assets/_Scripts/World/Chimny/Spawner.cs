using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("OSC")]
    public OSC OSC;
    [Header("Spawnable Prefabs:")]
    public string[] Keys;
    public GameObject[] Prefabs;
    [Header("World Values:")]
    public Transform SpawnPoint;

    private Dictionary<string, GameObject> SpawnablePrefabs = new Dictionary<string, GameObject>();
    private GameObject ObjectToSpawn = null;

    private void Start()
    {
        OSC.SetAddressHandler("/SpawnID", RecieveID);

        if (Keys.Length > 0 && Prefabs.Length > 0)
        {
            for (int i = 0; i < Keys.Length; i++)
            {
                if (Prefabs[i] != null && Keys[i] != null)
                {
                    SpawnablePrefabs.Add(Keys[i], Prefabs[i]);
                }
            }
        }
    }

    public void SpawnObject(string ObjID)
    {
        ObjectToSpawn = SpawnablePrefabs[ObjID];

        if (ObjectToSpawn != null)
        {
            Instantiate(ObjectToSpawn, SpawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogFormat("The object ID was not reconiced!", ObjID);
        }
    }

    public void RecieveID(OscMessage msg)
    {
        float newID = msg.GetFloat(0);

        string fromFloat = Keys[(int)Mathf.Floor(newID)];

        SpawnObject(fromFloat);
    }
}
