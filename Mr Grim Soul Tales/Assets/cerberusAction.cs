using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cerberusAction : MonoBehaviour
{
    public BattleTrigger battle;
    public GameObject cerbHitBox;
    public GameObject fireAtk;
    public GameObject Dialogue;
    public SpriteRenderer cerbSprite;
    public GameObject firePos;
    public GameObject isBattle;
    public GameObject cerberus;
    public Animator animController;
    public Animator zoomController;
    public PlayerMovement playerMovement;
    public bool actionBegin=false;
    public bool cerbAtkCD;
    public bool fireCD;
    public bool isAlive;
    public int life=100;
    public void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        isAlive = true;
    }
    public void delayDone()
    {
        cerberus.SetActive(false);
        playerMovement.isControlEnb = true;

    }
    public void Update()
    {
        if(life <=0)
        {
            playerMovement.isControlEnb = false;
            isBattle.SetActive(false);
            zoomController.SetBool("isZoom", true);
            isAlive = false;
            animController.SetBool("isDead", true);
            battle.cerberusMad = false;
            Dialogue.SetActive(true);
            Invoke("delayDone", 3f);
          
        }
        if(battle.cerberusMad && isAlive)
        {
            playerMovement.speed = 12;  
            if(actionBegin)
            {

                int cerbAction = Random.Range(0, 3);
                if (!cerbAtkCD)
                {
                    switch (cerbAction)
                    {
                        case 1:

                            animController.SetBool("isNormal", true);
                            cerbHitBox.SetActive(true);
                            Invoke("HitBoxDis", 0.2f);
                            cerbAtkCD = true;
                            Invoke("AttackCD", 2f);

                            break;
                        case 2:
                            int fireChance = Random.Range(1, 100);
                            if (fireChance > 70)
                            {
                                if (!fireCD)
                                {
                                    animController.SetBool("isFire", true);
                                    Instantiate(fireAtk, firePos.transform.position, firePos.transform.rotation);
                                    Invoke("FireAtkCD", 1.0f);
                                    Invoke("AttackCD", 1.2f);
                                }
                                Invoke("FireAtk", 1.2f);
                            }
                            else
                            {
                                animController.SetBool("isNormal", true);
                                cerbHitBox.SetActive(true);
                                Invoke("HitBoxDis", 0.2f);

                            }
                            break;
                        case 3:
                            animController.SetBool("isFire", false);
                            animController.SetBool("isNormal", false);
                            break;

                    }
                }
                
            }
            else
            {
                playerMovement.isControlEnb = false;
                animController.SetBool("isFire", true);
                Invoke("delayResponse", 0.5f);
            }
        }
        else
        {
            playerMovement.speed = 7;
           
            
        }
        

    }
    public void FireAtk()
    {
        animController.SetBool("isFire", false);
    }
    public void AttackCD()
    {
        cerbAtkCD = false;
    }
    public void FireAtkCD()
    {
        fireCD = false;
    }
    public void HitBoxDis()
    {
        cerbHitBox.SetActive(false);
        animController.SetBool("isNormal", false);
    }
    public void delayResponse()
    {
        playerMovement.isControlEnb = true;
        animController.SetBool("isFire", false);
        actionBegin = true;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerHit"))
        {
            life -= 5;
            Invoke("TakeDamageColor", 0.1f);
            Invoke("NormalizeColor", 0.2f);
        }

    }
    public void TakeDamageColor()
    {
        cerbSprite.color = new Color(183, 0, 0, 255);
    }
    public void NormalizeColor()
    {
        cerbSprite.color = new Color(255, 255, 255, 255);
    }
}
