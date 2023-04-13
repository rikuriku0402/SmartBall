using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Roulette : MonoBehaviour,IRouletteeble
{
    [SerializeField]
    [Header("はずれやリーチやあたりの動画が入ってるクラス")]
    private Video _video;
    
    public void RouletStart()
    {
        Debug.Log("ルーレット開始");
        
        if (Probability.RouletteProbability(10))
        {
            Debug.Log("リーチ");
            try
            {
                _video.Reach();
            }
            catch (ArgumentOutOfRangeException)
            {
                Debug.LogError("ビデオが入ってない");
            }
        }
        else
        {
            Debug.Log("はずれが流れてる");
            try
            {
                _video.NormalTime();
            }
            catch (ArgumentOutOfRangeException)
            {
                Debug.LogError("ビデオが入ってない");
            }
        }
        
    }
}
