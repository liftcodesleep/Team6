using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class HexMap : MonoBehaviour 
{

    public GameObject HexPrefab;
    public Material[] HexMaterials;
    public static readonly int NumRows = 30;
    public static readonly int NumColumns = 30;

    public GameObject unit;

    private static Hex[,] hexes;
    private HashSet<Unit> units;

    private Dictionary<Hex, GameObject> hexToGameObject;
    private Dictionary<Unit, GameObject> unitToGameObject;

    //int numRows = 20;
    //int numColumns = 40;
    void Start()
    {

        GenerateMap();
        Unit u = new Unit();

        SpawnUnitAt(u, unit, 5, 5);

    }

    private void Update()
    {
        if(units != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                foreach (Unit unit in units)
                {
                    unit.DoTurn();
                }
            }
        }
        
    }
    public void GenerateMap()
    {
        hexes = new Hex[NumRows,NumColumns];
        hexToGameObject = new Dictionary<Hex, GameObject>();

        for (int column = 0; column < NumColumns; column++)
        {
            for (int row = 0; row < NumRows; row++)
            {

                Hex h = new Hex(column, row);
                
                
                Vector3 pos = h.PositionFromCamera(
                 Camera.main.transform.position,
                 NumRows,
                 NumColumns
                );
                
                GameObject hexGo = (GameObject)Instantiate(
                 HexPrefab,
                 pos,
                 Quaternion.identity,
                 this.transform
                 );

                HexComponent component = hexGo.GetComponent<HexComponent>();

                component.Hex = h;
                component.HexMap = this;

                hexGo.GetComponentInChildren<TextMesh>().text = string.Format("{0},{1}",column,row);

                hexGo.name = string.Format("{0},{1}", column, row);

                MeshRenderer mr = hexGo.GetComponentInChildren<MeshRenderer>();
                
                //mr.material = HexMaterials[Random.Range(0, HexMaterials.Length)];
                mr.material = HexMaterials[h.GetElevation()];
                
                hexes[row, column] = h;
                hexToGameObject[h] = hexGo;
              
            }

        }

    }

    public static Hex GetHex(int col, int row)
    {
        return hexes[row, col % NumColumns];
    }

    public static float distanceFrom2Hexs(Hex a, Hex b)
    {

        int dQ = Mathf.Abs(a.Q - b.Q);
        
        if (dQ > NumColumns / 2)
        {
            dQ = NumColumns - dQ;
        }

        return Mathf.Max(
            dQ,
            Mathf.Abs(a.R - b.R),
            Mathf.Abs(a.S - b.S)
            );
    }

    public static Vector3 GetHexPosition(int q, int r)
    {

        Hex h = GetHex(q, r);

        return GetHexPosition(h);
    }

    public static Vector3 GetHexPosition(Hex h)
    {

        return h.PositionFromCamera(Camera.main.transform.position, NumRows, NumColumns);
    }

    public void SpawnUnitAt(Unit unit, GameObject prefab, int col, int  row)
    {

        if(units == null)
        {
            units = new HashSet<Unit>();
            unitToGameObject = new Dictionary<Unit, GameObject>();
        }

        Hex spawnedHex = GetHex(col, row);
        GameObject spawpoint = hexToGameObject[spawnedHex];
        unit.SetHex(spawnedHex);
        GameObject unitGO = Instantiate(prefab, spawpoint.transform.position, Quaternion.identity, spawpoint.transform);

        unit.OnUnitMoved += unitGO.GetComponent<UnitView>().OnUnitMove;
        unit.OnUnitMoved(spawnedHex, spawnedHex);

        units.Add(unit);
        unitToGameObject[unit] = unitGO;
    }

}
