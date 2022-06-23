using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OVRHand;
using static OVRCameraRig;

public class Heizung : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject rightHand;

    public MonoBehaviour RayInteractable;

    public ParticleSystem particleSystemBlue;
    public ParticleSystem particleSystemRed;

    public bool onMenu;


    private float distanceLeft;
    private float distanceRight;
    private float originalRotationY;
    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalRotationY = this.transform.eulerAngles.y;
        originalPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (onMenu == false)
        {
            distanceLeft = Vector3.Distance(transform.position, leftHand.transform.position);
            distanceRight = Vector3.Distance(transform.position, rightHand.transform.position);

            if (distanceLeft <= 0.5 || distanceRight <= 0.5)
            {
                RayInteractable.enabled = false;
            }
            else
            {
                RayInteractable.enabled = true;
            }
        }
        float currentRotationY = this.transform.eulerAngles.y;
        float currentRotationDifference = currentRotationY - originalRotationY;

        if(currentRotationDifference > 180)
        {
            if (particleSystemRed.isPlaying)
            {
                //Do Nothing
            }
            else
            {
                particleSystemRed.Play();
                particleSystemBlue.Pause();
            }
        }
        else
        {
            if (particleSystemBlue.isPlaying)
            {
                //Do Nothing
            }
            else
            {
                particleSystemRed.Pause();
                particleSystemBlue.Play();
            }
        }
    }


    public void InteractHeaterRay()
    {
        Vector3 offsetPosition = rightHand.transform.position;
        //offsetPosition.z += 0.25f;
        this.transform.position = offsetPosition;
        //this.transform.Translate(0, 0, 0.5f);
    }


    public void ReturnToOriginalPosition()
    {
        this.transform.position = originalPosition;
    }



}
