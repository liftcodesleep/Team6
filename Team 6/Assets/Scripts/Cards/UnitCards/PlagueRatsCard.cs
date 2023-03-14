using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueRats : Card
{
    public PlagueRats()
    {
        Name = "PlagueRats";
        RulesText = "Summon a PlagueRats creature";
        Color = "Black";
    }
    public override void DoAction(Hex hex)
    {
        GameComponent.SpawnUnitAt(new PlagueRatsUnit(), GameComponent.PlagueRats, hex.Column, hex.Row);
    }
}
