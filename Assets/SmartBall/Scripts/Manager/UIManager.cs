using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_Text BigHitText => _bigHitText;
    
    public TMP_Text[] SmallHitText => _smallHitText;
    
    public TMP_Text NowBallCountText => _nowBallCountText;
    
    public TMP_Text ScoreText => _scoreText;
    
    public TMP_Text GameText => _gameText;
    
    [SerializeField]
    [Header("大当たりテキスト")]
    private TMP_Text _bigHitText;
    
    [SerializeField]
    [Header("小当たりテキスト")]
    private TMP_Text[] _smallHitText;
    
    [SerializeField]
    [Header("今の玉の数テキスト")]
    private TMP_Text _nowBallCountText;
    
    [SerializeField]
    [Header("スコア")]
    private TMP_Text _scoreText;
    
    [SerializeField]
    [Header("ゲームオーバー、ゲームクリアテキスト")]
    private TMP_Text _gameText;

}
