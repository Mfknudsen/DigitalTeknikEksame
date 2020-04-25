using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tabel : MonoBehaviour
{
    public Keyhole KH;
    public GameObject TextNumbers;
    public Barrel barrel;
    public Door D;
    public bool done = false;

    private void Start()
    {
        TextNumbers.SetActive(false);
    }

    void Update()
    {
        if (KH.active && !done)
        {
            barrel.active = true;

            TextNumbers.SetActive(true);

            D.gameObject.SetActive(false);

            done = true;
        }
    }
}
