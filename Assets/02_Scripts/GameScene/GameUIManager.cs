using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    //Timer
    public Text textTime;
    int time;

    //Drop Position
    public GameObject objDrop_0;
    public GameObject objDrop_1;
    public GameObject objDrop_2;
    public GameObject objDrop_3;
    public GameObject objDrop_4;
    public GameObject objDrop_5;
    public GameObject objDrop_6;
    int receiveDropNum;

    //GameOver
    public GameObject popupGameOver;



    void Awake()
    {
        ResetAll();
    }

    void Start()
    {
        StartCoroutine(Timer10sec());
    }

    void Update()
    {
        TimeTextUpdate();
        DropPositionCheck();
    }

    //ResetAll         (void Awake)
    void ResetAll()
    {
        time = 10;

        objDrop_0.gameObject.SetActive(false);
        objDrop_1.gameObject.SetActive(false);
        objDrop_2.gameObject.SetActive(false);
        objDrop_3.gameObject.SetActive(false);
        objDrop_4.gameObject.SetActive(false);
        objDrop_5.gameObject.SetActive(false);
        objDrop_6.gameObject.SetActive(false);

        //Popup
        popupGameOver.gameObject.SetActive(false);
    }

    //10sec Timer Coroutine
    IEnumerator Timer10sec()
    {
        yield return new WaitForSeconds(1.0f);

        if(time == 0)
        {
            //Next Tama Drop
            GameObject.Find("GameLogic").GetComponent<GameLogic>().NextTama();

            //Time Reset
            time = 10;
        }
        else
        {
            time--;
        }
        StartCoroutine(Timer10sec());
    }

    //Timer Text Update      (void Update)
    void TimeTextUpdate()
    {
        textTime.text = time.ToString();
    }

    //Drop Position Check    (void Update)
    void DropPositionCheck()
    {
        PlayerLogic playerlogic = GameObject.Find("Player").GetComponent<PlayerLogic>();
        receiveDropNum = playerlogic.dropNum;

        switch(receiveDropNum)
        {
            case 0:
                objDrop_0.gameObject.SetActive(true);
                objDrop_1.gameObject.SetActive(false);
                objDrop_2.gameObject.SetActive(false);
                objDrop_3.gameObject.SetActive(false);
                objDrop_4.gameObject.SetActive(false);
                objDrop_5.gameObject.SetActive(false);
                objDrop_6.gameObject.SetActive(false);
                break;
            case 1:
                objDrop_0.gameObject.SetActive(false);
                objDrop_1.gameObject.SetActive(true);
                objDrop_2.gameObject.SetActive(false);
                objDrop_3.gameObject.SetActive(false);
                objDrop_4.gameObject.SetActive(false);
                objDrop_5.gameObject.SetActive(false);
                objDrop_6.gameObject.SetActive(false);
                break;
            case 2:
                objDrop_0.gameObject.SetActive(false);
                objDrop_1.gameObject.SetActive(false);
                objDrop_2.gameObject.SetActive(true);
                objDrop_3.gameObject.SetActive(false);
                objDrop_4.gameObject.SetActive(false);
                objDrop_5.gameObject.SetActive(false);
                objDrop_6.gameObject.SetActive(false);
                break;
            case 3:
                objDrop_0.gameObject.SetActive(false);
                objDrop_1.gameObject.SetActive(false);
                objDrop_2.gameObject.SetActive(false);
                objDrop_3.gameObject.SetActive(true);
                objDrop_4.gameObject.SetActive(false);
                objDrop_5.gameObject.SetActive(false);
                objDrop_6.gameObject.SetActive(false);
                break;
            case 4:
                objDrop_0.gameObject.SetActive(false);
                objDrop_1.gameObject.SetActive(false);
                objDrop_2.gameObject.SetActive(false);
                objDrop_3.gameObject.SetActive(false);
                objDrop_4.gameObject.SetActive(true);
                objDrop_5.gameObject.SetActive(false);
                objDrop_6.gameObject.SetActive(false);
                break;
            case 5:
                objDrop_0.gameObject.SetActive(false);
                objDrop_1.gameObject.SetActive(false);
                objDrop_2.gameObject.SetActive(false);
                objDrop_3.gameObject.SetActive(false);
                objDrop_4.gameObject.SetActive(false);
                objDrop_5.gameObject.SetActive(true);
                objDrop_6.gameObject.SetActive(false);
                break;
            case 6:
                objDrop_0.gameObject.SetActive(false);
                objDrop_1.gameObject.SetActive(false);
                objDrop_2.gameObject.SetActive(false);
                objDrop_3.gameObject.SetActive(false);
                objDrop_4.gameObject.SetActive(false);
                objDrop_5.gameObject.SetActive(false);
                objDrop_6.gameObject.SetActive(true);
                break;
            case 7:
                objDrop_0.gameObject.SetActive(false);
                objDrop_1.gameObject.SetActive(false);
                objDrop_2.gameObject.SetActive(false);
                objDrop_3.gameObject.SetActive(false);
                objDrop_4.gameObject.SetActive(false);
                objDrop_5.gameObject.SetActive(false);
                objDrop_6.gameObject.SetActive(false);
                break;
        }
    }

    //GameOver Popup Open
    public void PopupGameOverOpen()
    {
        popupGameOver.gameObject.SetActive(true);

        //Pause
        Time.timeScale = 0;
    }
}
