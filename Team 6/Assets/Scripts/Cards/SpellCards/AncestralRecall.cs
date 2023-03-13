using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncestralRecall : Card
{

    public AncestralRecall()
    {
        Name = "AncestralRecall";
    }

    public override void DoAction(Hex hex)
    {
        Game.GetCurrentPlayer().GetHand().DrawNCards(3);
    }
}
