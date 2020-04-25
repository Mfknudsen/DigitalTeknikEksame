using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public GameObject TextOnBook;

    private void Start()
    {
        TextOnBook.SetActive(false);
    }

    void OnDetachedFromHand()
    {
        TextOnBook.SetActive(false);
    }

    void OnAttachedToHand()
    {
        TextOnBook.SetActive(true);
    }
}
