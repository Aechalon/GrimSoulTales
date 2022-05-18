using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class dialogueScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]Text  Dialogue1;


 
    void Start()
    {
     
           
           
                StartCoroutine(Dialogue());
        
    }

    IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(1);
        Dialogue1.text = "Hi there";
        yield return new WaitForSeconds(3);
        Dialogue1.text = "A quick tutorial..";
        yield return new WaitForSeconds(3);
        Dialogue1.text = "Press E to Attack.";
        yield return new WaitForSeconds(3);
        Dialogue1.text = "Press Space to Jump.";
        yield return new WaitForSeconds(3);
        Dialogue1.text = "A to move Left and D to move Right..";
        yield return new WaitForSeconds(3);
        Dialogue1.text = "Common knowledge I guess?";
        yield return new WaitForSeconds(3);
        Dialogue1.text = "Oh yeah don't let those ashheads \n take the lost soul.";
        yield return new WaitForSeconds(3);
        Dialogue1.text = "It needs your help..";
        yield return new WaitForSeconds(3);
        Dialogue1.text = "Game isn't finish but..";
        yield return new WaitForSeconds(5);
        Dialogue1.text = "Good luck heheheh";
        yield return new WaitForSeconds(10);
        Dialogue1.text = "Hi there";
        yield return new WaitForSeconds(3);
        Dialogue1.text = "A quick tutorial..";
        yield return new WaitForSeconds(3);
        Dialogue1.text = "Press E to Attack.";
        yield return new WaitForSeconds(3);
        Dialogue1.text = "Press Space to Jump.";
        yield return new WaitForSeconds(3);
        Dialogue1.text = "A to move Left and D to move Right..";
        yield return new WaitForSeconds(3);
        Dialogue1.text = "Common knowledge I guess?";
        yield return new WaitForSeconds(3);
        Dialogue1.text = "Oh yeah don't let those ashheads \n take the lost soul.";
        yield return new WaitForSeconds(3);
        Dialogue1.text = "It needs your help..";
        yield return new WaitForSeconds(3);
        Dialogue1.text = "Game isn't finish but..";
        yield return new WaitForSeconds(5);
        Dialogue1.text = "Good luck heheheh";
        yield return new WaitForSeconds(10);
        Dialogue1.text = "Hi there";
        yield return new WaitForSeconds(3);
        Dialogue1.text = "A quick tutorial..";
        yield return new WaitForSeconds(3);
        Dialogue1.text = "Press E to Attack.";
        yield return new WaitForSeconds(3);
        Dialogue1.text = "Press Space to Jump.";
        yield return new WaitForSeconds(3);
        Dialogue1.text = "A to move Left and D to move Right..";
        yield return new WaitForSeconds(3);
        Dialogue1.text = "Common knowledge I guess?";
        yield return new WaitForSeconds(3);
        Dialogue1.text = "Oh yeah don't let those ashheads \n take the lost soul.";
        yield return new WaitForSeconds(3);
        Dialogue1.text = "It needs your help..";
        yield return new WaitForSeconds(3);
        Dialogue1.text = "Game isn't finish but..";
        yield return new WaitForSeconds(5);
        Dialogue1.text = "Good luck heheheh";



    }

}
