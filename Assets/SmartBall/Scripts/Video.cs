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
    [Header("大当たりの確率")]
    private int _bigHitProbability;
    
    [SerializeField]
    [Header("当たった時に操作の受付を拒否するためのイメージ")]
    private Image _operationIgnoreImage;
    
    [SerializeField]
    [Header("ScoreManager")]
    private ScoreManager _scoreManager;
    
    [SerializeField]
    [Header("UIManager")]
    private UIManager _uiManager;
    
    [SerializeField]
    [Header("ボールを生成するクラス")]
    private InstantiateBall instantiateBall;
    
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
            _scoreManager.GetScore(100);
            // _scoreManager.AddScore(100);
            _uiManager.ScoreText.text = _scoreManager.AllScore.ToString();
            _uiManager.BigHitText.text = _scoreManager.AllScore.ToString();
            BallInstantiate();
        }
        else
        {
            _listNumber = Random.Range(0,_smallHitVideo.Count);
            Debug.Log("小当たり");
            _smallHitVideo[_listNumber].loopPointReached += ImageActiveTure;
            _smallHitVideo[_listNumber].Play();
            _scoreManager.GetScore(50);
            // _scoreManager.AddScore(50);
            _uiManager.ScoreText.text = _scoreManager.AllScore.ToString();
            _uiManager.BigHitText.text = _scoreManager.AllScore.ToString();
            BallInstantiate();
        }
    }

    public void NormalHit()
    {
        _operationIgnoreImage.gameObject.SetActive(true);
        _listNumber = Random.Range(0,_smallHitVideo.Count);
        Debug.Log("固定当たり");
        _smallHitVideo[_listNumber].loopPointReached += ImageActiveTure;
        _smallHitVideo[_listNumber].Play();
        _scoreManager.GetScore(15);
        // _scoreManager.AddScore(15);
        _uiManager.ScoreText.text = _scoreManager.AllScore.ToString();
        _uiManager.BigHitText.text = _scoreManager.AllScore.ToString();
        BallInstantiate();
    }

    /// <summary>
    /// ボールを生成する関数
    /// </summary>
    private void BallInstantiate()
    {
        for (int i = 0; i < _scoreManager.AllScore; i++)
        {
            instantiateBall.RandomPositionInstantiate();
        }
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
