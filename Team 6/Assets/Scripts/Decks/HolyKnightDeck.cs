using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyKnightDeck : Deck
{
    public HolyKnightDeck()
    {
        Cards.Add(WhiteKnight);
        Cards.Add(HolyStrength);
    }
    public override void DrawNCards(int n)
    {

    }

}
