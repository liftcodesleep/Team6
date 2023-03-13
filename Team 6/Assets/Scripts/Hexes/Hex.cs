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

    public int elevation;

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
        this.units = new HashSet<Unit>();

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
    public HashSet<Unit> GetUnits()
    {
        return units;
    }

    public int GenerateSeed()
    {
        float smoothness = 1;
        int elevationChange = -10;
        float scale = 10;
        //int LocalSeed =  (int)(Mathf.PerlinNoise((Column + HexDimensions.GetOffset() + (int)(Row/2)) / scale, (Row + HexDimensions.GetOffset()) /scale) * 100) ;
        int LocalSeed = (int)(Mathf.PerlinNoise(((Column* smoothness) + HexDimensions.GetOffset() + (int)(Row / 2)) / scale, ((Row* smoothness) + HexDimensions.GetOffset()) / scale) * 100);

        LocalSeed += elevationChange;
        if (LocalSeed > 99)
        {
            LocalSeed =  99;
        }else if(LocalSeed < 0)
        {
            LocalSeed = 0;
        }

        return (LocalSeed) / 7;
    }

    public int CalcuateStyle()
    {
        float smoothness = 1;
        
        float scale = 10;
        
        //int LocalSeed = (int)(Mathf.PerlinNoise(((Column * smoothness) + HexDimensions.GetOffset() + (int)(Row / 2)) / scale, ((Row * smoothness) + HexDimensions.GetOffset()) / scale) * 100);

        elevation = (int)(Mathf.PerlinNoise(((Column * smoothness) + HexDimensions.GetOffset() + (int)(Row / 2)) / scale, ((Row * smoothness) + HexDimensions.GetOffset()) / scale) * 100);



        if (elevation > 75)
        {

            return 4;
        }
        else if (elevation > 53)
        {
            if(Random.Range(0,20) == 1)
            {
                return 0;
            }

            if (Random.Range(0, 10) == 1)
            {
                return 1;
            }
            return 3;
        }
        else if (elevation > 38)
        {
            if (Random.Range(0, 20) == 1)
            {
                return 0;
            }
            if (Random.Range(0, 30) == 1)
            {
                return 4;
            }
            return 2;
        }
        else if (elevation > 28)
        {
            if (Random.Range(0, 30) == 1)
            {
                return 4;
            }
            return 1;
        }
        else
        {
            if (Random.Range(0, 30) == 1)
            {
                return 4;
            }
            return 0;
        }


    }


    public void AddUnit(Unit unit)
    {
        units.Add(unit);
    }

    public void RemoveUnit(Unit unit)
    {
        if(units != null)
        {
            units.Remove(unit);
        }
    }

    public Unit[] GetUnitsArray()
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
