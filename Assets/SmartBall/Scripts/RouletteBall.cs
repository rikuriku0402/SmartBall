using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class RouletteBall : MonoBehaviour
{
    private async void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IRouletteeble roulette))
        {
            roulette.RouletStart();
            await BallActiveFalse(gameObject);
        }
    }

    private async UniTask BallActiveFalse(GameObject ball)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        ball.SetActive(false);
    }
}
