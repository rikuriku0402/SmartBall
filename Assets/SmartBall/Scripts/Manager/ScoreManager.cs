using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading;
using Cysharp.Threading.Tasks;

public class ScoreManager : MonoBehaviour
{
    public int AllScore => _allScore;
    
    private int _allScore;
    
    [SerializeField]
    [Header("ボールを生成するかのフラグ")]
    private bool _isInstantiateBall;

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
    
    [SerializeField]
    [Header("クリアするためのスコアの上限")]
    private int _clearScore;

    

    private void Start()
    {
        DontDestroyOnLoad(this);
        
        _uiManager.BigHitText.text = _bigHit.ToString();

        for (int i = 0; i < _uiManager.SmallHitText.Length; i++)
        {
            _uiManager.SmallHitText[i].text = _smallHit.ToString();
        }
    }

    public async void BigHit()
    {
        _allScore += _bigHit;
        Debug.Log(_allScore);
        _uiManager.ScoreText.text = _allScore.ToString();
        PlayerPrefs.SetInt("SCORE", _allScore);

        if (_allScore >= _clearScore)
        {
            await GameClearAsync();
        }
    }

    public async void SmallHit()
    {
        _allScore += _smallHit;        
        Debug.Log(_allScore);
        _uiManager.ScoreText.text = _allScore.ToString();
        PlayerPrefs.SetInt("SCORE", _allScore);
        
        if (_allScore >= _clearScore)
        {
            await GameClearAsync();
        }
    }

    private async UniTask GameClearAsync()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(1.5f));
        SceneLoader.SceneChange("ClearScene");
        Debug.Log("ゲームクリア");
    }
    
    /// <summary>
    /// ボールを生成する関数
    /// </summary>
    private void BallInstantiate()
    {
        if (!_isInstantiateBall)
        {
            for (int i = 0; i < _allScore; i++)
            {
                instantiateBall.RandomPositionInstantiate();
            }
        }
        else
        {
            Debug.Log("ボールは生成しない");
        }
    }
}
