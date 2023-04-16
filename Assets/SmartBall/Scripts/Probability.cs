using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Probability : MonoBehaviour
{
    public static bool RouletteProbability(float percent)
    {
        float probabilityRate = UnityEngine.Random.value * 100.0f;

        if (percent == 100.0f && probabilityRate == percent)
        {
            return true;
        }
        else if (probabilityRate < percent)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
