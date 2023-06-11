using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSliderView : MonoBehaviour
{
    [SerializeField]
    [Header("スコアゲージ")]
    Slider _scoreSlider;

    // [SerializeField] 
    // private Text _scoreText;
    
    public void SetScoreValue(float value)
    {
        DOTween.To(() => _scoreSlider.value,
            n => _scoreSlider.value = n,
            value, 1.5f);

        //_scoreText.text = value.ToString();
    }
}
