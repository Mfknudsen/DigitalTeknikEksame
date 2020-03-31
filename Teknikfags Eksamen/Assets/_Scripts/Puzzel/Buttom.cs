#region System
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion

public class Buttom : MonoBehaviour
{
    #region public DATA
    [Header("Required Input:")]
    public bool isConstant = false;
    public GameObject Visual;
    public Material OffColor, OnColor;
    [HideInInspector]
    public bool active = false;
    public Transform rest;
    [Header("TEMP BUTTOMS:")]
    public bool ACTIVATE = false;
    #endregion

    #region private DATA
    Vector3 restTransform;
    Vector3 downTransform;
    Vector3 targetTransform;
    MeshRenderer VisualRendere;
    #endregion

    void Start()
    {
        VisualRendere = Visual.GetComponent<MeshRenderer>();

        downTransform = transform.position;
        restTransform = rest.transform.position;
        if (!isConstant)
        {
            SwitchActive(false);
        }
        else
        {
            SwitchActive(true);
        }
    }

    void Update()
    {
        MoveButtom();

        if (isConstant)
        {
            if (VisualRendere.material != OnColor && active)
            {
                VisualRendere.material = OnColor;
            }
            else if (VisualRendere.material != OffColor && !active)
            {
                VisualRendere.material = OffColor;
            }
        }

        if (ACTIVATE == true)
        {
            TEMP();
        }
    }

    void MoveButtom()
    {
        if (transform.position != downTransform)
        {
            targetTransform = targetTransform - (downTransform - transform.position);
            downTransform = transform.position;
            restTransform = rest.transform.position;
        }

        if (Visual.transform.position != targetTransform)
        {
            Visual.transform.position = Vector3.Lerp(Visual.transform.position, targetTransform, 0.1f);
        }
    }

    public void SwitchActive(bool isInHand)
    {
        if (!isConstant)
        {
            if (isInHand == true)
            {
                targetTransform = downTransform;
                active = true;
            }
            else
            {
                targetTransform = restTransform;
                active = false;
            }
        }
        else
        {
            if (isInHand)
            {
                if (active == false)
                {
                    targetTransform = downTransform;
                    active = true;
                }
                else
                {
                    targetTransform = restTransform;
                    active = false;
                }
            }
        }
    }

    void TEMP()
    {
        if (active)
        {
            SwitchActive(false);
        }
        else
        {
            SwitchActive(true);
        }

        ACTIVATE = false;
    }
}
