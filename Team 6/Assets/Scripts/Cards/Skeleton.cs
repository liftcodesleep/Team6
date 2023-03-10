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
        if(hex == null)
        {
            Debug.Log("null hex");
        }else if (hexMap == null)
        {
            Debug.Log("null map");
        }

        hexMap.SpawnUnitAt(new SkeletonUnit(), hexMap.skeleton, hex.Column, hex.Row);

    }
}
