using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Specter : Card
{
    public Specter()
    {
        Name = "Specter";
        RulesText = "Summon a Specter creature";
        Color = "Black";
    }

    public override void DoAction(Hex hex)
    {
        GameComponent.SpawnUnitAt(new SpecterUnit(), GameComponent.Specter, hex.Column, hex.Row);
    }
}
