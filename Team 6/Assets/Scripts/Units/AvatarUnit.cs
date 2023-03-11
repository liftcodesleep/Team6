using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarUnit : Unit
{
   
    public AvatarUnit()
    {
        this.Name = "Avatar";
        this.Color = "WUBRG";
        this.MaxHitPoints = this.HitPoints = 20;
        this.Strength = 2;
        this.Movement = 2;
        this.MovementRemaining = 2;
    }
}
