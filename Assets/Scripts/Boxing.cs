using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxing : MonoBehaviour
{

    public GameObject pivotPointBoxingArea;
    public GameObject boxingTarget;
    public GameObject boxingGloveLeft;
    public GameObject boxingGloveRight;

    public bool boxingActive = false;
    public bool targetActive = false;


    private int targetCount = 0;

    private float countdown = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // If boxing "game" active, there is no target and countdown is done spawn new target
        if (boxingActive && !targetActive && countdown <= 0)
        {
          
            Quaternion spawnRotation = Quaternion.Euler(0,0,0);
            Vector3 spawnPosition;
            targetCount += 1;
            
            // Each fifth target is rotated downwards
            if(targetCount == 5)
            {
                Vector3 newRotation = new Vector3(90,0,0);
                spawnRotation.eulerAngles = newRotation;
                spawnPosition = new Vector3(Random.Range(0.3f,0.8f), Random.Range(0.5f, 0.8f), 0);
                targetCount = 0;
            }
            else
            {
                spawnPosition = new Vector3(Random.Range(0.3f,0.8f), Random.Range(0.3f, 0.8f), 0);
            }

            Instantiate(boxingTarget, pivotPointBoxingArea.transform.position + spawnPosition,  spawnRotation);
            targetActive = true;
        }
        countdown -= 1 * Time.deltaTime;

    }


    // Starts and ends the boxing "game"
    public void BoxingStartAndEnd()
    {
        if (!boxingActive)
        {
            boxingActive = true;
            return;
        }

        if (boxingActive)
        {
            boxingActive = false;
            return;
        }

    }

    // If target destroyed, set countdown until spawn new one
    public void TargetDestroyed()
    {
        targetActive = false;
        countdown += 2;
    }


}
