using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearUnit : Unit
{
   
    public BearUnit()
    {
        this.Name = "Bears";
        this.MaxHitPoints = this.HitPoints = 2;
        this.Strenth = 2;
        this.Movement = 2;
    }
}
