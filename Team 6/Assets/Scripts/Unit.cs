using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit 
{

    public string Name = "Unnamed";
    public int MaxHitPoints = 4;
    public int HitPoints;
    public int Strenth = 2;
    public int Movement = 1;
    public int MovementRemaining = 2;

    Queue<Hex> hexPath;

    public Hex Hex { get; protected set; }


    public delegate void UnitMovedDelegate(Hex oldHex, Hex newHex);

    public UnitMovedDelegate OnUnitMoved;


    public Unit()
    {
        HitPoints = MaxHitPoints;
    }

    public void SetHex(Hex hex)
    {

        if (OnUnitMoved != null)
        {
            OnUnitMoved(Hex, hex);
        }

        if (Hex != null)
        {
            hex.RemoveUnit(this);
        }


        Hex = hex;
        hex.AddUnit(this);
        
    }

    public void DoTurn()
    {
        if(hexPath == null || hexPath.Count == 0)
        {
            return;
        }
        //Hex oldHex = Hex;
        //Hex newHex = HexMap.GetHex(oldHex.Q + 1, oldHex.R);

        Hex newHex = hexPath.Dequeue();
        
        SetHex(newHex);
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
}
