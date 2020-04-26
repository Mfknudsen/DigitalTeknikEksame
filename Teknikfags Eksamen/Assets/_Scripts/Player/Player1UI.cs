using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player1UI : MonoBehaviour
{
    public TextMeshProUGUI CounterText;
    public float timer = 15;
    public bool active = false;

    private void Start()
    {
        CounterText.text = "15";
    }

    private void Update()
    {
        if (!active)
        {
            timer -= Time.deltaTime / 60;
            string timeType = " min.";
            if (timer < 1)
                timeType = " sec.";

            CounterText.text = "Time Left: " + "\n" + timer.ToString("0.0") + timeType;
        }
        else
        {
            CounterText.text = "VICTORY!";
        }
    }

    public void DecreaseTimer(float min)
    {
        timer -= min;
    }
}
