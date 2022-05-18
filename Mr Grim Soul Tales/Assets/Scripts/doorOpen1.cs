using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpen1 : MonoBehaviour
{
    public GameManager gameManager;
    public Animation doorActive2;

   
    void OnTriggerEnter2D(Collider2D collission)
    {
        if(collission.gameObject.CompareTag("Player")&&gameManager.doorKey )
        {
            doorActive2.Play();
        }
    }
}
