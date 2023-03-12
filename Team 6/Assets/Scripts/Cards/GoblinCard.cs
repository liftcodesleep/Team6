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

        //hexMap.SpawnUnitAt(new GoblinUnit(), hexMap.Goblin, hex.Column, hex.Row);
        GameComponent.SpawnUnitAt(new GoblinUnit(), GameComponent.Goblin, hex.Column, hex.Row);

    }
}
