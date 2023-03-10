using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteKnight : Card
{

    public WhiteKnight()
    {
        Name = "Knight";
        Color = "White";
    }

    public override void DoAction(Hex hex)
    {

        hexMap.SpawnUnitAt(new KnightUnit(), hexMap.WhiteKnight, hex.Column, hex.Row);

    }
}
