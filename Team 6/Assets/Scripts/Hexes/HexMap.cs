using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class HexMap : MonoBehaviour 
{

    public GameObject[] Prefabs;

    public static readonly int NumRows = 10;
    public static readonly int NumColumns = 15;

    private static Hex[,] hexes;
    
    public static Dictionary<Hex, GameObject> hexToGameObject;

    public static bool allowWrapEastWest = true;

    private readonly bool debug = false;

    public static bool MakeRandomMap = true;




    void Start()
    {
        Card.setMap(this);
        
        GenerateMap();


    }

    private void Update()
    {
       
        
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
                
                GameObject hexGo = (GameObject)Instantiate(
                 Prefabs[h.GetElevation()],
                 new Vector3(0,0,0),
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
                

                hexGo.name = string.Format("{0},{1}", column, row);


                
                //MeshRenderer mr = hexGo.transform.Find("Model").GetComponentInChildren<MeshRenderer>();
                
                //mr.material = HexMaterials[h.GetElevation()];
                
                hexes[row, column] = h;
                hexToGameObject[h] = hexGo;
              
            }

        }

    }

    public static Hex GetHex(int col, int row)
    {
        return hexes[row, col % NumColumns];
    }

    public static Hex gameObjectToHex(GameObject hex)
    {
        
        foreach(var item in hexToGameObject)
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

        return hexToGameObject[h].GetComponent<HexComponent>().PositionFromCamera();
    }
}
