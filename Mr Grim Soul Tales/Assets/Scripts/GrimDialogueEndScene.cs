using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GrimDialogueEndScene : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private Text grimTxt;
    private Text soulTxt;

    

    public GameObject grimDialogueBox;
    public GameObject soulDialogueBox;

    public GameObject inGameSettings;

    public GameObject messagePanel;
    public float time;
    public float maxOut;
    public bool skip;
    public bool curDialogue;
    public bool onCutscreen;

    public void Update()
    {
        if (curDialogue)
        {
            if (time > maxOut) //1.8f
            {
                FalseDialogue();

            }
            else
            {
                time += Time.deltaTime;
            }
        }
        if (onCutscreen)
        {
            if (Input.GetKey(KeyCode.Space))
            {
         
                inGameSettings.SetActive(true);

             
                messagePanel.SetActive(false);
                onCutscreen = false;
                skip = true;
                Invoke("delayControl", 0.2f);
              
            }
        }
       
        
       

    }
    private void Awake()
    {
        grimTxt = transform.Find("GrimDialogue").Find("message").GetComponent<Text>();
        soulTxt = transform.Find("SoulDialogue").Find("message").GetComponent<Text>();

        grimDialogueBox.gameObject.SetActive(false);
        soulDialogueBox.gameObject.SetActive(false);

        onCutscreen = true;
            StartCoroutine(GrimLines());
     

    }
    public void FalseDialogue()
    {
        grimDialogueBox.gameObject.SetActive(false);
        soulDialogueBox.gameObject.SetActive(false);

        time = 0;
        curDialogue = false;
    }
    public void CurrentDialogue(float maxOut)
    {
        this.maxOut = maxOut;
        curDialogue = true;

    }
    public void gameStart()
    {
        inGameSettings.SetActive(true);
        messagePanel.SetActive(false);
        onCutscreen = false;
        playerMovement.isControlEnb = true;

    }
    public void delayControl()
    {
        playerMovement.isControlEnb = true;
        skip = false;
    }

    IEnumerator GrimLines()
    {

        grimDialogueBox.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.01f);
        TextWriter.AddWriter_Static(grimTxt, "You've done your job well Cerberus", 0.04f, true);
        yield return new WaitForSeconds(2f);
        TextWriter.AddWriter_Static(grimTxt, "Rest for now... I'll return your soul later", 0.04f, true);
        CurrentDialogue(3.5f);
        gameStart();
        


}



    /* Sample Lines
      *       yield return new WaitForSeconds(3);
        DialogueBox.SetActive(true);
        TextWriter.AddWriter_Static(msgTxt, "Ahh that was a long vacation..", 0.05f,true);
        yield return new WaitForSeconds(2);
        TextWriter.AddWriter_Static(msgTxt, "There be hope filled the cycle of life", 0.05f, true);
        yield return new WaitForSeconds(2);
        TextWriter.AddWriter_Static(msgTxt, "was managed properly...", 0.05f, true);
        yield return new WaitForSeconds(2);
        soulDialogueBox.SetActive(true);
        DialogueBox.SetActive(false);
        TextWriter.AddWriter_Static(soulTxt, "GRIM! YOURE BACK! COME QUICK!!", 0.05f, true);
        yield return new WaitForSeconds(2);
        soulDialogueBox.SetActive(false);
        DialogueBox.SetActive(true);
        TextWriter.AddWriter_Static(msgTxt, "WHAT? WHAT NOW??", 0.05f, true);
        yield return new WaitForSeconds(2);
        soulDialogueBox.SetActive(false);
        DialogueBox.SetActive(false);
        yield return new WaitForSeconds(4);
        animController.SetBool("isCut", false);
        animController.SetBool("isClose", true);
        DialogueBox.SetActive(true);
        TextWriter.AddWriter_Static(msgTxt, "Your soul belongs to me now Cerberus", 0.05f, true);
        yield return new WaitForSeconds(2);
        TextWriter.AddWriter_Static(msgTxt, "Game Over!", 0.05f, true);
        yield return new WaitForSeconds(2);
        DialogueBox.SetActive(false); 
     *
     */
}
