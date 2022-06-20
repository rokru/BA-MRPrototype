using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicateTableObject : MonoBehaviour
{
    public GameObject emptyParentObject;
    public GameObject hand;

    public Material standartMaterial;
    public Material newMaterial;


    private GameObject copyEmptyGameObject;
    private GameObject copyGameObject;

    private Material standartMaterialSave;

    private float objectChangeCountdown = 5.0f;
   
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Renderer>().material = standartMaterial;
        standartMaterialSave = this.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        // After timer check if change material (to instantiate a visible change of the object)
        if (objectChangeCountdown <= 0)
        {
            if(this.GetComponent<Renderer>().material.name == "LightBlue (Instance)")
            {
                this.GetComponent<Renderer>().material = newMaterial;
            }
            else
            {
                this.GetComponent<Renderer>().material = standartMaterial;
            }
            objectChangeCountdown = 5.0f;
        }
        else
        {
            objectChangeCountdown -= Time.deltaTime;
        }

        CheckIfChanged();
    }

    // Function that checks if something has changed
    // This only simulates an actual check for change, as Translation, Rotation, Mesh, Material, etc. would need to be checked
    public void CheckIfChanged()
    {
        if(this.GetComponent<Renderer>().material == standartMaterialSave)
        {
            return;
        }
        else
        {
            ObjectChanged();
            standartMaterialSave = this.GetComponent<Renderer>().material;
        }
    }

    // Function that creates a duplicate of gameobject as child of the emptygameobject.
    public void CreateDuplicate()
    {
        Quaternion emptyQuaternion = new Quaternion(0,0,0,0);
        copyEmptyGameObject = Instantiate(emptyParentObject, hand.transform.position, emptyQuaternion);
        copyGameObject = Instantiate(this.gameObject, hand.transform.position, emptyQuaternion);

        copyGameObject.transform.parent = copyEmptyGameObject.transform;
    }

    // If object changed, update copied gameobject. 
    public void ObjectChanged()
    {
        if (copyGameObject)
        {
            Transform oldtransform = copyGameObject.transform;
            //oldtransform.position = copyGameObject.transform.position;
            Destroy(copyGameObject);
            
            copyGameObject = Instantiate(this.gameObject, oldtransform);
            copyGameObject.transform.parent = copyEmptyGameObject.transform;
        }
    }




}
