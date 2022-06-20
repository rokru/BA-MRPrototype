using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnSelectFunction : MonoBehaviour
{
    //Destroys this gameobject
    public void DestroyGameObject()
    {
        Destroy(this.gameObject);
    }

}
