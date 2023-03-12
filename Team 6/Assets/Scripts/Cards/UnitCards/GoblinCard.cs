using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Card
{

    public Goblin()
    {
        Name = "Goblin";
        Color = "Red";
    }

    public override void DoAction(Hex hex)
    {
        GameComponent.SpawnUnitAt(new GoblinUnit(), GameComponent.Goblin, hex.Column, hex.Row);
    }
}
