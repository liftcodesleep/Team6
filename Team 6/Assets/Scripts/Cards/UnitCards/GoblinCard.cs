using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Card
{

    public Goblin()
    {
        Name = "Goblin";
        RulesText = "Summon a Goblin creature";
        Color = "Red";
    }

    public override void DoAction(Hex hex)
    {
        GameComponent.SpawnUnitAt(new GoblinUnit(), GameComponent.Goblin, hex.Column, hex.Row);
    }
}
