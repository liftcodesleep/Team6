using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnivesUnit : Unit
{

    public KnivesUnit()
    {
        this.Name = "Knives";
        this.Color = "Black";
        this.MaxHitPoints = this.HitPoints = 4;
        this.Strength = 6;
        this.Movement = 3;
        this.MovementRemaining = 3;
    }
}
