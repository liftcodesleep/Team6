using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur : Card
{
    public Minotaur()
    {
        Name = "Minotaur";
        Color = "Red";
    }
    public override void DoAction(Hex hex)
    {

        hexMap.SpawnUnitAt(new MinotaurUnit(), hexMap.minotaur, hex.Column, hex.Row);

    }
}
