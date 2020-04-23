using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject ChestOpen, ChestClosed;
    public ButtonCompination[] ToActivate;
    public bool active = false;
    bool hasOpened = false;
    public GameObject Key;
    public Keyhole Keyhole;
    void Start()
    {
        ChestClosed.SetActive(true);
        ChestOpen.SetActive(false);
    }

    void Update()
    {
        if (active)
        {
            if (!hasOpened)
            {
                ChestOpen.SetActive(true);
                ChestClosed.SetActive(false);

                GameObject k = Instantiate(Key);
                k.transform.position = transform.position + new Vector3(0, 1, 0);
                k.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));

                Keyhole.correctKey = k;
                k.GetComponent<Key>().keyword = Keyhole.keyword;

                foreach (ButtonCompination BC in ToActivate)
                    BC.gameObject.SetActive(false);

                hasOpened = true;
            }
        }
        else
        {
            CheckActives();
        }
    }

    void CheckActives()
    {
        bool a = true;

        foreach (ButtonCompination B in ToActivate)
        {
            if (!B.active)
                a = false;
        }

        active = a;
    }
}
