using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTamaLogic : MonoBehaviour
{
    //Drag Area Check
    bool checkPlayerOn;



    void Start()
    {
        checkPlayerOn = false;
        OnMouseDrag();
    }

    void Update()
    {
        OnMouseDrag();
    }

    public void OnMouseDrag()
    {
        if(checkPlayerOn == true)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = new Vector3(mousePosition.x, -3.5f, 10);

            //Drag Area
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

            if (pos.x < 0.05f)
            {
                pos.x = 0.05f;
            }
            else if (pos.x > 0.95f)
            {
                pos.x = 0.95f;
            }

            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }
        else if(checkPlayerOn == false)
        {
            Debug.Log("드래그중!");

            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("PlayerArea"))
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            GameObject.Find("Player").transform.position = mousePosition;

            GameObject.Find("Player").GetComponent<PlayerLogic>().DragOn();
            checkPlayerOn = true;
        }
    }
}
