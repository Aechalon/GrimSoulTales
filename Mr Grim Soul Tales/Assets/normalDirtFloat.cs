using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalDirtFloat : MonoBehaviour
{
    public Animation dirtFloat;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            dirtFloat.Play();
        }
    }
}
