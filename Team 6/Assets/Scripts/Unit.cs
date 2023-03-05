using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit 
{

    public string Name = "Unnamed";
    public int MaxHitPoints = 4;
    public int HitPoints;
    public int Strenth = 2;
    public int Movement = 2;
    public int MovementRemaining = 2;

    Queue<Hex> hexPath;

    public Hex hex { get; protected set; }


    public Unit()
    {
        HitPoints = MaxHitPoints;
    }


    public bool Move(Hex movedToHex)
    {

        if (this.hex.DistanceFrom(movedToHex) <= Movement)
        {
            SetHex(movedToHex);
            return true;
        }

        return false;
    }

    public void SetHex(Hex hex)
    {

        if (this.hex != null)
        {
            hex.RemoveUnit(this);
        }

        this.hex = hex;
        hex.AddUnit(this);
        
    }


    public void SetHexPath(Hex[] hexPath)
    {
        this.hexPath = new Queue<Hex>(hexPath);
    }

   public int MovementCostToEnterHex(Hex hex)
    {
        return hex.BaseMovementCost();
    }

    public void attack(Unit enemy)
    {
        enemy.HitPoints -= this.Strenth;
    }

    public void heal(int amount)
    {
        if (amount + HitPoints > MaxHitPoints)
        {
            HitPoints = MaxHitPoints;
        }
        else
        {
            HitPoints += amount;
        }
    }
}
