using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Knives : Card
{
    public Knives()
    {
        Name = "Knives";
        RulesText = "Summon a Knives creature";
        Color = "Black";
    }
    Random random = new Random();

    public override void DoAction(Hex hex)
    {
        GameComponent.SpawnUnitAt(new KnivesUnit(), GameComponent.Knives, hex.Column, hex.Row);
    }
}
