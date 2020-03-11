using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public string[] Keys;
    public GameObject[] Prefabs;
    public Transform SpawnPoint;

    private Dictionary<string, GameObject> SpawnablePrefabs;
    private GameObject ObjectToSpawn = null;
    
    private void Start()
    {
        for (int i = 0; i < Keys.Length; i++)
        {
            SpawnablePrefabs[Keys[i]] = Prefabs[i]; 
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
