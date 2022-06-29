using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterbottle : MonoBehaviour
{
    public GameObject insideWater;
    public GameObject bookShelf;

    public bool emptyBottle = false;


    private bool bookShelfShown = false;
    private bool choiceWasMade = false;

    // Start is called before the first frame update
    void Start()
    {
        bookShelf.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // If bottle is hold downwards, show emptying the water by changing color
        if (Vector3.Dot(transform.forward, Vector3.down) > 0.0f && emptyBottle == false)
        {
            Color oldColor = insideWater.gameObject.GetComponent<Renderer>().material.color;
            oldColor.a -= 0.1f * Time.deltaTime;
            insideWater.gameObject.GetComponent<Renderer>().material.color = oldColor;

            if (oldColor.a <= 0)
            {
                emptyBottle = true;
                GrabSelectUnselect();
            }
        }
        // If bookshelf is show, track with offset to waterbottle
        // Disable this code if bookshelf is moved by being a child of the waterbottle
        if (bookShelfShown)
        {
            Vector3 offsetPositionBookShelf = this.transform.localPosition;
            offsetPositionBookShelf.z -= 0.3f;
            bookShelf.transform.localPosition = offsetPositionBookShelf;
        }
    }

    // Show bookshelf when bottle is grabbed
    public void GrabSelectUnselect()
    {
        if (emptyBottle && !bookShelfShown && !choiceWasMade)
        {
            bookShelf.SetActive(true);
            bookShelfShown = true;
        }
        else if (emptyBottle && bookShelfShown)
        {
            bookShelf.SetActive(false);
            bookShelfShown = false;
        }
    }

    // If choice choice was made, set bool to not show bookshelf anymore
    public void ChoiceMade()
    {
        choiceWasMade = true;
    }


}
