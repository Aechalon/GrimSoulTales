using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public PlayerMovement thePlayer;

    private Vector3 lastPlayerPosition;
    private float distanceToMovex;
  
  

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMovement>();
        lastPlayerPosition = thePlayer.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        distanceToMovex = thePlayer.transform.position.x - lastPlayerPosition.x;
       

        transform.position = new Vector3(transform.position.x + distanceToMovex, transform.position.y, transform.position.z);

        lastPlayerPosition = thePlayer.transform.position;
    }
}
