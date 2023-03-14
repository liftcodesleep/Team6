using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncestralRecall : Card
{

    public AncestralRecall()
    {
        Name = "AncestralRecall";
        RulesText = "Draw 3 cards.";
    }

    public override void DoAction(Hex hex)
    {
        Game.GetCurrentPlayer().GetHand().DrawNCards(3);
    }
}
