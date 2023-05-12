using UnityEngine;

public class Probability
{
    public static bool RouletteProbability(int percent)
    {
        int probabilityRate = (int)Random.value * 100;

        if (percent == 100 && probabilityRate == percent)
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
