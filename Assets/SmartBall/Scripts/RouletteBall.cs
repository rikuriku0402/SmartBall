using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteBall : MonoBehaviour,IRouletteeble
{
    private int _probability;
    
    
    public void RouletStart()
    {
        if (Probability.RouletteProbability(30))
        {
            Debug.Log("30%が起こった");
        }
        else if (Probability.RouletteProbability(50))
        {
            Debug.Log("50%が起こった");
        }
        else
        {
            Debug.Log("はずれ");
        }
        Debug.Log("ルーレット開始");
    }
}
