using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
   public void StartGame()
    {
        GameManager.Instance.scorePerLevel = 0;
        SceneManager.LoadScene(1);
    }
}
