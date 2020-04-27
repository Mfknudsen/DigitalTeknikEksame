using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireBoxTop : MonoBehaviour
{
    public GameObject[] Wires;
    public Buttom[] Buttons;
    public bool active = false;
    public GameObject TextHighlighter;
    public bool b1 = false, b2 = false, b3 = false, b4 = false;
    TextMesh TM;
    public GameObject WC;

    private void Start()
    {
        foreach (GameObject g in Wires)
            g.SetActive(false);

        TM = TextHighlighter.GetComponent<TextMesh>();
        TM.text = "Basement Door Lock System";
    }

    private void Update()
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            if (i == 0)
                b1 = Buttons[i].active;
            if (i == 1)
                b2 = Buttons[i].active;
            if (i == 2)
                b3 = Buttons[i].active;
            if (i == 3)
                b4 = Buttons[i].active;
        }

        if (!active)
        {
            if (b2)
            {
                if (b4)
                {
                    if (b1)
                    {
                        if (b3)
                        {
                            active = true;
                        }
                    }
                    else if (b3)
                    {
                        ResetButtons();
                    }
                }
                else if (b1 || b3)
                {
                    ResetButtons();
                }
            }
            else if (b1 || b3 || b4)
            {
                ResetButtons();
            }
        }
        else
        {
            foreach (GameObject g in Wires)
                g.SetActive(true);

            Destroy(gameObject);
        }
    }

    void ResetButtons()
    {
        foreach (Buttom B in Buttons)
        {
            B.active = true;
            B.SwitchActive(true);
        }
    }
}
