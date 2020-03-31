using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawnable Prefabs:")]
    public string[] Keys;
    public GameObject[] Prefabs;
    [Header("World Values:")]
    public Transform SpawnPoint;

    private Dictionary<string, GameObject> SpawnablePrefabs = new Dictionary<string, GameObject>();
    private GameObject ObjectToSpawn = null;

    private void Start()
    {
        if (Keys.Length > 0 && Prefabs.Length > 0)
        {
            for (int i = 0; i < Keys.Length; i++)
            {
                if (Prefabs[i] != null && Keys[i] != null)
                {
                    SpawnablePrefabs[Keys[i]] = Prefabs[i];
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

    [Serializable]
    public struct KeyAndPrefab
    {

    }
}
