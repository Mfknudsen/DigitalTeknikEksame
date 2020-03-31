using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRise : MonoBehaviour
{
    public bool ShouldRise = false;
    public float RiseSpeed = 1;
    bool Rise = false;
    float TimeToRise = 0;

    Vector3 startPos;
    Vector3 markedPos;
    Vector3 endPos;

    public GameObject EndTransform;

    private void Start()
    {
        endPos = new Vector3(0, 4.5f, 0);
    }

    private void FixedUpdate()
    {
        if (ShouldRise)
        {
            Vector3 newPos = transform.up * RiseSpeed * Time.deltaTime;

            transform.position = transform.position + newPos;

            if (!Rise)
            {
                startPos = new Vector3(-5, 0.35f, -5);

                StartCoroutine(TimeToFill());

                Rise = true;
            }
        }
    }

    IEnumerator TimeToFill()
    {
        yield return new WaitForSeconds(1);

        markedPos = transform.position;

        Vector3 dist = markedPos - startPos;

        TimeToRise = (endPos.y / dist.y) / 60;
    }
}
