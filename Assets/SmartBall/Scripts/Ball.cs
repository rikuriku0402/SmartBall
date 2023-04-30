using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // x軸方向の移動範囲の最小値
    [SerializeField]
    private float _minY = -0.5f;

    // x軸方向の移動範囲の最大値
    [SerializeField]
    private float _maxY = 10;

    public void Update()
    {
        var pos = transform.position;

        // x軸方向の移動範囲制限
        pos.y = Mathf.Clamp(pos.y, _minY, _maxY);
        transform.position = pos;
        
    }
}
