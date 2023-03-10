using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderUnit : Unit
{
    public SpiderUnit()
    {
        this.Name = "Spider";
        this.Color = "Black";
        this.MaxHitPoints = this.HitPoints = 2;
        this.Strength = 3;
        this.Movement = 1;
    }
}
