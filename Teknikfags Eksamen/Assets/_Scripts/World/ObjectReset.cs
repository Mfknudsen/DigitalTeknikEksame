#region Systems
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion

public class ObjectReset : MonoBehaviour
{
    public List<GameObject> Objects = new List<GameObject>();
    List<Transform> Transforms = new List<Transform>();

    void Start()
    {
        foreach (GameObject O in Objects)
        {
            Transforms.Add(O.transform);
        }
    }

    public void ResetObjectTransform()
    {
        for (int i = 0; i < Objects.Count; i++)
        {
            Objects[i].transform.position = Transforms[i].position;
            Objects[i].transform.rotation = Transforms[i].rotation;
        }
    }

    void OnTriggerExit(Collider O)
    {
        for (int i = 0; i < Objects.Count; i++)
        {
            if (Objects[i] == O)
            {
                Objects[i].transform.position = Transforms[i].position;
                Objects[i].transform.rotation = Transforms[i].rotation;
            }
        }
    }
}
