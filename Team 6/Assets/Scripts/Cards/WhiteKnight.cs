using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteKnight : Card
{

    public WhiteKnight()
    {
        name = "Knight";
    }

    public override void DoAction(Hex hex)
    {

        hexMap.SpawnUnitAt(new KnightUnit(), hexMap.whiteKnight, hex.Column, hex.Row);

    }
}
