using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    public GameObject angel;
    public GameObject devil;
    public bool spawned;
    public float lineofSight;


    void Start()
    {
       
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public Transform player;

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

    
            if (distanceFromPlayer < lineofSight)
            {
            Destroy(gameObject, 1);
            if (!spawned)
            {
                Invoke("spawn", .9f);
                spawned = true;
            }

        }
         
        
    }
    public void spawn()
    {
        Instantiate(angel, transform.position, transform.rotation);
        Instantiate(devil, transform.position, transform.rotation);
      
    }
        private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineofSight);

    }


}
