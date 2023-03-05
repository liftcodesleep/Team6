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

    private static int offset = Random.Range(0, 200);

    private HashSet<Unit> units;
    public Hex(int q, int r)
    {
        this.Column = q;
        this.Row = r;
        this.Sum = -(q + r);

        Random.InitState(42); // Random.seed = 42;
    }


    public int GetElevation()
    {

        float scale = 10;
        int elevation =  (int)(Mathf.PerlinNoise((Column+ offset+(int)(Row/2)) / scale, (Row+offset)/scale) * 100) ;

        if (elevation > 99)
        {
            return 4;
        } 
        
        return elevation / 20;
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
