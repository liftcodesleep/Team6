using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightUnit : Unit
{
    public KnightUnit()
    {
        this.Name = "Knight";
        this.Color = "White";
        this.MaxHitPoints = this.HitPoints = 4;
        this.Strength = 1;
        this.Movement = 1;
        this.MovementRemaining = 1;
    }

}
