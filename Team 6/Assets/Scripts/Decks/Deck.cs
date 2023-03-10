using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Deck
{
    public List<Card> Cards = new List<Card>();
    public abstract void DrawNCards(int n);
}
