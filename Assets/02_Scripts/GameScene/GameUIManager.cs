using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    //Timer
    public Text textTime;
    int time;

    //TamaDropSpeedUpCount
    float dropSpeed;
    int tamaDropSpeedUpMax;
    int tamaDropSpeedUpCount;
    public Text textDropSpeed;
    public Text textTamaDropSpeedUpCount;

    //Drop Position
    public GameObject objDrop_0;
    public GameObject objDrop_1;
    public GameObject objDrop_2;
    public GameObject objDrop_3;
    public GameObject objDrop_4;
    public GameObject objDrop_5;
    public GameObject objDrop_6;
    int receiveDropNum;

    //Skill
    bool checkSkill;    //true=On    , false=Off
    public GameObject objSkillStopTime;
    public Text textSkillStopTime;
    int SkillStoptime;
    public GameObject objSkillBatOn;
    public GameObject objSkillRocketOn;
    public GameObject objSkillTurtleOn;
    public GameObject objSkillStopOn;
    bool skillBat;
    bool skillRocket;
    bool skillTurtle;
    bool skillStop;

    //GameOver
    public GameObject popupGameOver;

    [SerializeField] private GameLogic _gameLogic;



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
        TamaSpeed();
        DropPositionCheck();
        CheckSkillActive();
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

        //Skill
        checkSkill = false;
        SkillStoptime = 16;
        objSkillStopTime.gameObject.SetActive(false);
        objSkillBatOn.gameObject.SetActive(false);
        objSkillRocketOn.gameObject.SetActive(false);
        objSkillTurtleOn.gameObject.SetActive(false);
        objSkillStopOn.gameObject.SetActive(false);
        skillBat = false;
        skillRocket = false;
        skillTurtle = false;
        skillStop = false;

        //Popup
        popupGameOver.gameObject.SetActive(false);
    }

    //10sec Timer Coroutine
    IEnumerator Timer10sec()
    {
        yield return new WaitForSeconds(1.0f);

        if(checkSkill == false)
        {
            if (time == 0)
            {
                //Next Tama Drop
                _gameLogic.NextTama();

                //Time Reset
                time = 10;
            }
            else
            {
                time--;
            }
            StartCoroutine(Timer10sec());
        }
        else if(checkSkill == true)
        {
            yield return new WaitForSeconds(15.0f);

            checkSkill = false;
            StartCoroutine(Timer10sec());
        }

    }

    IEnumerator SkillStopCoroutine()
    {
        if (SkillStoptime == 0)
        {
            objSkillStopTime.gameObject.SetActive(false);
            StopCoroutine(SkillStopCoroutine());
        }
        else
        {
            SkillStoptime--;

            yield return new WaitForSeconds(1.0f);

            StartCoroutine(SkillStopCoroutine());
        }
    }

    //TamaSpeed                   (void Update)
    void TamaSpeed()
    {
        dropSpeed = _gameLogic.tamaSpeed;
        tamaDropSpeedUpCount = _gameLogic.TamaDropSpeedUpCount;
        tamaDropSpeedUpMax = _gameLogic.TamaDropSpeedUpMax;

        textDropSpeed.text = dropSpeed.ToString("N1");
        textTamaDropSpeedUpCount.text = tamaDropSpeedUpCount.ToString() + " / " + tamaDropSpeedUpMax.ToString();
    }

    //SKill On Off
    public void SkillStop()
    {
        checkSkill = true;

        SkillStoptime = 16;
        objSkillStopTime.gameObject.SetActive(true);
        StartCoroutine(SkillStopCoroutine());
    }

    //Skill                            (void Update)
    void CheckSkillActive()
    {
        //Bat
        if (skillBat == true)
        {
            objSkillBatOn.gameObject.SetActive(true);
        }
        else if (skillBat == false)
        {
            objSkillBatOn.gameObject.SetActive(false);
        }

        //Rocket
        if (skillRocket == true)
        {
            objSkillRocketOn.gameObject.SetActive(true);
        }
        else if (skillRocket == false)
        {
            objSkillRocketOn.gameObject.SetActive(false);
        }

        //Turtle
        if (skillTurtle == true)
        {
            objSkillTurtleOn.gameObject.SetActive(true);
        }
        else if (skillTurtle == false)
        {
            objSkillTurtleOn.gameObject.SetActive(false);
        }

        //Stop
        if (skillStop == true)
        {
            objSkillStopOn.gameObject.SetActive(true);
        }
        else if (skillStop == false)
        {
            objSkillStopOn.gameObject.SetActive(false);
        }
    }

    public void BtnSkillBatOn()
    {
        skillBat = true;
    }

    public void SkillBatOff()
    {
        skillBat = false;
    }

    public void BtnSkillTurtle()
    {
        //if (skillTurtle == true)
        //{
        //    skillTurtle = false;
        //}
        //else if (skillTurtle == false)
        //{
        //    skillTurtle = true;
        //}
    }

    public void BtnSkillStop()
    {
        skillStop = true;
    }

    //Stop Coruotine Timer10sec
    public void StopTimer()
    {
        Debug.Log("Rocket");
        StopCoroutine(Timer10sec());
    }

    //Timer Text Update      (void Update)
    void TimeTextUpdate()
    {
        textTime.text = time.ToString();
        textSkillStopTime.text = SkillStoptime.ToString();
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
