using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton: Card
{

    public Skeleton()
    {
        Name = "Skeleton";
        RulesText = "Summon a Skeleton creature";
        Color = "Black";
    }

    public override void DoAction(Hex hex)
    {
        GameComponent.SpawnUnitAt(new SkeletonUnit(), GameComponent.Skeleton, hex.Column, hex.Row);
    }
}
