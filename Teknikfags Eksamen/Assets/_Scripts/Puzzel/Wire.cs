#region Systems
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion

public class Wire : MonoBehaviour
{
    #region Public Data
    public GameObject FixedWire;
    public GameObject BrokenWire;
    public bool Active = true;
    public Material[] Colors;
    public Material Highlight;
    public int ColorNumber = 0;
    public bool CanBeFixed = false;
    public int InRange = 0;
    #endregion

    private void Start()
    {
        BrokenWire.GetComponent<Renderer>().material = Colors[ColorNumber];
        FixedWire.GetComponent<Renderer>().material = Colors[ColorNumber];

        if (Active)
        {
            FixedWire.SetActive(true);
            BrokenWire.SetActive(false);
        }
        else
        {
            FixedWire.SetActive(false);
            BrokenWire.SetActive(true);
        }
    }

    private void Update()
    {
        if (InRange > 0)
        {
            BrokenWire.GetComponent<Renderer>().material = Highlight;
            FixedWire.GetComponent<Renderer>().material = Highlight;
        }
        else
        {
            BrokenWire.GetComponent<Renderer>().material = Colors[ColorNumber];
            FixedWire.GetComponent<Renderer>().material = Colors[ColorNumber];
        }
    }

    public void CutWire()
    {
        FixedWire.SetActive(false);
        BrokenWire.SetActive(true);

        Active = false;
    }

    public void FixWire()
    {
        FixedWire.SetActive(true);
        BrokenWire.SetActive(false);

        Active = true;
    }
}
