using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{
    public GameObject textMeshObject;

    private bool isInTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        textMeshObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    // If collided with flat wall, set text object active and change rotation to that of wall
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "FlatWall")
        {
            textMeshObject.SetActive(true);
            Quaternion mirroredRotation = other.transform.rotation;
            mirroredRotation.y *= -1;
            textMeshObject.transform.rotation = mirroredRotation;
            isInTrigger = true;
        }
    }

    // On exit, deactivate textobject
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "FlatWall")
        {
            isInTrigger = false;
            var renderers = this.GetComponentsInChildren<MeshRenderer>();
            foreach (var x in renderers)
            {
                x.enabled = true;
            }
        }
    }

    // Activate and deactivate 3D and 2D models
    public void From3DTo2DAndReverse()
    {
        if (isInTrigger == false)
        {
            textMeshObject.SetActive(false);
        }

        if (isInTrigger == true)
        {
            var renderers = this.GetComponentsInChildren<MeshRenderer>();
            foreach(var x in renderers)
            {
                x.enabled = false;
            }
            textMeshObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }


}
