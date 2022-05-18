using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiFollow2 : MonoBehaviour
{
    public float aiSpeed=5;
    public float lineofSight;
    public float shootingRange;
    public bool isAlive;

    public Animator animController;


    public bool soulAttached;
 
    public Transform player;


    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("GrimUp").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
            animController.SetBool("isMove", false);
            if (distanceFromPlayer < lineofSight && distanceFromPlayer > shootingRange)
            {
                soulAttached = false;
                animController.SetBool("isMove", true);
                transform.position = Vector2.MoveTowards(this.transform.position, player.position, aiSpeed * Time.deltaTime);

            }
            else if (distanceFromPlayer <= shootingRange)
            {
                soulAttached = true;
                animController.SetBool("isMove", false);
                aiSpeed = 10;
                transform.position = Vector2.MoveTowards(this.transform.position, player.position, aiSpeed * Time.deltaTime);


            }
            else
            {
                animController.SetBool("isMove", false);
            }

        }
        else
        {
            Destroy(gameObject, 0.9f);
            animController.SetBool("isMove", false);
            animController.SetBool("isDead", true);

        }
          
       


    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,lineofSight );
        Gizmos.DrawWireSphere(transform.position,shootingRange);
    }
}
 