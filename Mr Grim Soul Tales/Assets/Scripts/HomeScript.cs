using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HomeScript : MonoBehaviour
{
   
    public GameObject home;
    public PlayerMovement playerMovement;
    public Animation startFadeAnim;
    public GameObject startFade;
    public GameObject inGamePanel;
    public GameObject inGameSettings;
    public GameObject gameOverPanel;
    public GameObject blackScreenCanvas;
    public GameObject cutsceneCanvas;
    public GameObject txtWriterCanvas;
    public GameManager gameManager;

   
    public void StartGame()
    {
        
        if (!gameManager.isCutscene)
        {
            home.SetActive(false);
            blackScreenCanvas.SetActive(true);
            cutsceneCanvas.SetActive(true);
            startFade.SetActive(true);
            startFadeAnim.Play();
            inGameSettings.SetActive(false);
            txtWriterCanvas.SetActive(true);
            gameOverPanel.SetActive(false);
            gameManager.isCutscene = true;
            playerMovement.isControlEnb = false;
            playerMovement.gameStart = false;
        
        }
        else
        {

            home.SetActive(false);
            inGamePanel.SetActive(true);
            inGameSettings.SetActive(false);
            gameOverPanel.SetActive(false);
            playerMovement.isControlEnb = true;
            playerMovement.gameStart = true;
        }

    }
   
    public void QuitGame()
    {
        Application.Quit();

    }

}
