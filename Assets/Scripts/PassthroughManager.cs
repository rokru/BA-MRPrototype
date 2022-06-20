using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassthroughManager : MonoBehaviour
{
    public OVRPassthroughLayer passthroughLayer;

    // Set the opacity of the passthrough
    public void SetOpacity(float value)
    {
        passthroughLayer.textureOpacity = value;
    }


}
