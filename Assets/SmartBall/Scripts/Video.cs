using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Video;
using System;

public class Video : MonoBehaviour
{
    [SerializeField]
    [Header("UIManager")]
    private UIManager _uiManager;
    
    [SerializeField]
    [Header("通常時のはずれの動画集")]
    private List<VideoPlayer> _normalTimeVideo;
    
    [SerializeField]
    [Header("小当たりの動画集")]
    private List<VideoPlayer> _smallHitVideo;
    
    [SerializeField]
    [Header("大当たり動画集")]
    private List<VideoPlayer> _bigHitVideo;

    [SerializeField]
    [Header("リーチ中の演出動画")]
    private List<VideoPlayer> _reachEffectVideo;
    
    [SerializeField]
    [Header("リーチ中のはずれ動画集")]
    private List<VideoPlayer> _reachMissVideo;

    private int _listNumber;
    
    public void Reach()
    {
        _listNumber = UnityEngine.Random.Range(0,_smallHitVideo.Count);

        if (Probability.RouletteProbability(75))
        {
            _smallHitVideo[_listNumber].Play();
        }
        else if (Probability.RouletteProbability(30))
        {
            _bigHitVideo[_listNumber].Play();
        }
                
    }
    
    public async void NormalTime()
    {
        _uiManager.RouletteHold();
        await RouletteFlow();
        _uiManager.RouletteHoldConsumption();
    }

    private void ReachEffect(VideoPlayer vp)
    {
        if (Probability.RouletteProbability(75))
        {
            Debug.Log("はずれの動画");
            ReachMiss();
        }
        else if (Probability.RouletteProbability(20))
        {
            Debug.Log("あたり");
            _reachEffectVideo[_listNumber].Play();
        }
    }

    private void ReachMiss()
    {
        _reachMissVideo[_listNumber].Play();
    }
    
    private async UniTask RouletteFlow()
    {
        var miss = UnityEngine.Random.Range(0,_normalTimeVideo.Count);
        _normalTimeVideo[miss].Play();
        await UniTask.Delay(TimeSpan.FromSeconds(_normalTimeVideo[miss].clip.length));
        
        if (_uiManager.RouletteHoldNumberNumber > 0)
        {
            Debug.Log("保留あり");
            await RouletteFlow();
        }
    }
}
