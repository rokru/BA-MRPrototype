using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{

    private TextMeshPro textObject;

    private System.DateTime time;

    // Start is called before the first frame update
    void Start()
    {
        textObject = this.GetComponent<TextMeshPro>();
        
    }

    // Update is called once per frame
    void Update()
    {
        time = System.DateTime.Now;
        textObject.text = time.ToString("T");
    }
}
