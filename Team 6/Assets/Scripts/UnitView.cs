using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitView : MonoBehaviour
{

    private Vector3 oldPostion;
    private Vector3 newPosition;

    private Vector3 currentVelocity;
    private GameObject healthBar;
    private Vector3 healthBarSize;
    float smoothTime = .1f;

    public  Unit unit;

    private float shrinkSpeed = .9f;
    

    private void Start()
    {
        
        oldPostion = newPosition = this.transform.position;

        healthBar = this.transform.Find("Health").gameObject;
        healthBarSize = healthBar.transform.localScale;
        unit = HexMap.gameObjectToUnit(this.gameObject);

        //healthBar.transform.localScale *= .5f;

    }


    public void OnUnitMove(Hex oldHex, Hex newHex)
    {


        //this.transform.position = oldHex.PositionFromCamera();
        newPosition = newHex.PositionFromCamera();

        currentVelocity = Vector3.zero;

       


    }

    public void updateHealthBar()
    {
        healthBar.transform.localScale *= (float)unit.HitPoints/(float)unit.MaxHitPoints;
    }


    private void Update()
    {

        if (unit.HitPoints <=0 )
        {
            this.gameObject.transform.localScale *= shrinkSpeed;
        }

        if (this.gameObject.transform.localScale.magnitude < .1f)
        {
            Destroy(this.gameObject);
            return;
        }
        /*
        if (Vector3.Distance(this.transform.position, newPosition) > 2)
        {
            this.transform.position = newPosition;
        }
        */
        if(newPosition != oldPostion)
        {
            this.transform.position = Vector3.SmoothDamp(this.transform.position, newPosition, ref currentVelocity, smoothTime);

            if(Mathf.Abs(this.transform.position.magnitude - newPosition.magnitude) < .001f)
            {
                oldPostion = newPosition;
            }
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
