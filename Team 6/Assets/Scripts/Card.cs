using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card 
{
    public string name;

    public List<Hex> hexes = new List<Hex>();

    public int numTargets = 1;

    public static HexMap hexMap;

    public static void setMap(HexMap hexMap)
    {
        Card.hexMap = hexMap;
    }

    public abstract void DoAction(Hex hex);



}
