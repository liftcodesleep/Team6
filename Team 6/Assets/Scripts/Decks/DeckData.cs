using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckData
{

    public List<Card> Cards;

    private int StartingHandSize = 7;
    private int MaxHandSize = 7;



    public PlayerComponent Owner;

    public DeckData(PlayerComponent player)
    {
        Owner = player;
        Cards = new List<Card>();
        while (Cards.Count < StartingHandSize)
        {
            Draw();
        }
    }


    public void Draw()
    {
        Cards.Add(GameData.AllCards[Random.Range(0, GameData.AllCards.Length)]);
    }


    public void PutInHand(Card card)
    {
        if (Cards.Count < MaxHandSize)
        {
            Cards.Add(card);
        }

    }




}
