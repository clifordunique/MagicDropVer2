using System.Collections;
using System.Collections.Generic;
using MagicDrop;
using UnityEngine;

public class LobbyLogic : MonoBehaviour
{
    //Game Mode
    public bool clearRule;     //true=Horizontal&Vertical    false=Tetris
    public bool clearTiming;   //true=Always    false=Drop->Claer
    public bool tamaCreate;    //true=Top       false=Bottom

    //Tama Speed Up
    public static int tamaDropSpeed;




    void Awake()
    {
        ResetAll();
    }

    void Start()
    {
        
    }

    void Update()
    {
        GameSettings.ClearRule = clearRule ? DropClearRule.Line : DropClearRule.Chain;
        GameSettings.ClearTiming = clearTiming ? DropClearTiming.Always : DropClearTiming.Dropped;
        GameSettings.CreateMode = tamaCreate ? DropCreateMode.Top : DropCreateMode.Bottom;
    }

    //ResetAll               (void Awake)
    void ResetAll()
    {
        //Game Mode
        clearRule = true;
        clearTiming = true;
        tamaCreate = true;

        //Tama Speed
        tamaDropSpeed = 5;
    }

    //Btn GameMode ClearRule
    public void BtnClearRule()
    {
        if(clearRule == true)
        {
            clearRule = false;
        }
        else if(clearRule == false)
        {
            clearRule = true;
        }
    }

    //Btn GameMode ClearTiming
    public void BtnClearTiming()
    {
        if (clearTiming == true)
        {
            clearTiming = false;
        }
        else if (clearTiming == false)
        {
            clearTiming = true;
        }
    }

    //Btn GameMode TamaCreate
    public void BtnTamaCreate()
    {
        if (tamaCreate == true)
        {
            tamaCreate = false;
        }
        else if (tamaCreate == false)
        {
            tamaCreate = true;
        }

    }

    //Tama Drop Speed P
    public void BtnTamaSropSpeedP()
    {
        if(tamaDropSpeed < 10)
        {
            tamaDropSpeed++;
        }
        else if(tamaDropSpeed >= 10)
        {
            tamaDropSpeed = 10;
        }
    }

    //Tama Drop Speed M
    public void BtnTamaSropSpeedM()
    {
        if (tamaDropSpeed > 1)
        {
            tamaDropSpeed--;
        }
        else if (tamaDropSpeed <= 1)
        {
            tamaDropSpeed = 1;
        }
    }
}
