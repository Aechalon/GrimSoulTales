using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneScript : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject dialogueCall;
    public Animator cutsceneAnimator;
    public GrimDialogue grimDialogue;
    public void Start()
    {
        gameManager.isCutscene = true;
    }
    void Update()
    {
        if(gameManager.isCutscene)
        {
            cutsceneAnimator.SetBool("CutscenePlay", true);
            dialogueCall.SetActive(true);
            
        }
        if(grimDialogue.skip)
        {
            cutsceneAnimator.SetBool("CutscenePlay", false);
        }
    }
}
