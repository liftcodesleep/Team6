using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearUnit : Unit
{
   
    public BearUnit()
    {
        this.MaxHitPoints = this.HitPoints = 2;
        this.Strenth = 2;
        this.Movement = 2;
    }
}
