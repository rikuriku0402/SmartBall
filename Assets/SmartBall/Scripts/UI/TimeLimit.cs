using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class TimeLimit : MonoBehaviour
{
    [SerializeField]
    private float _time;

    [SerializeField] 
    private Text _timeText;

    private void Start()
    {
        this.UpdateAsObservable()
            .Skip(1)
            .Subscribe(_ => TimeCount())
            .AddTo(this);
    }

    private void TimeCount()
    {
        _timeText.text = _time.ToString("f1");
        
        if (0 >= _time)
        {
            Debug.Log("終わり");
            _time = 0;
            SceneManager.LoadScene("GameOverScene");
        }
        else
        {
            _time -= Time.deltaTime;
        }
    }
}
