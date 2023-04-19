using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GetBall : MonoBehaviour
{
    [SerializeField]
    [Header("ボールのブレハブ")]
    private GameObject _ball;
    
    [SerializeField]
    [Header("生成する範囲1")]
    private Transform _position1;
    
    [SerializeField]
    [Header("生成する範囲2")]
    private Transform _position2;
    
    [SerializeField]
    [Header("ボールの親オブジェクト")]
    private Transform _ballParentObject;
    
    

    public void RandomPositionInstantiate()
    {
            // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
            float x = Random.Range(_position1.position.x, _position2.position.x);
            // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
            float y = Random.Range(_position1.position.y, _position2.position.y);
            // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
            float z = Random.Range(_position1.position.z, _position2.position.z);

            // GameObjectを上記で決まったランダムな場所に生成
            Instantiate(_ball, new Vector3(x,y,z), _ball.transform.rotation,_ballParentObject);
    }
}
