using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class chestCollected : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject collectedChest1;
    public GameObject collectedChest2;
    public GameObject collectedChest3;
    public void Update()
    {
        

        if (gameManager.onLevel == 1)
        {
            if (gameManager.level1Item1)
            {
                collectedChest1.SetActive(true);
            }
            else
            {
                collectedChest1.SetActive(false);
            }
            if (gameManager.level1Item2)
            {
                collectedChest2.SetActive(true);
            }
            else
            {
                collectedChest2.SetActive(false);
            }
            if (gameManager.level1Item3)
            {
                collectedChest3.SetActive(true);
            }
            else
            {
                collectedChest3.SetActive(false);
            }

            /*   if (gameManager.onLevel == 2)
              {
                  if (gameManager.level2Item1)
                  {
                      collectedChest1.SetActive(true);
                  }
                  else
                  {
                      collectedChest1.SetActive(false);
                  }
                  if (gameManager.level2Item2)
                  {
                      collectedChest2.SetActive(true);
                  }
                  else
                  {
                      collectedChest2.SetActive(false);
                  }
                  if (gameManager.level2Item3)
                  {
                      collectedChest3.SetActive(true);
                  }
                  else
                  {
                      collectedChest3.SetActive(false);
                  }
              }
          }
          if (gameManager.onLevel == 3)
          {
              if (gameManager.level3Item1)
              {
                  collectedChest1.SetActive(true);
              }
              else
              {
                  collectedChest1.SetActive(false);
              }
              if (gameManager.level3Item2)
              {
                  collectedChest2.SetActive(true);
              }
              else
              {
                  collectedChest2.SetActive(false);
              }
              if (gameManager.level3Item3)
              {
                  collectedChest3.SetActive(true);
              }
              else
              {
                  collectedChest3.SetActive(false);
              }
          }*/
        }

    }

}