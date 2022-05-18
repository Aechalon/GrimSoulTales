using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public AiFollow2 soul;
    public AiFollow angelSC;
    public AiFollow1 devilSC;
    public GameObject soulObj;
    public float detachTime;
    public int onLevel = 1;
    public int miniGameScore;
    public bool doorKey;
    public bool soulFail;
    public bool miniGameStart;
    public bool isThere;
    public bool gameStart;
    public bool isCutscene;
    public GameObject miniGamePanel;
    public Transform soulLeft;
    public Transform soulRight;
    public Transform checkpoint1;
    public Transform checkpoint2;
    public Transform checkpoint3;
    public GameObject Angel;
    public GameObject Devil;

    public HitBar hitBarScore;
    public void Update()
    {
        if(miniGameScore == 25 && hitBarScore.gameEnd)
        {

            Invoke("delaySpawn", 1.4f);
            soul.isAlive = false;
            hitBarScore.gameEnd = false;
        }
        if (miniGameScore == 100 && hitBarScore.gameEnd)
        {
            angelSC = FindObjectOfType<AiFollow>();
            devilSC = FindObjectOfType<AiFollow1>();
            angelSC.onCommand = true;
            devilSC.onCommand = true;
            Invoke("delayCommand",0.2f);
            hitBarScore.gameEnd = false;
        }

        if (onLevel == 1)
        {
        transform.position = checkpoint1.transform.position;
        }
        if (onLevel == 2)
        {
           transform.position = checkpoint2.transform.position;
        }
        if (onLevel == 3)
        {
          transform.position = checkpoint3.transform.position;
        }

        if (playerMovement.isControlEnb)
        {
            if (!soul.soulAttached)
            {
                if (!miniGameStart)
                {
                    detachTime += Time.deltaTime;
                }
                else
                {
                    if (!isThere)
                    {

                        Instantiate(Devil, soulLeft.position, soulLeft.rotation);
                        Instantiate(Angel, soulRight.position, soulRight.rotation);
                        isThere = true;
                    }
                    miniGamePanel.SetActive(true);
                    hitBarScore.onPlay = true;
                    hitBarScore.gameEnd = false;
                }
                if (detachTime > 9)
                {

                    detachTime = 0;
                    miniGameStart = true;
                }

            }
            else
            {
                detachTime = 0;
            }
        }

       
    }
    public void delaySpawn()

    {

        soul.isAlive = true;
        Instantiate(soulObj, transform.position, transform.rotation);
        soulLeft = GameObject.FindGameObjectWithTag("SoulLeft").transform;
        soulRight = GameObject.FindGameObjectWithTag("SoulRight").transform;
        soul = FindObjectOfType<AiFollow2>();


    }
    public void delayCommand()
    {
        angelSC.onCommand = false;
        devilSC.onCommand = false;
    }
    public void Start()
    {
        soulLeft = GameObject.FindGameObjectWithTag("SoulLeft").transform;
        soulRight = GameObject.FindGameObjectWithTag("SoulRight").transform;
        soul = FindObjectOfType<AiFollow2>();
        onLevel = 1;
    }
  
    [Header("Level 1 Items")]
    public bool level1Item1;
    public bool level1Item2;
    public bool level1Item3;
   /* [Header("Level 2 Items")]
    public bool level2Item1;
    public bool level2Item2;
    public bool level2Item3;
    [Header("Level 3 Items")]
  
    public bool level3Item1;
    public bool level3Item2;
    public bool level3Item3;
    */
    
    
}
