using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class HexMap : MonoBehaviour 

{

    public GameObject HexPrefab;
    public Material[] HexMaterials;
    public readonly int NumRows = 50;
    public readonly int NumColumns = 50;

    private Hex[,] map;

    //int numRows = 20;
    //int numColumns = 40;

    public void GenerateMap()
    {
        map = new Hex[NumRows,NumColumns];

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

                hexGo.GetComponentInChildren<TextMesh>().text = string.Format("{0},{1}", column, row);

                MeshRenderer mr = hexGo.GetComponentInChildren<MeshRenderer>();
                
                //mr.material = HexMaterials[Random.Range(0, HexMaterials.Length)];
                mr.material = HexMaterials[h.getElevation()];
                
                map[row, column] = h;
              
            }

        }

    }



    void Start()
    {
        
        GenerateMap();

    }


}
