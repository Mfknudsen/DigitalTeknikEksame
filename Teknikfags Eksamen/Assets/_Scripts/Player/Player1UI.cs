using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player1UI : MonoBehaviour
{
    public TextMeshProUGUI CounterText;
    public Image Img;
    public float timer = 15;
    public bool active = false;
    public float fadeSpeed;
    public bool startNow = false;

    private void Start()
    {
        CounterText.text = "Getting Ready!";

        Img.color = new Color(0, 0, 0, 0);
    }

    private void Update()
    {
        if (startNow)
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
                CounterText.gameObject.transform.parent.GetComponent<RectTransform>().localPosition = Vector2.Lerp(CounterText.gameObject.transform.parent.GetComponent<RectTransform>().localPosition, Vector2.zero, fadeSpeed * Time.deltaTime);

                Img.color = new Color(0, 0, 0, Img.color.a + fadeSpeed * Time.deltaTime);
            }
        }
    }

    public void DecreaseTimer(float min)
    {
        timer -= min;
    }
}
