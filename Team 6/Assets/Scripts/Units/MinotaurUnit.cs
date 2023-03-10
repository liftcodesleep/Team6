using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurUnit : Unit
{
    public MinotaurUnit()
    {
        this.Name = "Minotaur";
        this.MaxHitPoints = this.HitPoints = 5;
        this.Strenth = 5;
        this.Movement = 5;
    }
}
