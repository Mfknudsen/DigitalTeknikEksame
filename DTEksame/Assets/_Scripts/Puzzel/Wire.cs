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
    #endregion

    private void Start()
    {
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
