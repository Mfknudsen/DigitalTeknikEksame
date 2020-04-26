using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireBox : MonoBehaviour
{
    public Wire[] Wires;
    public WaterRise Water;
    public Player1UI UI;
    [Range(1, 3)]
    public int CorrectWire = 0;
    private bool active = false;
    private bool b1 = true, b2 = true, b3 = true;
    private bool firstWire = false, secWire = false;
    private int n = 0;

    private void Update()
    {
        for (int i = 0; i < Wires.Length; i++)
        {
            if (i + 1 == 1 && CorrectWire != 1)
                b1 = Wires[i].active;
            if (i + 1 == 2 && CorrectWire != 2)
                b2 = Wires[i].active;
            if (i + 1 == 3 && CorrectWire != 3)
                b3 = Wires[i].active;
        }

        if (!active)
        {
            if (Wires[CorrectWire - 1].active)
            {
                if (!firstWire && (!b1 || !b2 || !b3))
                {
                    if (!b1)
                        n = 1;
                    if (!b2)
                        n = 2;
                    if (!b3)
                        n = 3;

                    Water.GetComponent<WaterRise>().IncreaseWaterLevel(2);
                    UI.DecreaseTimer(2);

                    firstWire = true;
                }
                else if (!secWire && ((n != 1 && !b1) || (n != 2 && !b2) || (n != 3 && !b3)))
                {
                    Water.GetComponent<WaterRise>().IncreaseWaterLevel(2);
                    UI.DecreaseTimer(2);

                    secWire = true;
                }
            }
            else
            {
                active = true;
            }
        }
        else
        {
            Water.gameObject.SetActive(false);

            UI.active = true;
        }
    }
}
