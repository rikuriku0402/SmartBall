using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBall : MonoBehaviour
{
    [SerializeField]
    [Header("生成するボールのプレハブ")]
    private GameObject _ball;
    
    [SerializeField]
    [Header("再利用するボール")]
    private GameObject _recycleBall;
    
    [SerializeField]
    [Header("生成する範囲1")]
    private Transform _position1;
    
    [SerializeField]
    [Header("生成する範囲2")]
    private Transform _position2;
    
    [SerializeField]
    [Header("ボールの親オブジェクト")]
    private Transform _ballParentObject;
    
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

    public void RandomPositionInstantiate()
    {
            // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
            float x = Random.Range(_position1.position.x, _position2.position.x);
            // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
            float y = Random.Range(_position1.position.y, _position2.position.y);
            // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
            float z = Random.Range(_position1.position.z, _position2.position.z);

            // GameObjectを上記で決まったランダムな場所に生成
            Instantiate(_ball, new Vector3(x,y,z), _ball.transform.rotation, _ballParentObject);
    }
    
    public void GenerationBall()
    {
        if (_ballCount == 0)
        {
            Debug.Log("玉なし");
            _recycleBall.SetActive(false);
            return;
        }
        else
        {           
            Debug.Log("玉あり");
            _ballCount--;
            _recycleBall.transform.position = _ballGeneratePos.position;
            _recycleBall.SetActive(true);
            _uiManager.NowBallCountText.text = _ballCount.ToString();
        }
    }
}
