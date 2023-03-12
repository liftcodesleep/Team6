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
        hexes.Add(hex);
        GameComponent.SpawnUnitAt(new KnightUnit(), GameComponent.WhiteKnight, hex.Column, hex.Row);
    }
}
