using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexComponent : MonoBehaviour
{

    public Hex hex;
    public HexMap hexMap;


    private void Start()
    {
        this.transform.localScale = new Vector3(.01f, .01f, .01f);
    }

    private void Update()
    {
        if (this.transform.localScale.x < 1)
        {
            this.transform.localScale += new Vector3(.02f, .02f, .02f);
        }
    }

    public Vector3 Position()
    {

        return new Vector3(
         HexCalculator.HexHorizontalSpacing() * (this.hex.Column + this.hex.Row / 2f),
         0,
         HexCalculator.HexVerticalSpacing() * this.hex.Row
        );

    }

    public void UpdatePosition()
    {
        this.transform.position = this.PositionFromCamera();
    }


    public Vector3 PositionFromCamera()
    {
        Vector3 cameraPosition = Camera.main.transform.position;

        float mapHeight = HexMap.NumRows * HexCalculator.HexVerticalSpacing();
        float mapWidth = HexMap.NumColumns * HexCalculator.HexHorizontalSpacing();

        Vector3 position = Position();

        if (HexMap.AllowWrapEastWest)

        {

            float howManyWidthsFromCamera = (position.x - cameraPosition.x) / mapWidth;


            //We want howmanyWidthsFromCamera to be between -0.5 to 0.5

            if (howManyWidthsFromCamera > 0)
            {
                howManyWidthsFromCamera += 0.5f;
            }
            else
            {
                howManyWidthsFromCamera -= 0.5f;
            }

            int howManyWidthToFix = (int)howManyWidthsFromCamera;


            position.x -= howManyWidthToFix * mapWidth;

        }

        //Deprecated but useful to have written
        /*        if (HexMap.allowWrapNorthSouth)
                {

                    float howManyHeightsFromCamera = (position.z - cameraPosition.z) / mapHeight;

                    //We want howmanyWidthsFromCamera to be between -0.5 to 0.5

                    if (howManyHeightsFromCamera > 0)
                    {
                        howManyHeightsFromCamera += 0.5f;
                    }
                    else
                    {
                        howManyHeightsFromCamera -= 0.5f;
                    }

                    int howManyHeightsToFix = (int)howManyHeightsFromCamera;

                    position.z -= howManyHeightsToFix * mapHeight;

                }
        */
                return position;

            }
            
        /*
        public Vector3 PositionFromCamera()
        {
            return HexMap.GetHexPosition(hex);
        }
        */
        public Vector3 PositionFromCamera(Vector3 cameraPosition)
        {

            float mapHeight = HexMap.NumRows * HexDimensions.HexVerticalSpacing();
            float mapWidth = HexMap.NumColumns * HexDimensions.HexHorizontalSpacing();

            Vector3 position = this.Position();


            if (HexMap.AllowWrapEastWest)

            {

                float howManyWidthsFromCamera = (position.x - cameraPosition.x) / mapWidth;


                //We want howmanyWidthsFromCamera to be between -0.5 to 0.5

                if (howManyWidthsFromCamera > 0)
                {
                    howManyWidthsFromCamera += 0.5f;
                }
                else
                {
                    howManyWidthsFromCamera -= 0.5f;
                }

                int howManyWidthToFix = (int)howManyWidthsFromCamera;


                position.x -= howManyWidthToFix * mapWidth;

            }


            /*if (HexMap.allowWrapNorthSouth)
            {

                float howManyHeightsFromCamera = (position.z - cameraPosition.z) / mapHeight;

                //We want howmanyWidthsFromCamera to be between -0.5 to 0.5

                if (howManyHeightsFromCamera > 0)
                {
                    howManyHeightsFromCamera += 0.5f;
                } else
                {
                    howManyHeightsFromCamera -= 0.5f;
                }

                int howManyHeightsToFix = (int)howManyHeightsFromCamera;

                position.z -= howManyHeightsToFix * mapHeight;

            }
            */
            return position;

        }
    }

