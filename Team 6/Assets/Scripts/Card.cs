using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card 
{
    public string name;

    public static HexMap hexMap;

    public static void setMap(HexMap hexMap)
    {
        Card.hexMap = hexMap;
    }

    public abstract void DoAction(Hex hex);



}
