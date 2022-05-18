using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GrimDialogue : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private Text grimTxt;
    private Text soulTxt;
    private Text devilTxt;
    private Text angelTxt;
    public Animator soulAnim;
    public Animator grimAnim;
    public Animator devilAnim;
    public Animator angelAnim;
    public GameObject grimDialogueBox;
    public GameObject soulDialogueBox;
    public GameObject devilDialogueBox;
    public GameObject angelDialogueBox;
    public GameObject startFade;
    public GameObject inGameSettings;
    public GameObject cutsceneCanvas;
    public GameObject blackScreenCanvas;
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
                cutsceneCanvas.SetActive(false);
                startFade.SetActive(false);
                blackScreenCanvas.SetActive(false);
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
        angelTxt = transform.Find("AngelDialogue").Find("message").GetComponent<Text>();
        devilTxt = transform.Find("DevilDialogue").Find("message").GetComponent<Text>();
        grimDialogueBox.gameObject.SetActive(false);
        soulDialogueBox.gameObject.SetActive(false);
        angelDialogueBox.gameObject.SetActive(false);
        devilDialogueBox.gameObject.SetActive(false);
        onCutscreen = true;
            StartCoroutine(GrimLines());
     

    }
    public void FalseDialogue()
    {
        grimDialogueBox.gameObject.SetActive(false);
        soulDialogueBox.gameObject.SetActive(false);
        angelDialogueBox.gameObject.SetActive(false);
        devilDialogueBox.gameObject.SetActive(false);
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
        cutsceneCanvas.SetActive(false);
        blackScreenCanvas.SetActive(false);
        startFade.SetActive(false);
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
        grimAnim.SetBool("isLeft", true);
        yield return new WaitForSeconds(0.5f);
        grimDialogueBox.gameObject.SetActive(true);
        CurrentDialogue(1.8f);
        TextWriter.AddWriter_Static(grimTxt, "Finally! A day off..", 0.07f, true);
        yield return new WaitForSeconds(7);
        grimAnim.SetBool("isLeft", false);
        grimDialogueBox.gameObject.SetActive(true);
        TextWriter.AddWriter_Static(grimTxt, "What was that?", 0.05f, true);
        CurrentDialogue(0.9f);
        yield return new WaitForSeconds(1);
        soulDialogueBox.gameObject.SetActive(true);
        TextWriter.AddWriter_Static(soulTxt, "!m^#wq2@qw&@!w (Giberrish)", 0.02f, true);
        CurrentDialogue(0.9f);
        soulAnim.SetBool("isLeft", true);
        yield return new WaitForSeconds(3);
        angelDialogueBox.gameObject.SetActive(true);
        TextWriter.AddWriter_Static(angelTxt, "Hey!!", 0.05f, true);
        CurrentDialogue(0.9f);
        soulAnim.SetBool("isLeft", false);
        grimAnim.SetBool("isLeft", true);
        yield return new WaitForSeconds(2f);
        grimAnim.SetBool("isLeft", false);
        angelAnim.SetBool("isLeft", true);
        devilAnim.SetBool("isLeft", false);
        grimDialogueBox.gameObject.SetActive(true);
        TextWriter.AddWriter_Static(grimTxt, "Explain yourselves!", 0.05f, true);
        CurrentDialogue(1.5f);
        yield return new WaitForSeconds(2f);
        angelAnim.SetBool("isLeft", false);
        devilAnim.SetBool("isLeft", true);
        angelDialogueBox.gameObject.SetActive(true);
        TextWriter.AddWriter_Static(angelTxt, "That soul belongs to me", 0.05f, true);
        CurrentDialogue(1.5f);
        yield return new WaitForSeconds(2f);
        devilDialogueBox.gameObject.SetActive(true);
        TextWriter.AddWriter_Static(devilTxt, "Hell no it belongs to me!", 0.05f, true);
        CurrentDialogue(1.5f);
        yield return new WaitForSeconds(1.6f);
        grimDialogueBox.gameObject.SetActive(true);
        TextWriter.AddWriter_Static(grimTxt, "Silence!! I'll take care of it!", 0.05f, true);
        CurrentDialogue(2);
        yield return new WaitForSeconds(2.30f);
        devilDialogueBox.gameObject.SetActive(true);
        TextWriter.AddWriter_Static(devilTxt, "You forced this on your own Grim!", 0.02f, true);
        CurrentDialogue(1.5f);
        angelAnim.SetBool("isAtk", true);
        devilAnim.SetBool("isAtk", true);
        yield return new WaitForSeconds(1.6f);
        grimAnim.SetBool("isAtk", true);
        yield return new WaitForSeconds(0.5f);
        grimAnim.SetBool("isAtk", false);
        yield return new WaitForSeconds(1.9f);
        grimDialogueBox.gameObject.SetActive(true);
        TextWriter.AddWriter_Static(grimTxt, "*Sigh Let's go, I'll take you to the judgement place", 0.03f, true);
        CurrentDialogue(2.0f);
        yield return new WaitForSeconds(2.5f);
        soulDialogueBox.gameObject.SetActive(true);
        TextWriter.AddWriter_Static(soulTxt, "*&$#Wrt$~!#t@- (More Gibberish) ", 0.02f, true);
        CurrentDialogue(2.0f);
        yield return new WaitForSeconds(5f);

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
