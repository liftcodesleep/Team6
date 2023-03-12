using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ManaData
{
    private char Type = 'M';
    private int Count = 0;

    public string GetMana()
    {
        string ManaProduction = new string (Type, Count);
        return ManaProduction;
    }
    public void SetCount(int NewCount)
    {
        this.Count = NewCount;
    }
    public void SetType(char NewType)
    {
        this.Type = NewType;
    }
}
