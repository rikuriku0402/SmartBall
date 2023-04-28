using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Triggers;
using Cysharp.Threading.Tasks;
using DG.Tweening;

public class TensionRod : MonoBehaviour
{
    [SerializeField]
    private float _clickingTime;

    [SerializeField]
    private GameObject _ball;

    private Rigidbody _rd;

    [SerializeField]
    private Vector3 _currentPos;

    [SerializeField]
    private float _power;
    private void Start()
    {
        _rd = _ball.GetComponent<Rigidbody>();
        _currentPos = gameObject.transform.position;
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
        var posX = gameObject.transform.position.x;
        var posZ = gameObject.transform.position.z;
        transform.DOMove(new Vector3(posX, _clickingTime, posZ), 0.5f);
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

}
