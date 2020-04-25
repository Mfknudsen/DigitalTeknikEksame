using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireBoxTop : MonoBehaviour
{
    public Buttom[] Buttons;
    public bool active = false;
    public GameObject TextHighlighter;
    TextMesh TM;

    private void Start()
    {
        TM = TextHighlighter.GetComponent<TextMesh>();
        TM.text = "READY FOR INPUT";
    }

    private void Update()
    {
        if (!active)
        {
            if (!Buttons[1].active)
            {
                if (!Buttons[3].active)
                {
                    if (!Buttons[0].active)
                    {
                        if (!Buttons[2].active)
                        {

                        }
                    }
                    else
                    {
                    
                    }
                }
                else
                {
                    bool t = false;
                    foreach (Buttom b in Buttons)
                        if (!b.active)
                            t = true;

                    if (t)
                        foreach (Buttom b in Buttons)
                        {
                            TM.text = "WRONG! \nTRY AGAIN";
                            b.Reset();
                        }
                }
            }
            else
            {
                bool t = false;
                foreach (Buttom b in Buttons)
                    if (!b.active)
                        t = true;

                if (t)
                    foreach (Buttom b in Buttons)
                    {
                        TM.text = "WRONG! \nTRY AGAIN";
                        b.Reset();
                    }
            }
        }
        else Destroy(gameObject);
    }
}
