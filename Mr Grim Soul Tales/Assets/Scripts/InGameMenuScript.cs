using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenuScript : MonoBehaviour
{
    public GameObject cont;
    public GameObject homeSet;
    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    public void Continue()
    {
        cont.SetActive(false);
        playerMovement.isControlEnb = true;
    }
    public void Home()
    {
        homeSet.SetActive(true);
   
    }
}
