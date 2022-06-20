using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject menuTurnTowards;

    public GameObject cubeSideFront;
    public GameObject cubeSideLeft;
    public GameObject cubeSideBack;
    public GameObject cubeSideRight;

    public GameObject sideGrab1;
    public GameObject sideGrab2;
    public GameObject sideGrab3;
    public GameObject sideGrab4;


    private int currentSide = 0;    //0 = Front; 1 = Left; 2 = Back; 3 = Right;

    private float currentAngleDifference;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 currentRotation = this.transform.eulerAngles;
    }

    // Spawns the menu on an offset position of the hand or adjusts rotation 
    public void SpawnMenu(Transform transform)
    {
        if (this.gameObject.activeSelf == false)
        {
            this.gameObject.SetActive(true);
            Vector3 offsetPosition = new Vector3(0, 0.15f, 0.1f);
            transform.position += offsetPosition;
            this.gameObject.transform.position = transform.position;
        }
        else
        {
            //AdjustRotation();
        }
    }

    //After rotating, snap rotation into 90 degree angles
    public void RotationUnselectedCheck()
    {
        Vector3 currentRotation = this.transform.eulerAngles;
        while(currentRotation.y > 360)
        {
            currentRotation.y -= 360;
        }
        while (currentRotation.y < 0)
        {
            currentRotation.y += 360;
        }
        Debug.Log(currentRotation);
        if(currentRotation.y > 315 || currentRotation.y <= 45)
        {
            this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, 0.0f + currentAngleDifference, this.transform.eulerAngles.z);
            currentSide = 0;
            cubeSideFront.SetActive(true);
            cubeSideLeft.SetActive(false);
            cubeSideBack.SetActive(false);
            cubeSideRight.SetActive(false);
            sideGrab1.SetActive(true);
            sideGrab2.SetActive(false);
            sideGrab3.SetActive(false);
            sideGrab4.SetActive(true);
        }
        if(currentRotation.y > 45 && currentRotation.y <= 135)
        {
            this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, 90 + currentAngleDifference, this.transform.eulerAngles.z);
            currentSide = 1;
            cubeSideFront.SetActive(false);
            cubeSideLeft.SetActive(true);
            cubeSideBack.SetActive(false);
            cubeSideRight.SetActive(false);
            sideGrab1.SetActive(true);
            sideGrab2.SetActive(true);
            sideGrab3.SetActive(false);
            sideGrab4.SetActive(false);
        }
        if(currentRotation.y > 135 && currentRotation.y <= 225)
        {
            this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, 180 + currentAngleDifference, this.transform.eulerAngles.z);
            currentSide = 2;
            cubeSideFront.SetActive(false);
            cubeSideLeft.SetActive(false);
            cubeSideBack.SetActive(true);
            cubeSideRight.SetActive(false);
            sideGrab1.SetActive(false);
            sideGrab2.SetActive(true);
            sideGrab3.SetActive(true);
            sideGrab4.SetActive(false);
        }
        if(currentRotation.y > 225 && currentRotation.y <= 315)
        {
            this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, 270 + currentAngleDifference, this.transform.eulerAngles.z);
            currentSide = 3;
            cubeSideFront.SetActive(false);
            cubeSideLeft.SetActive(false);
            cubeSideBack.SetActive(false);
            cubeSideRight.SetActive(true);
            sideGrab1.SetActive(false);
            sideGrab2.SetActive(false);
            sideGrab3.SetActive(true);
            sideGrab4.SetActive(true);
        }
    }

    //Shows the adjacent sides of the cube when rotating
    public void StartingRotationSelect()
    {
        if(currentSide == 0)
        {
            cubeSideFront.SetActive(true);
            cubeSideLeft.SetActive(true);
            cubeSideBack.SetActive(false);
            cubeSideRight.SetActive(true);
        }
        if (currentSide == 1)
        {
            cubeSideFront.SetActive(true);
            cubeSideLeft.SetActive(true);
            cubeSideBack.SetActive(true);
            cubeSideRight.SetActive(false);
        }
        if (currentSide == 2)
        {
            cubeSideFront.SetActive(false);
            cubeSideLeft.SetActive(true);
            cubeSideBack.SetActive(true);
            cubeSideRight.SetActive(true);
        }
        if (currentSide == 3)
        {
            cubeSideFront.SetActive(true);
            cubeSideLeft.SetActive(false);
            cubeSideBack.SetActive(true);
            cubeSideRight.SetActive(true);
        }

    }

    //Rotate menu towards hand
    public void AdjustRotation()
    {
        //currentAngleDifference = Vector3.Angle(this.gameObject.transform.forward, (menuTurnTowards.gameObject.transform.position - this.gameObject.transform.position ));
        //this.gameObject.transform.eulerAngles = new Vector3(0, currentAngleDifference, 0);
    }


}
