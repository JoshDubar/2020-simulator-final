using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public static int highScore = 0;
    public static int curScore;

    public static void UpdateHighScore(int score)
    {
        curScore = score;
        if (score > highScore)
        {
            highScore = score;
        }
    }
}
