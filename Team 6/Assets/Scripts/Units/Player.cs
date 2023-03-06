using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    
    public Player()
    {
        this.MaxHitPoints = this.HitPoints = 20;
        this.Strenth = 1;
        this.Movement = 1;
    }
}
