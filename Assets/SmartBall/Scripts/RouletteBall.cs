using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class RouletteBall : MonoBehaviour
{
    private async void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IRouletteAble roulette))
        {
            roulette.RouletStart();
            // await BallActiveFalse(gameObject);
        }
    }

    private async UniTask BallActiveFalse(GameObject ball)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        ball.SetActive(false);
    }
}
