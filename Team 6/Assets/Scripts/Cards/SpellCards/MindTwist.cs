using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindTwist : Card
{

    public MindTwist()
    {
        Name = "MindTwist";
        RulesText = "Destroy each opponents hand.";
    }

    public override void DoAction(Hex hex)
    {
        foreach(PlayerData player in Game.Players)
        {
            if(player != Game.GetCurrentPlayer())
            {
                player.GetHand().Cards.Clear();
            }
        }
    }
}
