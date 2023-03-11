using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Knives : Card
{
    public Knives()
    {
        Name = "Knives";
        Color = "Black";
    }
    Random random = new Random();

    public override void DoAction(Hex hex)
    {
        hexMap.SpawnUnitAt(new KnivesUnit(), hexMap.Knives, hex.Column, hex.Row);

    }
}
