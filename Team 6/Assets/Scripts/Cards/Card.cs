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

    public static void setMap(HexMap hexMap)
    {
        Card.hexMap = hexMap;
    }

    public abstract void DoAction(Hex hex);



}
