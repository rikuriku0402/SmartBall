using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Triggers;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UniRx;
using UnityEngine.Serialization;

public class TensionRod : MonoBehaviour
{
    private float _clickingTime;

    [SerializeField]
    private GameObject _ball;

    private Rigidbody _rd;
    
    private Vector3 _currentPos;

    [SerializeField]
    private float _power = 20;
    
    //y軸方向の移動範囲の最小値
    [SerializeField]
    private float _minY;

    //y軸方向の移動範囲の最大値
    [SerializeField]
    private float _maxY;

    [SerializeField]
    private bool _coolTime;
    
    private void Start()
    {
        _rd = _ball.GetComponent<Rigidbody>();
        _currentPos = gameObject.transform.position;
        
        this.UpdateAsObservable()
            .Subscribe(_ => Limit())
            .AddTo(this);
        
        //CoolTime(false);
    }

    public void Drag()
    {
        _clickingTime += Time.deltaTime * -5;
        Move();
    }

    public void EndDrag()
    {
        Shot();
    }

    public void Move()
    {
        var pos = gameObject.transform.position;
        
        transform.DOMove(new Vector3(pos.x, _clickingTime, pos.z), 0.1f);
    }

    public async void Shot()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
        transform
            .DOMove(_currentPos, 0.5f)
            .SetEase(Ease.OutBounce);
        
        if (_coolTime == false)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(0.1f));
            _rd.AddForce(new Vector3(0,_clickingTime * -_power, 0), ForceMode.Impulse);
        }
        _clickingTime = 0;
        //CoolTime(true);
    }

    public void Limit()
    {
        //y軸方向の移動範囲制限
        _clickingTime = Mathf.Clamp(_clickingTime, _minY, _maxY);
    }
    
    public void CoolTime(bool value)
    {
        //ボール生成時に呼び出しボールをはじけるようにする
        _coolTime = value;
    }
}
