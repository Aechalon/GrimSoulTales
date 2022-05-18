using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class nextChapt : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameObject gameOverPanel;
    public GameObject inGameSet;
    public GameObject endPanel;
    public Animation tBC;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerMovement.isControlEnb = false;
            endPanel.SetActive(true);
            tBC.Play();
            Invoke("delayGameOver", 3f);
        }
    }
    public void delayGameOver()
    {
        gameOverPanel.SetActive(true);
        inGameSet.SetActive(false);
       
    }

}
