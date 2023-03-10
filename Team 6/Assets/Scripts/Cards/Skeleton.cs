using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton: Card
{

    public Skeleton()
    {
        Name = "Skeleton";
        Color = "Black";
    }

    public override void DoAction(Hex hex)
    {

        hexMap.SpawnUnitAt(new SkeletonUnit(), hexMap.skeleton, hex.Column, hex.Row);

    }
}
