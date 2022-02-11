using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    public static int scoreP1;
    public static int scoreP2;
    public static bool playerOneScored;
    public TextMeshProUGUI playerOneText;
    public TextMeshProUGUI playerTwoText;
    
    void Update()
    {
        playerOneText.text = $"Player One - {scoreP1}";
        playerTwoText.text = $"Player Two - {scoreP2}";
        
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
