using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitView : MonoBehaviour
{

    private Vector3 oldPostion;
    private Vector3 newPosition;

    private Vector3 currentVelocity;

    float smoothTime = .5f;

    private void Start()
    {
        
        oldPostion = newPosition = this.transform.position;
        
    }


    public void OnUnitMove(Hex oldHex, Hex newHex)
    {


        this.transform.position = oldHex.PositionFromCamera();
        newPosition = newHex.PositionFromCamera();

        currentVelocity = Vector3.zero;

        if(Vector3.Distance(this.transform.position, newPosition) > 2)
        {
            this.transform.position = newPosition;
        }


    }


    private void Update()
    {

       
        

        if (Vector3.Distance(this.transform.position, newPosition) > 2)
        {
            this.transform.position = newPosition;
        }
        
        if(newPosition != oldPostion)
        {
            this.transform.position = Vector3.SmoothDamp(this.transform.position, newPosition, ref currentVelocity, smoothTime);
        }
        


        /*
        Vector3 parentPosition = GetComponentInParent<Transform>().position;

        if (Vector3.Distance(this.transform.position, parentPosition) > 2)
        {
            this.transform.position = parentPosition;
        }
        */
    }
}
