using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBall : MonoBehaviour
{
    [SerializeField]
    [Header("ボールを再生成するクラス")]
    private InstantiateBall _instantiateBall;
    
    [SerializeField]
    [Header("")]
    private TensionRod _tensionRod;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("コリジョン");
            _tensionRod.CoolTime(false);
            _instantiateBall.GenerationBall();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       //_tensionRod.CoolTime(false);
    }
}
