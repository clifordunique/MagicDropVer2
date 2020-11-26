using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamaLogic : MonoBehaviour
{




    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TamaSelectBox"))
        {
            Debug.Log("BOX!");
            this.gameObject.tag = "CanSelect";
        }
    }
}
