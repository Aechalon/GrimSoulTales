using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBarScore : MonoBehaviour
{
    public GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("WhiteBar"))
        {
            Debug.Log("detect");
            gameManager.miniGameScore = 50;
        }
        if (collision.gameObject.CompareTag("YellowBar"))
        {
            gameManager.miniGameScore = 75;
        }
        if (collision.gameObject.CompareTag("GreenBar"))
        {
            gameManager.miniGameScore = 100;
        }
    }

}
