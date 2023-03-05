using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HexCalculator 
{


    static readonly float WIDTH_MULTIPLIER = Mathf.Sqrt(3) / 2;

    static float radius = 1f;

    public static  float HexHeight()
    {
        return radius * 2;
    }

    public static float HexWidth()
    {
        return WIDTH_MULTIPLIER * HexHeight();
    }

    public static float HexVerticalSpacing()
    {
        return HexHeight() * 0.75f;
    }

    public static float HexHorizontalSpacing()
    {
        return HexWidth();
    }

    
}
