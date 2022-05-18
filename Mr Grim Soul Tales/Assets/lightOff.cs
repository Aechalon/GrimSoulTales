using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightOff : MonoBehaviour
{
  
    public GameObject torch;
    public Animation rockMove;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerHit"))
        {
     
            torch.gameObject.SetActive(false);
            rockMove.Play();
        }
    }

}
