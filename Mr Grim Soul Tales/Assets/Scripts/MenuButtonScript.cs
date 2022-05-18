using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonScript : MonoBehaviour
{
    public GameObject inGameSettings;
    public PlayerMovement playerMovement;
   public void OpenMenu()
    { 
        inGameSettings.SetActive(true);
        playerMovement.isControlEnb = false;
    }
}
