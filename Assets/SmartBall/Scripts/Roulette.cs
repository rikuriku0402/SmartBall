using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette : MonoBehaviour,IRouletteeble
{
    [SerializeField]
    [Header("はずれやリーチやあたりの動画が入ってるクラス")]
    private Video _video;
    
    [SerializeField]
    [Header("ゲートタイプ")]
    private GateEnum _type;
    
    private enum GateEnum
    {
        Lottery,
        NormalHit
    }
    
    public void RouletStart()
    {
        switch (_type)
        {
           case GateEnum.Lottery: 
               _video.Lottery();
               break;
           
           case GateEnum.NormalHit:
               _video.NormalHit();
               break;
        }
        Debug.Log("当たり");
    }
}
