using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    Vector3 currentPos;

    //Drop Number -> Drop Position    7=null(reset)
    public int dropNum;

    //Check Can Drag
    bool checkCanDrag;




    void Awake()
    {
        ResetAll();
    }

    void Start()
    {
        currentPos = this.gameObject.transform.position;
    }

    void Update()
    {
        OnMouseDrag();
    }

    //ResetAll             (void Awake)
    public void ResetAll()
    {
        dropNum = 7;
        checkCanDrag = false;
    }

    //Drag Change
    public void DragOn()
    {
        checkCanDrag = true;
    }

    public void DragOff()
    {
        checkCanDrag = false;
    }

    //Touch -> Drag -> Move
    public void OnMouseDrag()
    {
        if (checkCanDrag == true)
        {
            GameObject.Find("GameLogic").GetComponent<GameLogic>().SelectTamaDelete();

            Debug.Log("드래그중!");
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = new Vector3(mousePosition.x, currentPos.y, 10);

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
        else if (checkCanDrag == false)
        {

        }
    }

    //Player Drop Position Check
    public void OnTriggerStay2D(Collider2D other)
    {
        if (checkCanDrag == true)
        {
            if (other.gameObject.CompareTag("Drop_0"))
            {
                dropNum = 0;
            }
            else if (other.gameObject.CompareTag("Drop_1"))
            {
                dropNum = 1;
            }
            else if (other.gameObject.CompareTag("Drop_2"))
            {
                dropNum = 2;
            }
            else if (other.gameObject.CompareTag("Drop_3"))
            {
                dropNum = 3;
            }
            else if (other.gameObject.CompareTag("Drop_4"))
            {
                dropNum = 4;
            }
            else if (other.gameObject.CompareTag("Drop_5"))
            {
                dropNum = 5;
            }
            else if (other.gameObject.CompareTag("Drop_6"))
            {
                dropNum = 6;
            }
        }
        else
        {
            dropNum = 7;
        }
    }
}
