using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Specter : Card
{
    public Specter()
    {
        Name = "Specter";
        Color = "Black";
    }

    public override void DoAction(Hex hex)
    {

        hexMap.SpawnUnitAt(new SpecterUnit(), hexMap.specter, hex.Column, hex.Row);

    }
}