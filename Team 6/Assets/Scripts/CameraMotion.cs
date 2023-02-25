using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{

    private Vector3 oldPosition;
    int speed = 100;

    // Start is called before the first frame update
    void Start()
    {
        oldPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfCameraMoved();

        float xChange = Input.GetAxis("Horizontal");
        float yChange = Input.GetAxis("Vertical");

        Vector3 change = new Vector3(xChange, 0, yChange);

        this.transform.position += change * Time.deltaTime * speed;


    }


    public void PanToHex(Hex hex)
    {

    }

    private void CheckIfCameraMoved()
    {
        if(this.oldPosition != this.transform.position)
        {
            oldPosition = this.transform.position;

            HexComponent[] hexes = GameObject.FindObjectsOfType<HexComponent>();

            foreach(HexComponent hex in hexes)
            {
                hex.UpdatePosition();
            }
        }
    }
}
