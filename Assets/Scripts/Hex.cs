using System.Collections;

using System.Collections.Generic;

using UnityEngine;





/// <summary>

/// The Hex class defines the grid position, world space position, size,

/// neighbours,etc.. of a Hex Tile. However, it doesn NOT interact with 

/// Unity directly in any way.

/// </summary>





public class Hex{



 public Hex(int q, int r)

 {

  this.Q = q;

  this.R = r;

  this.S = -(q + r); 

 }



 // Q + R + S = 0

 // S = - (Q+R)



 public readonly int Q;  //Column

 public readonly int R;  // Row

 public readonly int S;  //Some --- Not need



 static readonly float WIDTH_MULTIPLIER = Mathf.Sqrt (3) / 2;



 float radius = 1f;

 bool allowWrapEastWest = true;

 bool allowWrapNorthSouth = false;





 /// <summary>

 /// Returns the world space position on this hex

 /// </summary>

 public Vector3 Position()

 {  

  return new Vector3 (  

   HexHorizontalSpacing() * (this.Q + this.R/2f),

   0,

   HexVerticalSpacing() * this.R  

  ); 



 }



 public float HexHeight()

 {

  return radius * 2;

 }



 public float HexWidth()

 {

  return WIDTH_MULTIPLIER * HexHeight();

 }



 public float HexVerticalSpacing()

 {

  return HexHeight() * 0.75f;

 }





 public float HexHorizontalSpacing()

 {

  return HexWidth ();

 }



 public Vector3 PositionFromCamera( Vector3 cameraPosition, float numRows, float numColumns)

 {

  float mapHeight = numRows * HexVerticalSpacing ();

  float mapWidth = numColumns * HexHorizontalSpacing ();



  Vector3 position = Position ();



  if (allowWrapEastWest) 

  {

   float howManyWidthsFromCamera = (position.x - cameraPosition.x) / mapWidth;



   //We want howmanyWidthsFromCamera to be between -0.5 to 0.5

   if (howManyWidthsFromCamera > 0)

    howManyWidthsFromCamera += 0.5f;

   else

    howManyWidthsFromCamera -= 0.5f;



   int howManyWidthToFix = (int)howManyWidthsFromCamera;



   position.x -= howManyWidthToFix * mapWidth;



  }

     

  if(allowWrapNorthSouth) 

  {

   float howManyHeightsFromCamera = (position.z - cameraPosition.z) / mapHeight;



   //We want howmanyWidthsFromCamera to be between -0.5 to 0.5

   if (howManyHeightsFromCamera > 0)

    howManyHeightsFromCamera += 0.5f;

   else

    howManyHeightsFromCamera -= 0.5f;



   int howManyHeightsToFix = (int)howManyHeightsFromCamera;



   position.z -= howManyHeightsToFix * mapHeight;

  }

   return position; 

 }







}
