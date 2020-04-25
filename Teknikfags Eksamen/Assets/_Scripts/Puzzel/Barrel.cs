using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public bool active = false;
    bool hasOpened = false;
    public Vector3 OpenPos = Vector3.zero;

    void Update()
    {
        if (active && !hasOpened)
        {
            transform.localPosition = OpenPos;

            Destroy(this, 1);
        }
    }
}
