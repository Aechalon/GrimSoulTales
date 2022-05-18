using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollect3 : MonoBehaviour
{
    public GameManager gameManager;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            gameManager.level1Item3 = true;
            this.gameObject.SetActive(false);
        }
    }
}
