using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card 
{
    public string Name;
    public string description; //TODO Flavor text?
    public string Color;

    public List<Hex> hexes = new List<Hex>();

    public int numTargets = 1;

    public static HexMap hexMap;
    public static GameData GameData;
    public static GameComponent GameComponent;

    public static void setMap(HexMap hexMap)
    {
        Card.hexMap = hexMap;
    }
    public static void setGameData(GameData GameData)
    {
        Card.GameData = GameData;
    }

    public static void setGameComponent(GameComponent GameComponent)
    {
        Card.GameComponent = GameComponent;
    }

    public abstract void DoAction(Hex hex);



}
