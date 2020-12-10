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
}
