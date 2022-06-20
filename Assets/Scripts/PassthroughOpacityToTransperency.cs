using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassthroughOpacityToTransperency : MonoBehaviour
{
    public OVRPassthroughLayer passthroughLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // Sets Opacity of Material to passthrough opacity
    void Update()
    {
        Color currentColor = this.gameObject.GetComponent<Renderer>().material.color;
        currentColor.a = 1 - passthroughLayer.textureOpacity;

        if(passthroughLayer.textureOpacity >= 0.75f)
        {
            currentColor.a = 0;
        }

        this.gameObject.GetComponent<Renderer>().material.color = currentColor;
    }


}
