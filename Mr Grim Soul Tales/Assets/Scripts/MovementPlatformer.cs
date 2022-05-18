using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlatformer : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;

    Rigidbody2D rb2d;

    void Start()
    {

        //on initialization get the component of the gameobject 
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    void OnCollisionStay2D(Collision2D coll)

    {
        if (coll.gameObject.tag == "Ground" && (Input.GetKeyDown(KeyCode.Space)))

        {
            rb2d.AddForce(Vector3.up * jumpForce * Time.deltaTime);
        }
    }
}