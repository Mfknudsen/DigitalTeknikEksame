using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject ChestOpen, ChestClosed;
    public Buttom[] ToActivate;
    [SerializeField]
    bool active = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            ChestOpen.SetActive(true);
            ChestClosed.SetActive(false);
        }
        else
        {
            ChestOpen.SetActive(false);
            ChestClosed.SetActive(true);
        }
    }
}
