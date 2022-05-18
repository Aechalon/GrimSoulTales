using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpen : MonoBehaviour
{
    public dropItem dropItem;
    public Animation doorActive;

    public void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(dropItem.collected && collision.gameObject.CompareTag("Player") )
        {
            doorActive.Play();
        }
    }
}
