using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallGenerator : MonoBehaviour
{
    [SerializeField]
    [Header("生成ボタン")]
    private Button _ballGeneratorButton;
    
    [SerializeField]
    [Header("ボールのプレハブ")]
    private GameObject _ball;
    
    [SerializeField]
    [Header("ボール生成位置")]
    private Transform _bollGeneratePos;
    
    void Start()
    {
        _ballGeneratorButton.onClick.AddListener(BallGeneratorButton);
    }

    private void BallGeneratorButton()
    {
        Instantiate(_ball,_bollGeneratePos.position,Quaternion.identity);
    }
}
