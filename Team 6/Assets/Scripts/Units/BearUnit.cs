using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearUnit : Unit
{
   
    public BearUnit()
    {
        this.Name = "Bears";
        this.Color = "Green";
        this.MaxHitPoints = this.HitPoints = 2;
        this.Strength = 2;
        this.Movement = 2;
        this.MovementRemaining = 2;
    }
}
