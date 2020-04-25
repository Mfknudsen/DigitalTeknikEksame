using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : MonoBehaviour
{
    private Rigidbody RB;
    public GameObject PasswordBook;
    private float lastFrameY = 0;
    public bool Drop = false;
    int inHand = 0;

    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if ((RB.velocity.y - lastFrameY) > 5 && inHand == 0)
        {
            if (Drop)
            {
                GameObject Book = Instantiate(PasswordBook);
                Book.transform.position = transform.position;
                Book.transform.rotation = transform.rotation;
            }
            Destroy(gameObject);
        }
        else
            lastFrameY = RB.velocity.y;
    }

    void OnDetachedFromHand()
    {
        inHand--;
    }

    void OnAttachedToHand()
    {
        inHand++;
    }
}
