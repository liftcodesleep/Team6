using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur : Card
{
    public Minotaur()
    {
        Name = "Minotaur";
        RulesText = "Summon a Minotaur creature";
        Color = "Red";
    }
    public override void DoAction(Hex hex)
    {
        GameComponent.SpawnUnitAt(new MinotaurUnit(), GameComponent.Minotaur, hex.Column, hex.Row);
    }
}
