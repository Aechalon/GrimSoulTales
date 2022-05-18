using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   
public class HitBar : MonoBehaviour
{
    public GameObject miniGamePanel;
    public GameManager gameManager;

    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    public float speed = 1.5f;
    public bool isGoingLeft = false;
    public bool onPlay;
    public bool gameEnd;
    
    // Update is called once per frame

    public void minigameonPlay()
    {
        onPlay = false;
    }
    public void Start()
    {
 
        playerMovement.isControlEnb = false;
        
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && onPlay)
        {
            onPlay = false;
            gameEnd = true;
            miniGamePanel.SetActive(false);
            gameManager.miniGameStart = false;
            playerMovement.isControlEnb = true;
            gameManager.isThere = false;
        }


        if (onPlay)
        {
            if (isGoingLeft == false)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.right * -speed * Time.deltaTime;
            }


        }



            /*  if ((transform.position.x > -307.1 && transform.position.x < -210.4) || (transform.position.x > -8.2 && transform.position.x < -82.8))
              {

                  gameManager.miniGameScore = 50;
              }
              if ((transform.position.x > -210.4 && transform.position.x < -120.4) || (transform.position.x > -99.4 && transform.position.x < -8.5))
              {

                  gameManager.miniGameScore = 100;
              }
      */

        }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Right"))
        {
            isGoingLeft = true;
        }

        if (collision.gameObject.CompareTag("Left"))
        {
            isGoingLeft = false ;
        }
        if (collision.gameObject.CompareTag("YellowBar"))
        {
            gameManager.miniGameScore = 50;
        }
        if (collision.gameObject.CompareTag("WhiteBar"))
        {
            gameManager.miniGameScore = 25;
        }
        if (collision.gameObject.CompareTag("GreenBar"))
        {
            gameManager.miniGameScore = 100;
        }
    }


}
 
   
