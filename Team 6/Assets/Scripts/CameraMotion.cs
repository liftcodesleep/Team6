using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{

    private Vector3 oldPosition;

    // Start is called before the first frame update
    void Start()
    {
        oldPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfCameraMoved();
    }


    public void PanToHex(Hex hex)
    {

    }

    private void CheckIfCameraMoved()
    {
        if(this.oldPosition != this.transform.position)
        {
            Debug.Log("Moved");

            oldPosition = this.transform.position;

            HexComponent[] hexes = GameObject.FindObjectsOfType<HexComponent>();

            foreach(HexComponent hex in hexes)
            {
                hex.UpdatePosition();
            }
        }
    }
}
