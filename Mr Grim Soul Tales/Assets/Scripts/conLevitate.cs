using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conLevitate : MonoBehaviour
{
    public dropItem dropItemScript;
    public Animation onLevitate;
    // Start is called before the first frame update

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && dropItemScript.collected)
        {
            onLevitate.Play();
        }
    }
}
