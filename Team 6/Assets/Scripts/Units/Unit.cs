using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit 
{
    public static GameData Game;

    public string Name = "Unit.Name";
    public string Color = "Unit.Color";
    public int MaxHitPoints = 1;
    public int HitPoints;
    public int Strength = 1;
    public int Movement = 1;
    public int MovementRemaining = 1;
    public int Range = 1;
    public bool CanRangedAttack = false;
    
    public PlayerData Owner;

    Queue<Hex> hexPath;

    public Hex hex { get; protected set; }


    public Unit()
    {
        HitPoints = MaxHitPoints;
    }


    public bool Move(Hex movedToHex)
    {
        //TODO Move should decrement from Unit's MovementRemaining
        if (this.hex.DistanceFrom(movedToHex) <= MovementRemaining && (movedToHex.GetUnits().Count == 0))
        {
            //Debug.Log("Hex distance is: " + this.hex.DistanceFrom(movedToHex));
            //Debug.Log("MovementRemaining is: " + this.MovementRemaining);
            SetHex(movedToHex);
            //this.MovementRemaining -= (int)this.hex.DistanceFrom(movedToHex);
            //Debug.Log("IntMovementRemaining is: " + (int)this.MovementRemaining);
            return true;
        }

        return false;
    }
    public void SetOwner(PlayerData owner)
    {
        this.Owner = owner;
    }
    public PlayerData GetOwner()
    {
        return this.Owner;
    }

    public void SetHex(Hex hex)
    {

        if (this.hex != null)
        {
            this.hex.RemoveUnit(this);
        }

        this.hex = hex;
        hex.AddUnit(this);
        
    }
    public static void SetGameData(GameData GameData)
    {
        Unit.Game = GameData;
    }

    public string GetName()
    {
        return this.Name;
    }

    public void SetHexPath(Hex[] hexPath)
    {
        this.hexPath = new Queue<Hex>(hexPath);
    }

   public int MovementCostToEnterHex(Hex hex)
    {
        return hex.BaseMovementCost();
    }

    public void Attack(Unit enemy)
    {
        //STOP HITTING YOURSELF
        if (enemy == this)
        {
            return;
        }
        if (this.hex.DistanceFrom(enemy.hex) <= Range && this.GetOwner() != enemy.GetOwner())
        {
            enemy.HitPoints -= this.Strength;
            this.HitPoints -= enemy.Strength; //For next playtest, attacks are symmetric, consider reducing damage dealt by defender? would like to avoid fractional damage
        }
    }

    public void Heal(int amount)
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
    public void Damage(int amount)
    {
        HitPoints -= amount;
    }
}
