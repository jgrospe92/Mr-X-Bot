using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public Text EndScore;

    private void Start()
    {
        int score = GameManager.Instance.GetScore();
        EndScore.text = "SCORE : " + score;
        Cursor.lockState = CursorLockMode.None;
    }

}
