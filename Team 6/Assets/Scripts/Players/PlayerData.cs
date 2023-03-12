using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    private DeckData deck;
    private Hand hand;
    private List<Unit> Units;
    private string Name;
    private int ManaAvailable;
    private int ManaMax;

    public string GetName()
    {
        return this.Name;
    }
    public void SetName(string name)
    {
        this.Name = name;
    }
    public void SetHand(Hand NewHand)
    {
        this.hand = NewHand;
    }
    public void SetDeck(DeckData NewDeck)
    {
        this.deck = NewDeck;
    }
    public string GetMana()
    {
        return "Mana available: " + this.ManaAvailable.ToString();
    }
    public Hand GetHand()
    {
        return this.hand;
    }
    public DeckData GetDeck()
    {
        return this.deck;
    }
}
