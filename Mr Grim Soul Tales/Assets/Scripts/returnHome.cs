using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class returnHome : MonoBehaviour
{
    public GameObject homePanel;
    public GameObject gameoverPanel;
    public PlayerMovement playerMovement;
    public void ReturnHome()
    {
        gameoverPanel.SetActive(false);
        homePanel.SetActive(true);
        if (!playerMovement.isControlEnb)
        {
            SceneManager.LoadScene("Level 1");
            playerMovement.isControlEnb = true;

        }

    }
}
