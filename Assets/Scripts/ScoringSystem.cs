using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    public static int scoreP1;
    public static int scoreP2;

    void Update()
    {
        if (scoreP1 >= 11)
        {
            Debug.Log("Game Over, Player One Wins!");
            scoreP1 = 0;
            scoreP2 = 0;
        }
        else if (scoreP2 >= 11)
        {
            Debug.Log("Game Over, Player One Wins!");
            scoreP1 = 0;
            scoreP2 = 0;
        }
    }
}
