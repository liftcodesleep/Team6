using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    private DeckData deck;
    private Hand hand;
    private HandComponent handComponent;
    private List<Unit> Units;
    private string Name;
    private int ManaAvailable = 0;
    private int ManaMax;

    public Color color;

    public void SetName(string NewName)
    {
        this.Name = NewName;
    }
    public void SetHand(Hand NewHand)
    {
        this.hand = NewHand;
    }
    public void SetHandComponent(HandComponent NewHandComponent)
    {
        this.handComponent = NewHandComponent;
    }
    public void SetDeck(DeckData NewDeck)
    {
        this.deck = NewDeck;
    }
    public string GetName()
    {
        return this.Name;
    }
    public string GetMana()
    {
        return this.ManaAvailable.ToString();
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
