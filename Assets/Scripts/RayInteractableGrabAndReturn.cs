using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayInteractableGrabAndReturn : MonoBehaviour
{
    public GameObject hand;

    private Vector3 oldPosition;

    // Start is called before the first frame update
    void Start()
    {
        oldPosition = this.transform.position;
    }

    // Teleports gameobject to hand position
    public void OnRayInteractionSelect()
    {
        this.gameObject.transform.position = hand.transform.position;
    }

    // Teleports gameibject back to original position
    public void OnGrabInteractionUnselect()
    {
        this.gameObject.transform.position = oldPosition;
    }

}
