using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BallGenerator : MonoBehaviour
{
    [SerializeField]
    [Header("生成ボタン")]
    private Button _ballGeneratorButton;
    
    [SerializeField]
    [Header("ボールのプレハブ")]
    private GameObject _ball;
    
    [FormerlySerializedAs("_bollGeneratePos")]
    [SerializeField]
    [Header("ボール生成位置")]
    private Transform _ballGeneratePos;

    [SerializeField]
    [Header("何球に設定するか")]
    private int _ballCount;
    
    void Start()
    {
        _ballGeneratorButton.onClick.AddListener(BallGeneratorButton);
    }

    private void BallGeneratorButton()
    {
        _ballCount--;
        if (_ballCount == 0)
        {
            _ballCount = 0;
            Debug.Log("玉なし");
            return;
        }
        else
        {
            _ball.transform.position = _ballGeneratePos.position;
            _ball.SetActive(true);
        }
    }
}
