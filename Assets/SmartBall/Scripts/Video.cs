using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    [SerializeField]
    [Header("小当たりの動画集")]
    private List<VideoPlayer> _smallHitVideo;
    
    [SerializeField]
    [Header("大当たり動画集")]
    private List<VideoPlayer> _bigHitVideo;

    [SerializeField]
    [Header("大当たりの確率それ以外は小当たり")]
    private int _bigHitProbability;
    
    [SerializeField]
    [Header("当たった時に操作の受付を拒否するためのイメージ")]
    private Image _operationIgnoreImage;
    
    [SerializeField]
    [Header("ScoreManager")]
    private ScoreManager _scoreManager;

    private int _listNumber;
    
    
    public void Lottery()
    {
        _operationIgnoreImage.gameObject.SetActive(true);
        
        if (Probability.RouletteProbability(_bigHitProbability))
        {
            _listNumber = Random.Range(0,_bigHitVideo.Count);
            Debug.Log("大当たり");
            _bigHitVideo[_listNumber].loopPointReached += ImageActiveTure;
            _bigHitVideo[_listNumber].Play();
            _scoreManager.BigHit();
        }
        else
        {
            _listNumber = Random.Range(0,_smallHitVideo.Count);
            Debug.Log("小当たり");
            _smallHitVideo[_listNumber].loopPointReached += ImageActiveTure;
            _smallHitVideo[_listNumber].Play();
            _scoreManager.BigHit();
        }
    }

    public void NormalHit()
    {
        _operationIgnoreImage.gameObject.SetActive(true);
        _listNumber = Random.Range(0,_smallHitVideo.Count);
        Debug.Log("固定当たり");
        _smallHitVideo[_listNumber].loopPointReached += ImageActiveTure;
        _smallHitVideo[_listNumber].Play();
        _scoreManager.SmallHit();
    }
    

    /// <summary>
    /// VideoPlayerの再生が終わった後に呼ばれる
    /// </summary>
    /// <param name="vp"></param>
    private void ImageActiveTure(VideoPlayer vp)
    {
        _operationIgnoreImage.gameObject.SetActive(false);
    }
}
