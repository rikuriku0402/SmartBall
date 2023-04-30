using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Triggers;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UniRx;

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
    private float _minY = -0.5f;

    //y軸方向の移動範囲の最大値
    [SerializeField]
    private float _maxY = 10;
    private void Start()
    {
        _rd = _ball.GetComponent<Rigidbody>();
        _currentPos = gameObject.transform.position;
        
        this.UpdateAsObservable()
            .Subscribe(_ => Limit())
            .AddTo(this);
    }

    public void Drag()
    {
        _clickingTime += Time.deltaTime * -4;
        Move();
    }

    public void EndDrag()
    {
        Shot();
    }

    public void Move()
    {
        var pos = gameObject.transform.position;
        
        Limit();
        transform.DOMove(new Vector3(pos.x, _clickingTime, pos.z), 0.5f);

    }

    public async void Shot()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
        transform.DOMove(_currentPos, 0.5f)
            .SetDelay(0.2f)
            .SetEase(Ease.OutBounce);
        
        await UniTask.Delay(TimeSpan.FromSeconds(0.2f));
        _rd.AddForce(new Vector3(0,_clickingTime * -_power, 0), ForceMode.Impulse);
        _clickingTime = 0;
    }

    public void Limit()
    {
        //y軸方向の移動範囲制限
        _clickingTime = Mathf.Clamp(_clickingTime, _minY, _maxY);

    }

}
