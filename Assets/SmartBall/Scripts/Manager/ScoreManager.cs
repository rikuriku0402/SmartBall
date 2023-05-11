using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int AllScore => _allScore;
    
    private int _allScore;
    
    [SerializeField]
    [Header("大当たりをどのくらい増やすか")]
    private int _bigHit;
    
    [SerializeField]
    [Header("小当たりどのくらいふやすか")]
    private int _smallHit;
    
    [SerializeField]
    [Header("UIManager")]
    private UIManager _uiManager;
    
    [SerializeField]
    [Header("ボールを生成するクラス")]
    private InstantiateBall instantiateBall;


    private void Start()
    {
        _uiManager.BigHitText.text = _bigHit.ToString();

        for (int i = 0; i < _uiManager.SmallHitText.Length; i++)
        {
            _uiManager.SmallHitText[i].text = _smallHit.ToString();
        }
    }

    public int BigHit()
    {
        _allScore += _bigHit;
        Debug.Log(_allScore);
        _uiManager.ScoreText.text = _allScore.ToString();
        BallInstantiate();
        return _allScore;
    }

    public int SmallHit()
    {
        _allScore += _smallHit;        
        Debug.Log(_allScore);
        _uiManager.ScoreText.text = _allScore.ToString();
        BallInstantiate();
        return _allScore;
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
    
    /// <summary>
    /// ボールを生成する関数
    /// </summary>
    private void BallInstantiate()
    {
        for (int i = 0; i < _allScore; i++)
        {
            instantiateBall.RandomPositionInstantiate();
        }
    }
}
