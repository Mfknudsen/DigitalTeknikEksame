using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRise : MonoBehaviour
{
    public bool ShouldRise = false;
    public float RiseSpeed = 1;
    float TimeToRise = 0;
    float toAdd = 0;

    Vector3 startPos = Vector3.zero;
    Vector3 markedPos = Vector3.zero;
    Vector3 endPos = Vector3.zero;

    public GameObject EndTransform;

    private void Start()
    {
        endPos = new Vector3(0, 4.5f, 0);

        float DistToTravel = endPos.y - transform.position.y;
        RiseSpeed = DistToTravel / (15 * 60);
    }

    private void Update()
    {
        if (ShouldRise)
        {
            Vector3 newPos = transform.up * RiseSpeed * Time.deltaTime + (transform.up * toAdd * RiseSpeed);
            transform.position = transform.position + newPos;

            if (toAdd > 0)
            {
                Debug.Log(toAdd);
                toAdd = 0;
            }
        }
    }

    public void IncreaseWaterLevel(float min)
    {
        toAdd = min * 60f;
    }
}
