using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    [SerializeField]
    [Header("横の動く範囲")]
    private float _moveX = 10;
    
    private Sequence _sequence;
    void Start()
    {
        _sequence = DOTween.Sequence();
        
        _sequence.Append(transform.DOLocalMoveX(_moveX, 1.0f).SetEase(Ease.Linear).SetRelative());
        _sequence.Append(transform.DOLocalMoveX(-_moveX, 1.0f).SetEase(Ease.Linear).SetRelative());
        _sequence.SetLoops(-1);
    }
}
