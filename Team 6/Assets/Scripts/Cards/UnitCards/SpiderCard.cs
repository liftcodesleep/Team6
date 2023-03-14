using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Spider : Card
{
    public Spider()
    {
        Name = "Spider";
        RulesText = "Summon a Spider creature";
        Color = "Black";
    }
    Random random = new Random();

    public override void DoAction(Hex hex)
    {
        GameComponent.SpawnUnitAt(new SpiderUnit(), GameComponent.Spiders[random.Next() % 2], hex.Column, hex.Row);
    }
}
