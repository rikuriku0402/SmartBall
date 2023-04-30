using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshPro BigHitText => _bigHitText;
    
    public TextMeshProUGUI ScoreText => _scoreText;
    
    [SerializeField]
    [Header("大当たりテキスト")]
    private TextMeshPro _bigHitText;
    
    [SerializeField]
    [Header("今の玉の数テキスト")]
    private TextMeshProUGUI _nowBallCountText;
    
    [SerializeField]
    [Header("スコア")]
    private TextMeshProUGUI _scoreText;

}
