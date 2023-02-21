using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class HexMap : MonoBehaviour 

{



 // Use this for initialization

 void Start () 

 {

  GenerateMap ();

  

 }



 public GameObject HexPrefab;



 public Material[] HexMaterials;



 public readonly int NumRows = 60;

 public readonly int NumColumns = 120;



 //int numRows = 20;

 //int numColumns = 40;



 public void GenerateMap()

 {

  for (int column = 0; column < NumColumns; column++) 

  {

   for (int row = 0; row < NumRows; row++) 

   {

    //Instantiate a Hex

    Hex h = new Hex( column, row );



    Vector3 pos = h.PositionFromCamera (

     Camera.main.transform.position,

     NumRows,

     NumColumns

    );



    GameObject hexGo = (GameObject)Instantiate (

     HexPrefab,

     pos,

     Quaternion.identity,

     this.transform

     );

    MeshRenderer mr = hexGo.GetComponentInChildren<MeshRenderer> ();

    mr.material = HexMaterials [Random.Range (0, HexMaterials.Length)];

   }

  }

 }

}
