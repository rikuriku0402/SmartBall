using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IRouletteeble rouletteeble))
        {
            rouletteeble.RouletStart();
        }
    }
}
