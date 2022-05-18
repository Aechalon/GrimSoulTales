using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayDirtFloat : MonoBehaviour
{
    // Start is called before the first frame update

    public Animation dirtFloat;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("DelayFloat", 1.3f);
        }
    }
    public void DelayFloat()
    {
        dirtFloat.Play();
    }
}
