using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand 
{

    public List<Card> cards;

    private int StartingHandSize = 4;
    private int MaxHandSize = 8;



    public Player Owner;

    public Hand(Player player)
    {
        Owner = player;
        cards = new List<Card>();
        while (cards.Count < StartingHandSize)
        {
            Draw();
        }
    }


    public void Draw()
    {
        cards.Add(HexMap.allCards[Random.Range(0, HexMap.allCards.Length)]);

    }


    public void PutInHand(Card card)
    {
        if(cards.Count < MaxHandSize)
        {
            cards.Add(card);
        }
        
    }




}
