using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBall : MonoBehaviour
{
    [SerializeField]
    [Header("生成するボールのプレハブ")]
    private GameObject _ball;
    
    [SerializeField]
    [Header("ボール生成位置")]
    private Transform _ballGeneratePos;

    [SerializeField]
    [Header("何球に設定するか")]
    private int _ballCount;

    [SerializeField]
    [Header("UIManager")]
    private UIManager _uiManager;


    private void Start()
    {
        _uiManager.NowBallCountText.text = _ballCount.ToString();
    }

    
    public void GenerationBall()
    {
        if (_ballCount == 0)
        {
            Debug.Log("玉なし");
            _ball.SetActive(false);
            return;
        }
        else
        {           
            Debug.Log("玉あり");
            _ballCount--;
            _ball.transform.position = _ballGeneratePos.position;
            _ball.SetActive(true);
            _uiManager.NowBallCountText.text = _ballCount.ToString();
        }
    }
}
