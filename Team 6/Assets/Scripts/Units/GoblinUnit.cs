using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinUnit : Unit
{

    public GoblinUnit()
    {
        this.Name = "Goblin";
        this.Color = "Red";
        this.MaxHitPoints = this.HitPoints = 1;
        this.Strength = 2;
        this.Movement = 2;
        this.MovementRemaining = 2;
    }
}
