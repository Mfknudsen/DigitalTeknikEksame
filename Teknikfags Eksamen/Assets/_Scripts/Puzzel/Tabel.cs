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
    public GameObject[] Areas;

    private void Start()
    {
        TextNumbers.SetActive(false);

        foreach (GameObject G in Areas)
            G.SetActive(false);
    }

    void Update()
    {
        if (KH.active && !done)
        {
            barrel.active = true;

            TextNumbers.SetActive(true);

            D.transform.rotation = Quaternion.Euler(D.OpenTransform);


            foreach (GameObject G in Areas)
                G.SetActive(true);

            done = true;
        }
    }
}
