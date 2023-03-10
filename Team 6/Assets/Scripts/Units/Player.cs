using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    
    public Player()
    {
        this.Name = "Player";
        this.MaxHitPoints = this.HitPoints = 20;
        this.Strength = 1;
        this.Movement = 1;
    }
}
