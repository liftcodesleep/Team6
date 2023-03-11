using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card 
{
    public string Name;
    public string Description; //TODO Flavor text?
    public string Color;

    public List<Hex> hexes = new List<Hex>();

    public int numTargets = 1;

    public static HexMap hexMap;
    public static GameData Game;
    public static GameComponent GameComponent;

    public static void SetMap(HexMap hexMap)
    {
        Card.hexMap = hexMap;
    }
    public static void SetGameData(GameData GameData)
    {
        Card.Game = GameData;
    }

    public static void SetGameComponent(GameComponent GameComponent)
    {
        Card.GameComponent = GameComponent;
    }

    public abstract void DoAction(Hex hex);



}
