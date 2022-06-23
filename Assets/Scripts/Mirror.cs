using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public GameObject handRight;
    public GameObject handLeft;
    public Camera camera;


    private int handInRangeCount = 0;

    private float oldHandDistance = 0;
    private float newHandDistance = 0;

    private bool leftHandinPosition = false;
    private bool rightHandinPosition = false;
    private bool everythingInPosition = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If hands not in position or range, reset distance
        if(everythingInPosition == true && (handInRangeCount < 2 || !leftHandinPosition || !rightHandinPosition))
        {
            everythingInPosition = false;
            oldHandDistance = 0;
            newHandDistance = 0;
        }

        //If both hands in range and position
        if(handInRangeCount >= 2 && leftHandinPosition && rightHandinPosition)
        {
            everythingInPosition = true;
            Debug.Log("YES");
        }

        //Change FOV of Camera depending on distance between hands
        if (everythingInPosition)
        {
            newHandDistance = Vector3.Distance(handLeft.transform.position, handRight.transform.position);
            if(oldHandDistance == 0) { oldHandDistance = newHandDistance;}
            else
            {
                if (newHandDistance > oldHandDistance && camera.fieldOfView < 110)
                {
                    camera.fieldOfView += 1;
                }
                else if(newHandDistance < oldHandDistance && camera.fieldOfView > 50)
                {
                    camera.fieldOfView -= 1;
                }
            }
        }
    }

    //Check left hand position
    public void LeftHandInPosition()
    {
        if (leftHandinPosition)
        {
            leftHandinPosition = false;
        }
        else
        {
            leftHandinPosition = true;
        }
    }

    //Check right hand position
    public void RightHandInPosition()
    {
        if (rightHandinPosition)
        {
            rightHandinPosition = false;
        }
        else
        {
            rightHandinPosition = true;
        }
    }

    //Adds to counter if hand enters range of mirror
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Gloves")
        {
            handInRangeCount += 1;
        }
    }

    //Removes from counter if hand exits range of mirror
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Gloves")
        {
            handInRangeCount -= 1;
        }
    }


}
