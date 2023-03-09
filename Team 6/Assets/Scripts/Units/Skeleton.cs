using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonUnit : Unit
{
    public SkeletonUnit()
    {
        this.Name = "Skeleton";
        this.MaxHitPoints = this.HitPoints = 3;
        this.Strenth = 2;
        this.Movement = 1;
    }

}
