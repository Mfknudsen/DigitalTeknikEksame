using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsCamera : MonoBehaviour
{
    public WireCutter W = null;
    public GameObject Camera = null;
    public GameObject Button = null;

    private void Start()
    {
        W = GetComponentInParent(typeof(WireCutter)) as WireCutter;
    }

    public void StartNow()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    public void EndNow()
    {
        Button.transform.position = new Vector3(0, -10, 0);
        Button.transform.rotation = Quaternion.Euler(Vector3.zero);

        Camera = null;
    }

    private void Update()
    {
        if (Camera != null && Button != null)
        {
            Button.transform.position = Vector3.Lerp(Button.transform.position, transform.position, 0.9f);

            Transform temp = Button.transform;
            temp.LookAt(Camera.transform.position, Button.transform.up);

            Button.transform.rotation = Quaternion.Euler(Vector3.Lerp(Button.transform.rotation.eulerAngles, temp.rotation.eulerAngles, 0.9f));

            transform.LookAt(Camera.transform, transform.up);
        }
    }
}
