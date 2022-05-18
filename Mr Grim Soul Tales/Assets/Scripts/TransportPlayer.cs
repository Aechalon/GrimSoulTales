using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TransportPlayer : MonoBehaviour
{
    public GameManager gameManager;
    public AiFollow2 aiFollow;
    public PlayerMovement playerMovement;
    public Text txtGrim;
    public Transform teleportTo;
    public Transform player;
    public Transform soul;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        soul = GameObject.FindGameObjectWithTag("Soul").transform;
        playerMovement = FindObjectOfType<PlayerMovement>();
        //  player = FindObjectOfType<Transform>()
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (aiFollow.soulAttached)
            {
                player.transform.position = teleportTo.transform.position;
                aiFollow.transform.position = teleportTo.transform.position;
                gameManager.onLevel += 1;
                playerMovement.tempHp = playerMovement.maxHp;
                playerMovement.HealthBar.SetHealth(playerMovement.maxHp);

            }
            else
            {
                txtGrim.text = "Can't continue without" +
                               "\n the lost soul.";
                Invoke("textClear", 1.2f);

            }

            
        }
    }
    public void textClear()
    {
        txtGrim.text = "";
    }
}
