using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurUnit : Unit
{
    public MinotaurUnit()
    {
        this.Name = "Minotaur";
        this.Color = "Red";
        this.MaxHitPoints = this.HitPoints = 5;
        this.Strength = 5;
        this.Movement = 5;
        this.MovementRemaining = 5;
    }
}
