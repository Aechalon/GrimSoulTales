using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RestartGame : MonoBehaviour
{
  public void restart()
    {
        SceneManager.LoadScene("Level 1");
    }
}
