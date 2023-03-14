using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteKnight : Card
{

    public WhiteKnight()
    {
        Name = "Knight";
        RulesText = "Summon a White Knight creature";
        Color = "White";
    }

    public override void DoAction(Hex hex)
    {
        GameComponent.SpawnUnitAt(new KnightUnit(), GameComponent.WhiteKnight, hex.Column, hex.Row);
    }
}
