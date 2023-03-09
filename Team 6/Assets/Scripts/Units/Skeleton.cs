using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonUnit : Unit
{
    public SkeletonUnit()
    {
        this.MaxHitPoints = this.HitPoints = 4;
        this.Strenth = 1;
        this.Movement = 1;
    }

}
