using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropItem : MonoBehaviour
{
    public Animator animController;
    public GameObject itemDrop;
    public BoxCollider2D BoxCollider2D;
    public bool collected;
    private void Start()
    {
        collected = false;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) 
        {
            collected = true;
            animController.SetBool("isOpen", true);
            Invoke("ItemDrop", 1f);
            Invoke("DelayCollider", 1.2f);
            Invoke("delayInactive",1.4f);
        }
    }
    public void DelayCollider()
    {
        BoxCollider2D.enabled = true;
    }
    public void ItemDrop()
    {
        itemDrop.SetActive(true);
    }
    public void delayInactive()
    {
        this.gameObject.SetActive(false);
      
    }

}
