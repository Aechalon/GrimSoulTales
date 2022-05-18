using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorKey : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            gameManager.doorKey = true;
        }
    }
}
