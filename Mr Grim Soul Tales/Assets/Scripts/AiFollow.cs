using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiFollow : MonoBehaviour
{
    public float aiSpeed;
    public float lineofSight;
    public float shootingRange;
    public float fireRate = 1f;
    public float fireTime;
    public Animator animController;
    public GameObject bullet;
    public GameObject bullet2;
    public GameObject bullet3;
    public SpriteRenderer noteType;
    public GameObject bulletParent;
    public Transform player;
    public BoxCollider2D colliderAI;

    public bool onCommand;
    public bool isShooting;
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
    public void ObjectGenerator()
    {
        int noteChange = Random.Range(1, 3);
        switch(noteChange)
        {
            case 1:
                Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(bullet2, bulletParent.transform.position, Quaternion.identity);
                break;

            case 3:
                Instantiate(bullet3, bulletParent.transform.position, Quaternion.identity);
                break;

        }
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
                animController.SetBool("isDeadLeft", true);
                animController.SetBool("isDead", false);
            }
            else
            {
                animController.SetBool("isDead", true);
                animController.SetBool("isDeadLeft", false);
            }

            colliderAI.enabled = false;
            Destroy(gameObject, 1);
        }
        if (isAlive)
        {
            if (distanceFromPlayer < lineofSight && distanceFromPlayer > shootingRange)
            {
                isShooting = false;
                transform.position = Vector2.MoveTowards(this.transform.position, player.position, aiSpeed * Time.deltaTime);

            }
            else if (distanceFromPlayer <= shootingRange && fireTime < Time.time)
            {
                ObjectGenerator();
                
                isShooting = true;
                fireTime = Time.time + fireRate;
            }
        }
        //animation
        if (!isShooting)
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
           
                animController.SetBool("isAtk", false);
                animController.SetBool("isAtkLeft", true);
            }
            else
            {
                animController.SetBool("isAtk", true);
                animController.SetBool("isAtkLeft",false);
            }
        }



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
                animController.SetBool("isDeadLeft", true);
                animController.SetBool("isDead", false);
            }
            else
            {
                animController.SetBool("isDead", true);
                animController.SetBool("isDeadLeft", false);
            }

            colliderAI.enabled = false;
            Destroy(gameObject, 1);
        }

    }
}
 