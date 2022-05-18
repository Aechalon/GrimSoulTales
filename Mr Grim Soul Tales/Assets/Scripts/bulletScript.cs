using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    GameObject player;
    public float bulletSpeed;
    Rigidbody2D bulletRb;
    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (player.transform.position - transform.position).normalized * bulletSpeed;
        bulletRb.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 1);
        
    }

    // Update is called once per frame
    
}
