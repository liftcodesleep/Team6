using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class HexMap : MonoBehaviour 
{

    public GameObject[] Prefabs;


    public GameObject[] IslandPrefabs;
    public GameObject[] SwampPrefabs;
    public GameObject[] PlanesPrefabs;
    public GameObject[] ForestPrefabs;
    public GameObject[] MontainPrefabs;


    public static readonly int NumRows = 10;
    public static readonly int NumColumns = 15;

    private static Hex[,] hexes;
    
    public static Dictionary<Hex, GameObject> HexToGameObject;

    public static bool AllowWrapEastWest = true;

    private readonly bool debug = false;

    public static bool MakeRandomMap = true;

    void Start()
    {
        GenerateMap();
    }

    private void Update()
    {
       
        
    }
    public void GenerateMap()
    {
        hexes = new Hex[NumRows, NumColumns];
        HexToGameObject = new Dictionary<Hex, GameObject>();

        for (int column = 0; column < NumColumns; column++)
        {
            for (int row = 0; row < NumRows; row++)
            {

                Hex h = new Hex(column, row);

                GameObject hexLooks = Prefabs[h.GetSeed()];

                hexLooks = GetPrefab(h);

                GameObject hexGo = (GameObject)Instantiate(
                 hexLooks,
                 new Vector3(0, 0, 0),
                 Quaternion.identity,
                 this.transform
                 );

                HexComponent component = hexGo.GetComponent<HexComponent>();

                component.hex = h;
                component.hexMap = this;

                hexGo.transform.position = component.PositionFromCamera();

                if (debug)
                {
                    hexGo.GetComponentInChildren<TextMesh>().text = string.Format("{0},{1}", column, row);
                }
                else
                {
                    hexGo.GetComponentInChildren<TextMesh>().text = "";
                }

                //TODO name should be capitalized and relfect hex type/prefab/identity
                hexGo.name = string.Format("{0},{1}", column, row);



                //MeshRenderer mr = hexGo.transform.Find("Model").GetComponentInChildren<MeshRenderer>();

                //mr.material = HexMaterials[h.GetElevation()];

                hexes[row, column] = h;
                HexToGameObject[h] = hexGo;

            }

        }

    }

    public static Hex GetHex(int col, int row)
    {
        return hexes[row, col % NumColumns];
    }

    public static Hex GameObjectToHex(GameObject hex)
    {
        
        foreach(var item in HexToGameObject)
        {
            if(item.Value == hex)
            {
                return item.Key;
            }
        }

        return null;

    }

    public static Vector3 GetHexPosition(int q, int r)
    {

        Hex h = GetHex(q, r);

        return GetHexPosition(h);
    }

    public static Vector3 GetHexPosition(Hex h)
    {

        return HexToGameObject[h].GetComponent<HexComponent>().PositionFromCamera();
    }



    private GameObject GetPrefab(Hex h)
    {

        GameObject hexLooks = Prefabs[h.GetSeed()];
        int typeOfHex = h.CalcuateStyle();

        if (typeOfHex == 0)
        {
            hexLooks = GetIslandPreFab(h);
        }
        else if (typeOfHex == 1)
        {
            hexLooks = GetSwampPreFab( h);
        }
        else if (typeOfHex == 2)
        {
            hexLooks = GetPlainsPreFab(h);
        }
        else if (typeOfHex == 3)
        {
            hexLooks = ForestPrefabs[0];
        }
        else
        {
            hexLooks = GetMountainPreFab(h);
        }

        return hexLooks;
    }


    private GameObject GetIslandPreFab(Hex h)
    {
        int chance = Random.Range(0, 100);

        if (chance < 90)
        {
            return IslandPrefabs[0];
        }
        else if (chance < 98)
        {
            return IslandPrefabs[1];
        }
        else
        {
            return IslandPrefabs[2];
        }
    }


    private GameObject GetSwampPreFab(Hex h)
    {
       

        if (h.elevation < 50)
        {
            return SwampPrefabs[0];
        }
        else 
        {
            return SwampPrefabs[1];
        }
        
    }

    private GameObject GetPlainsPreFab(Hex h)
    {


        if (Random.Range(0,50) == 1)
        {
            return PlanesPrefabs[1];
        }
        else
        {
            return PlanesPrefabs[0];
        }

    }

    private GameObject GetMountainPreFab(Hex h)
    {
        if (h.elevation < 30)
        {
            return MontainPrefabs[2];
        }
        else if (h.elevation < 50)
        {
            return MontainPrefabs[3];
        }
        else if (h.elevation < 85)
        {
            return MontainPrefabs[0];
        }
        else
        {
            return MontainPrefabs[1];
        }

    }


}
