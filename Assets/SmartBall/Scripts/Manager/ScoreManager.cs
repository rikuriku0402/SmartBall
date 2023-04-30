using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int AllScore => _allScore;
    
    private int _allScore;

    public void AddScore(int score)
    {
        _allScore += score;
    }
    
    public void GetScore(int score)
    {
        _allScore = score;
    }

    public void MinusScore(int currentScore)
    {
        if (currentScore == 0)
        {
            Debug.Log("金ないやんけ");
            return;
        }
        
        currentScore -= 1;
        _allScore = currentScore;
    }
}
