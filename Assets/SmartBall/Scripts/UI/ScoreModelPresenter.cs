using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ScoreModelPresenter : MonoBehaviour
{
    [SerializeField] 
    private ScoreSliderModel _gameScoreModel;
    
    [SerializeField]
    private ScoreSliderView _gameScoreView;

    private void Start()
    {
        _gameScoreModel.Score
            .Subscribe(x => { _gameScoreView.SetScoreValue(x); })
            .AddTo(this);
    }
}
