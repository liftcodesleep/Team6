using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{

    public int totalMana;
    public int currentMana;

    public Hand hand;
    
    public Player()
    {
        totalMana = currentMana = 1;

        this.Name = "Player";
        this.MaxHitPoints = this.HitPoints = 20;
        this.Strength = 1;
        this.Movement = 1;

        hand = new Hand(this);
    }


    public void NewTurn()
    {
        hand.Draw();
        currentMana = totalMana++;
    }



}
