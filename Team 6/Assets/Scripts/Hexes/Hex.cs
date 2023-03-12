using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


/// <summary>
/// The Hex class defines the grid position, world space position, size,
/// neighbours,etc.. of a Hex Tile. However, it doesn NOT interact with
/// Unity directly in any way.
/// </summary>


public class Hex
{

    public readonly int Column;
    public readonly int Row;
    public readonly int Sum;
    private int Seed;
    private readonly string Name = "Hex.Name";

    public ManaData[] HexMana = new ManaData[5] {new WhiteMana(), new BlueMana(), new BlackMana(), new RedMana(), new GreenMana()};

    private HashSet<Unit> units;

    public Hex(int q, int r)
    {
        this.Column = q;
        this.Row = r;
        this.Sum = -(q + r);
        this.Seed = GenerateSeed();
        HexMana[Seed % 5].SetCount(1);
        this.Name = Seed.ToString();

    }

    public int GetSeed()
    {
        return this.Seed;
    }
    public string GetHexMana()
    {
        return HexMana[0].GetMana() + HexMana[1].GetMana() + HexMana[2].GetMana() + HexMana[3].GetMana() + HexMana[4].GetMana();
    }
    public string GetName()
    {
        return this.Name;
    }
    public int GenerateSeed()
    {

        float scale = 10;
        int LocalSeed =  (int)(Mathf.PerlinNoise((Column + HexDimensions.GetOffset() + (int)(Row/2)) / scale, (Row + HexDimensions.GetOffset()) /scale) * 100) ;

        if (LocalSeed > 99)
        {
            return 16;
        }

        return LocalSeed / 6;
    }


    public void AddUnit(Unit unit)
    {

        if(units == null)
        {
            units = new HashSet<Unit>();
        }

        units.Add(unit);

    }

    public void RemoveUnit(Unit unit)
    {
        if(units != null)
        {
            units.Remove(unit);
        }
    }

    public Unit[] Units()
    {
        return units.ToArray();
    }

    public int BaseMovementCost()
    {
        return 1;
    }



    public float DistanceFrom(Hex b)
    {

        int dQ = Mathf.Abs(this.Column - b.Column);

        if (dQ > HexMap.NumColumns / 2)
        {
            dQ = HexMap.NumColumns - dQ;
        }

        int dS = Mathf.Abs(this.Sum - b.Sum);
        if(dS > HexMap.NumColumns / 2)
        {
            dS =  Mathf.Abs(dS - HexMap.NumColumns) ;
        }
        
        return Mathf.Max(
            dQ,
            Mathf.Abs(this.Row - b.Row),
            dS
            );
    }


}
