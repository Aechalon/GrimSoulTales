using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
   
    // Start is called before the first frame update

    // Update is called once per frame
    public void Start()
    {
 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
     
        if (collision.gameObject.CompareTag("Bullet"))
        {

            Destroy(collision.gameObject);
        }


    }

}