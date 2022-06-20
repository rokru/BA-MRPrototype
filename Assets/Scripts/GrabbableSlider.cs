using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableSlider : MonoBehaviour
{
    public PassthroughManager passthroughManager;
    public float limits = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        //Scales the local z position of the slider into the passthrough opacity
        float maxNumber = limits * 2;
        float currentNumber = this.transform.localPosition.z;
        if(currentNumber < 0.0f)
        {
            currentNumber = limits - Mathf.Abs(currentNumber);
        }
        else
        {
            currentNumber += limits;
        }
        float scaledValue = (currentNumber - 0.0f) / (maxNumber - 0.0f);
        passthroughManager.SetOpacity(scaledValue);

    }
}
