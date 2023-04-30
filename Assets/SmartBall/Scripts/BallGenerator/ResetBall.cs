using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBall : MonoBehaviour
{
    [SerializeField]
    [Header("ボールを再生成するクラス")]
    private InstantiateBall _instantiateBall;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("呼ばれた");
            _instantiateBall.GenerationBall();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            Debug.Log("呼ばれた");
            _instantiateBall.GenerationBall();
        }
    }
}
