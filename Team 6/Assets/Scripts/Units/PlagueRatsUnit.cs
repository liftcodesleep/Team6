using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueRatsUnit : Unit
{

    public PlagueRatsUnit()
    {
        this.Name = "Plague Rats";
        this.Color = "Black";
        this.MaxHitPoints = this.HitPoints = GetPlagueRatCount();
        this.Strength = 1;
        this.Movement = 2;
        this.MovementRemaining = 2;
    }
    private int GetPlagueRatCount()
    {
        int count = 0;
        foreach(Unit unit in Game.units)
        {
            if(unit.GetName() == this.Name)
            {
                unit.MaxHitPoints++;
                unit.HitPoints++;
                unit.Strength++;
                count++;
            }
        }
        return count;
    }
}
