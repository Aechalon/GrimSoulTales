using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiFollow1 : MonoBehaviour
{
    public float aiSpeed;
    public float lineofSight;
    public float shootingRange;


    public Animator animController;

    public GameObject HitBoxLeft;
    public GameObject HitBoxRight;
    public Transform player;
    public Collider2D aiCollider;
    public bool onCommand;

    public bool atkCD;
    public bool isAttacking;
    public bool isAlive;
    public bool lookLeft;
    public bool lookRight;
    // Start is called before the first frame update
    void Start()
    {
        onCommand = false;
        isAlive = true;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void AtkCD()
    {
        atkCD = false;
    }
    public void atkDisable()
    {
        HitBoxLeft.SetActive(false);
        HitBoxRight.SetActive(false);
        atkCD = true;
    }
    public void delayAtkLeft()
    {
        HitBoxLeft.SetActive(true);

    }
    public void delayAtkRight()
    {
        HitBoxRight.SetActive(true);

    }
    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        
        if(onCommand)
        {
            isAlive = false;
            if (transform.position.x > player.position.x)
            {

                animController.SetBool("isDead", true);
            }
            else
            {
                animController.SetBool("isDead", true);

            }

            aiCollider.enabled = false;
            Destroy(gameObject, 1);
        }
        if (isAlive)
        {
            if (distanceFromPlayer < lineofSight && distanceFromPlayer > shootingRange)
            {
                isAttacking = false;
                animController.SetBool("isAtkLeft", false);
                animController.SetBool("isAtk", false);
                transform.position = Vector2.MoveTowards(this.transform.position, player.position, aiSpeed * Time.deltaTime);

            }
            else if (distanceFromPlayer <= shootingRange )
            {
                isAttacking = true;
                if (transform.position.x > player.position.x && isAttacking)
                {
                    if (!atkCD)
                    {
                        Invoke("delayAtkLeft", 0.2f);
                        Invoke("atkDisable", 0.9f);
                        Invoke("AtkCD",1.2f);
                    }
                   
                }
                else
                {
                    if (!atkCD)
                    {
                        Invoke("delayAtkRight", 0.2f);
                        Invoke("atkDisable", 0.9f);
                        Invoke("AtkCD", 1.2f);
                    }
                }
            if (!isAttacking)
                {
                    animController.SetBool("isAtkLeft", false);
                    animController.SetBool("isAtk", false);
                    if (transform.position.x > player.position.x)
                    {
                        lookLeft = true;
                        animController.SetBool("isFlyLeft", true);


                    }
                    else
                    {
                        lookRight = true;
                        animController.SetBool("isFlyLeft", false);
                    }
                }
                else
                {

                    if (transform.position.x > player.position.x)
                    {
                        animController.SetBool("isFlyLeft", true);
                        animController.SetBool("isAtk", false);
                        animController.SetBool("isAtkLeft", true);
                    }
                    else
                    {
                        animController.SetBool("isAtk", true);
                        animController.SetBool("isFlyLeft", false);
                        animController.SetBool("isAtkLeft", false);
                    }
                }


            }
        }
        //animation
    


    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,lineofSight );
        Gizmos.DrawWireSphere(transform.position,shootingRange);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("PlayerHit"))
        {
            isAlive = false;
            if (transform.position.x > player.position.x)
            {
      
                animController.SetBool("isDead", true);
            }
            else
            {
                animController.SetBool("isDead", true);
            
            }

            aiCollider.enabled = false;
            Destroy(gameObject, 1);
        }

    }
}
 