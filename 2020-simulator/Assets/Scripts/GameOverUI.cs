using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Text highScore, thisScore;

    public void Start()
    {
        highScore.text = HighScore.highScore.ToString();
        thisScore.text = HighScore.curScore.ToString() + " NEW FRIENDS!";
    }
}
