using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton: Card
{

    public Skeleton()
    {
        name = "Skeleton";
    }

    public override void DoAction(Hex hex)
    {

        hexMap.SpawnUnitAt(new SkeletonUnit(), hexMap.skeleton, hex.Column, hex.Row);

    }
}
