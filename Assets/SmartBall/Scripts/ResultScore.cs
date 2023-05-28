using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultScore : MonoBehaviour
{
    [SerializeField]
    [Header("スコアテキスト")]
    private TMP_Text _scoreText;
    
    private ScoreManager _scoreManager;
    
    void Start()
    {
        int allScore = FindObjectOfType<ScoreManager>().AllScore;
        _scoreText.text = allScore.ToString();
    }
}
