using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ScoreSliderModel : MonoBehaviour
{
    public IReadOnlyReactiveProperty<int> Score => _score;
    private readonly IntReactiveProperty _score = new(0);
    
    /// <summary>スコア加算の処理</summary>
    public void GetScore(int score)
    {
        _score.Value += score;
    }

    private void OnDestroy()
    {
        _score.Dispose();
    }
}
