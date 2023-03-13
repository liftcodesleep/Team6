using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    private DeckData deck;
    private Hand hand;
    private Unit Avatar;
    private HandComponent handComponent;
    private List<Unit> Units = new List<Unit>(); //Should be hash set
    private string Name;
    private int ManaAvailable = 0;
    private int ManaMax;


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
    public void SetAvatar(Unit unit)
    {
        this.Avatar = unit;
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
    public List<Unit> GetUnits()
    {
        return this.Units;
    }
    public Unit GetAvatar()
    {
        return this.Avatar;
    }
}
