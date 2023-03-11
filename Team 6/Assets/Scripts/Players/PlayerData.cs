using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    private DeckData deck;
    private DeckData hand;
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
    public string GetMana()
    {
        return "Mana available: " + this.ManaAvailable.ToString();
    }
    public DeckData GetHand()
    {
        return this.hand;
    }
}
