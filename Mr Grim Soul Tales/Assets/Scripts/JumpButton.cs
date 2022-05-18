using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : MonoBehaviour
{

    public Rigidbody2D myRigidBody;
    public Collider2D myCollider;
    public bool isGrounded;
    public bool jumping;

    public int jumpforce = 19;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();


    }
    void Update()
    {
        Jump();

        if (jumping)
        {


            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpforce);
            jumping = false;
        }
    }
    public void Jump()
    {
        jumping = true;
    }
}
