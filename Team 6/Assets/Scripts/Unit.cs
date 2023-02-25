using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit 
{

    public string Name = "Unnamed";
    public int HitPoints = 100;
    public int Strenth = 8;
    public int Movement = 2;
    public int MovementRemaining = 2;

    public Hex Hex { get; protected set; }


    public delegate void UnitMovedDelegate(Hex oldHex, Hex newHex);

    public UnitMovedDelegate OnUnitMoved;

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
        
        Hex oldHex = Hex;

        Hex newHex = HexMap.GetHex(oldHex.Q + 1, oldHex.R);
        
        SetHex(newHex);
    }

   
}
