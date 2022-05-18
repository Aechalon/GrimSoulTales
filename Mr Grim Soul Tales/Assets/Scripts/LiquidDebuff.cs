using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidDebuff : MonoBehaviour
{
    public PlayerMovement playerMovementScript;

    public void Start()
    {

        playerMovementScript = FindObjectOfType<PlayerMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMovementScript.speed = playerMovementScript.speed - 2;
        }
        

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMovementScript.speed = 7;
        }


    }
}
