using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject boxingGameObject;
    private Boxing Boxing;

    // Start is called before the first frame update
    void Start()
    {
        Boxing = boxingGameObject.GetComponent<Boxing>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Destroy target if hit by users hands
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Gloves")
        {
            Boxing.TargetDestroyed();
            Destroy(gameObject);
        }
    }


}
