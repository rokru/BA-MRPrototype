using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnTurnOff : MonoBehaviour
{
    //Turns on and off the gameobject
    public void TurnOnOff()
    {
        if (this.gameObject.activeSelf)
        {
            this.gameObject.SetActive(false);
            return;
        }

        if (!this.gameObject.activeSelf)
        {
            this.gameObject.SetActive(true);
            return;
        }

    }
}
