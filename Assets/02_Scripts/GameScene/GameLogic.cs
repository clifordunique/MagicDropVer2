using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public const int ColumnCount = 7;
    public const int RowCount = 12;
    public const int TamaNull = 10;
    //Tama
    public float tamaSpeed;
    int carryNum;
    int selectNum;
    int receiveDropNum;
    bool checkCarry;      //true=carry   , false=not carry
    bool checkSelectTamaDelete;         //true=Delete   , false=not Delete

    //Skill


    //List
    public List<Transform> TamaTransformList = new List<Transform>();
    public List<Transform> NextTamaTransformList = new List<Transform>();
    public List<GameObject> NextTamaList = new List<GameObject>();
    public List<GameObject> TamaKindList = new List<GameObject>();
    public List<GameObject> TamaSelectKindList = new List<GameObject>();
    public List<GameObject> TamaSpawnedList = new List<GameObject>();
    public List<GameObject> TamaCarryList = new List<GameObject>();
    public List<int> TamaNumList = new List<int>();
    public List<int> NextTamaNumList = new List<int>();
    //List



    void Awake()
    {
        ResetAll();
    }

    void Start()
    {
        Invoke("Initialize", 0.1f);
    }

    void Initialize ()
    {
        TamaStart();
        NextTamaStart();
        StartCoroutine(TamaMoveClear());
    }

    void Update()
    {
        
    }

    //ResetAll          (void Awake)
    void ResetAll()
    {
        tamaSpeed = 0.4f;

        carryNum = 10;
        selectNum = 10;
        receiveDropNum = 7;
        checkCarry = false;
        checkSelectTamaDelete = true;
    }

    //ゲームが始まるとき、下端部の3つの列に生じる玉      (void Start)
    void TamaStart()
    {
        for(int i = 0; i < 21; i++)
        {
            int z = (Random.Range(0, 4));

            Transform targetPoint = TamaTransformList[i];
            GameObject newTama = Instantiate(TamaKindList[z]);
            newTama.transform.position = targetPoint.position;
            TamaSpawnedList[i] = newTama;
            TamaNumList[i] = z;
        }
    }

    //ゲームが始まるとき、上端部の1つの列に生じる玉      (void Start)
    void NextTamaStart()
    {
        for (int i = 0; i < 7; i++)
        {
            int z = (Random.Range(0, 4));

            Transform targetPoint = NextTamaTransformList[i];
            GameObject newTama = Instantiate(TamaKindList[z]);
            newTama.transform.position = targetPoint.position;
            NextTamaList[i] = newTama;
            NextTamaNumList[i] = z;
        }
    }

    //Next Tama
    public void NextTama()
    {
        StartCoroutine(NextTamaCoroutine());
    }

    IEnumerator NextTamaCoroutine()
    {
        //準備できている次の玉1列を下げる
        for (int i = 0; i < 7; i++)
        {
            Transform targetPoint = TamaTransformList[i + 70];
            GameObject newTama = Instantiate(TamaKindList[NextTamaNumList[i]]);
            newTama.transform.position = targetPoint.position;
            TamaSpawnedList[i + 70] = newTama;
            TamaNumList[i + 70] = NextTamaNumList[i];

            Destroy(NextTamaList[i]);
            NextTamaNumList[i] = 10;
        }

        yield return new WaitForSeconds(0.2f);

        //新しく次の玉1列を生じる
        for (int i = 0; i < 7; i++)
        {
            int z = (Random.Range(0, 4));

            Transform targetPoint = NextTamaTransformList[i];
            GameObject newTama = Instantiate(TamaKindList[z]);
            newTama.transform.position = targetPoint.position;
            NextTamaList[i] = newTama;
            NextTamaNumList[i] = z;
        }
    }

    //TamaSelectButton (OnpointerDown)
    public void BtnOnpointer_0()
    {
        if(TamaNumList[0] != 10)
        {
            carryNum = TamaNumList[0];
            selectNum = 0;
            checkCarry = true;

            //OnMouseDrag
            OnMouseDrag();
        }
        else
        {

        }
    }

    public void BtnOnpointer_1()
    {
        if (TamaNumList[1] != 10)
        {
            carryNum = TamaNumList[1];
            selectNum = 1;
            checkCarry = true;

            //OnMouseDrag
            OnMouseDrag();
        }
        else
        {

        }
    }

    public void BtnOnpointer_2()
    {
        if (TamaNumList[2] != 10)
        {
            carryNum = TamaNumList[2];
            selectNum = 2;
            checkCarry = true;

            //OnMouseDrag
            OnMouseDrag();
        }
        else
        {

        }
    }

    public void BtnOnpointer_3()
    {
        if (TamaNumList[3] != 10)
        {
            carryNum = TamaNumList[3];
            selectNum = 3;
            checkCarry = true;

            //OnMouseDrag
            OnMouseDrag();
        }
        else
        {

        }
    }

    public void BtnOnpointer_4()
    {
        if (TamaNumList[4] != 10)
        {
            carryNum = TamaNumList[4];
            selectNum = 4;
            checkCarry = true;

            //OnMouseDrag
            OnMouseDrag();
        }
        else
        {

        }
    }

    public void BtnOnpointer_5()
    {
        if (TamaNumList[5] != 10)
        {
            carryNum = TamaNumList[5];
            selectNum = 5;
            checkCarry = true;

            //OnMouseDrag
            OnMouseDrag();
        }
        else
        {

        }
    }

    public void BtnOnpointer_6()
    {
        if (TamaNumList[6] != 10)
        {
            carryNum = TamaNumList[6];
            selectNum = 6;
            checkCarry = true;

            //OnMouseDrag
            OnMouseDrag();
        }
        else
        {

        }
    }

    //Drag
    public void OnMouseDrag()
    {
        if(checkCarry == true)
        {
            switch(selectNum)
            {
                case 0:
                    //New Tama Create
                    GameObject carryTama0 = Instantiate(TamaSelectKindList[carryNum], new Vector3(-2.4f, -2.9f, 0), Quaternion.identity);
                    TamaCarryList[0] = carryTama0;
                    break;
                case 1:
                    //New Tama Create
                    GameObject carryTama1 = Instantiate(TamaSelectKindList[carryNum], new Vector3(-1.6f, -2.9f, 0), Quaternion.identity);
                    TamaCarryList[0] = carryTama1;
                    break;
                case 2:
                    //New Tama Create
                    GameObject carryTama2 = Instantiate(TamaSelectKindList[carryNum], new Vector3(-0.8f, -2.9f, 0), Quaternion.identity);
                    TamaCarryList[0] = carryTama2;
                    break;
                case 3:
                    //New Tama Create
                    GameObject carryTama3 = Instantiate(TamaSelectKindList[carryNum], new Vector3(0.0f, -2.9f, 0), Quaternion.identity);
                    TamaCarryList[0] = carryTama3;
                    break;
                case 4:
                    //New Tama Create
                    GameObject carryTama4 = Instantiate(TamaSelectKindList[carryNum], new Vector3(0.8f, -2.9f, 0), Quaternion.identity);
                    TamaCarryList[0] = carryTama4;
                    break;
                case 5:
                    //New Tama Create
                    GameObject carryTama5 = Instantiate(TamaSelectKindList[carryNum], new Vector3(1.6f, -2.9f, 0), Quaternion.identity);
                    TamaCarryList[0] = carryTama5;
                    break;
                case 6:
                    //New Tama Create
                    GameObject carryTama6 = Instantiate(TamaSelectKindList[carryNum], new Vector3(2.4f, -2.9f, 0), Quaternion.identity);
                    TamaCarryList[0] = carryTama6;
                    break;
            }
        }
        else
        {

        }
    }

    //下端部の選んだ玉を消す
    public void SelectTamaDelete()
    {
        if(checkSelectTamaDelete == true)
        {
            switch (selectNum)
            {
                case 0:
                    Destroy(TamaSpawnedList[0]);
                    TamaNumList[0] = 10;
                    checkSelectTamaDelete = false;
                    break;
                case 1:
                    Destroy(TamaSpawnedList[1]);
                    TamaNumList[1] = 10;
                    checkSelectTamaDelete = false;
                    break;
                case 2:
                    Destroy(TamaSpawnedList[2]);
                    TamaNumList[2] = 10;
                    checkSelectTamaDelete = false;
                    break;
                case 3:
                    Destroy(TamaSpawnedList[3]);
                    TamaNumList[3] = 10;
                    checkSelectTamaDelete = false;
                    break;
                case 4:
                    Destroy(TamaSpawnedList[4]);
                    TamaNumList[4] = 10;
                    checkSelectTamaDelete = false;
                    break;
                case 5:
                    Destroy(TamaSpawnedList[5]);
                    TamaNumList[5] = 10;
                    checkSelectTamaDelete = false;
                    break;
                case 6:
                    Destroy(TamaSpawnedList[6]);
                    TamaNumList[6] = 10;
                    checkSelectTamaDelete = false;
                    break;
            }
        }
        else
        {
            //Don't Delete
        }
    }

    //TamaDrop
    public void TamaDrop()
    {
        if(checkCarry == true)
        {
            if(TamaNumList[63] == 10 && TamaNumList[64] == 10 && TamaNumList[65] == 10 && TamaNumList[66] == 10 && TamaNumList[67] == 10 && TamaNumList[68] == 10 && TamaNumList[69] == 10)
            {
                PlayerLogic playerlogic = GameObject.Find("Player").GetComponent<PlayerLogic>();
                receiveDropNum = playerlogic.dropNum;

                switch (receiveDropNum)
                {
                    case 0:
                        receiveDropNum = 63;
                        break;
                    case 1:
                        receiveDropNum = 64;
                        break;
                    case 2:
                        receiveDropNum = 65;
                        break;
                    case 3:
                        receiveDropNum = 66;
                        break;
                    case 4:
                        receiveDropNum = 67;
                        break;
                    case 5:
                        receiveDropNum = 68;
                        break;
                    case 6:
                        receiveDropNum = 69;
                        break;
                    case 7:
                        break;
                }

                Transform targetPoint = TamaTransformList[receiveDropNum];
                GameObject newTama = Instantiate(TamaKindList[carryNum]);
                newTama.transform.position = targetPoint.position;
                TamaSpawnedList[receiveDropNum] = newTama;
                TamaNumList[receiveDropNum] = carryNum;
            }
            else if(TamaNumList[70] == 10 && TamaNumList[71] == 10 && TamaNumList[72] == 10 && TamaNumList[73] == 10 && TamaNumList[74] == 10 && TamaNumList[75] == 10 && TamaNumList[76] == 10)
            {
                PlayerLogic playerlogic = GameObject.Find("Player").GetComponent<PlayerLogic>();
                receiveDropNum = playerlogic.dropNum;

                switch(receiveDropNum)
                {
                    case 0:
                        receiveDropNum = 70;
                        break;
                    case 1:
                        receiveDropNum = 71;
                        break;
                    case 2:
                        receiveDropNum = 72;
                        break;
                    case 3:
                        receiveDropNum = 73;
                        break;
                    case 4:
                        receiveDropNum = 74;
                        break;
                    case 5:
                        receiveDropNum = 75;
                        break;
                    case 6:
                        receiveDropNum = 76;
                        break;
                    case 7:
                        break;
                }

                Transform targetPoint = TamaTransformList[receiveDropNum];
                GameObject newTama = Instantiate(TamaKindList[carryNum]);
                newTama.transform.position = targetPoint.position;
                TamaSpawnedList[receiveDropNum] = newTama;
                TamaNumList[receiveDropNum] = carryNum;
            }
            else
            {
                if (TamaNumList[77] == 10 && TamaNumList[78] == 10 && TamaNumList[79] == 10 && TamaNumList[80] == 10 && TamaNumList[81] == 10 && TamaNumList[82] == 10 && TamaNumList[83] == 10)
                {
                    PlayerLogic playerlogic = GameObject.Find("Player").GetComponent<PlayerLogic>();
                    receiveDropNum = playerlogic.dropNum;

                    switch (receiveDropNum)
                    {
                        case 0:
                            receiveDropNum = 77;
                            break;
                        case 1:
                            receiveDropNum = 78;
                            break;
                        case 2:
                            receiveDropNum = 79;
                            break;
                        case 3:
                            receiveDropNum = 80;
                            break;
                        case 4:
                            receiveDropNum = 81;
                            break;
                        case 5:
                            receiveDropNum = 82;
                            break;
                        case 6:
                            receiveDropNum = 83;
                            break;
                        case 7:
                            break;
                    }

                    Transform targetPoint = TamaTransformList[receiveDropNum];
                    GameObject newTama = Instantiate(TamaKindList[carryNum]);
                    newTama.transform.position = targetPoint.position;
                    TamaSpawnedList[receiveDropNum] = newTama;
                    TamaNumList[receiveDropNum] = carryNum;
                }
            }

            GameObject.Find("Player").GetComponent<PlayerLogic>().DragOff();
            GameObject.Find("Player").GetComponent<PlayerLogic>().ResetAll();
            Destroy(TamaCarryList[0]);
            carryNum = 10;
            selectNum = 10;
            receiveDropNum = 7;
            checkCarry = false;
            checkSelectTamaDelete = true;
        }
        else
        {

        }
    }

    //TamaMove & Clear Coroutone                 (void Start)
    IEnumerator TamaMoveClear()
    {
        //Move
        for (int i = 0; i < 77; i++)
        {
            if(TamaNumList[i] == 10)
            {
                if(TamaNumList[i + 7] != 10)
                {
                    Transform targetPoint = TamaTransformList[i];
                    GameObject newTama = Instantiate(TamaKindList[TamaNumList[i + 7]]);
                    newTama.transform.position = targetPoint.position;
                    TamaSpawnedList[i] = newTama;
                    TamaNumList[i] = TamaNumList[i + 7];

                    Destroy(TamaSpawnedList[i + 7]);
                    TamaNumList[i + 7] = 10;
                }
                else
                {
                    //Don't Move
                }
            }
            else
            {
                //Don't Move
            }
        }

        yield return new WaitForSeconds(tamaSpeed);

        //Tama Clear Horizontal
        for(int a = 0; a < 4; a++)
        {
            //1列
            if(TamaNumList[a] != 10 && TamaNumList[a] == TamaNumList[a + 1] && TamaNumList[a] == TamaNumList[a + 2] && TamaNumList[a] == TamaNumList[a + 3])
            {
                if(TamaNumList[a] == TamaNumList[a + 4] && TamaNumList[a + 4] < 7)
                {
                    if(TamaNumList[a] == TamaNumList[a + 5] && TamaNumList[a + 5] < 7)
                    {
                        if(TamaNumList[a] == TamaNumList[a + 6] && TamaNumList[a + 6] < 7)
                        {
                            //7個消す
                            Destroy(TamaSpawnedList[a]);
                            Destroy(TamaSpawnedList[a + 1]);
                            Destroy(TamaSpawnedList[a + 2]);
                            Destroy(TamaSpawnedList[a + 3]);
                            Destroy(TamaSpawnedList[a + 4]);
                            Destroy(TamaSpawnedList[a + 5]);
                            Destroy(TamaSpawnedList[a + 6]);
                            TamaNumList[a] = 10;
                            TamaNumList[a + 1] = 10;
                            TamaNumList[a + 2] = 10;
                            TamaNumList[a + 3] = 10;
                            TamaNumList[a + 4] = 10;
                            TamaNumList[a + 5] = 10;
                            TamaNumList[a + 6] = 10;
                        }
                        else
                        {
                            //6個消す
                            Destroy(TamaSpawnedList[a]);
                            Destroy(TamaSpawnedList[a + 1]);
                            Destroy(TamaSpawnedList[a + 2]);
                            Destroy(TamaSpawnedList[a + 3]);
                            Destroy(TamaSpawnedList[a + 4]);
                            Destroy(TamaSpawnedList[a + 5]);
                            TamaNumList[a] = 10;
                            TamaNumList[a + 1] = 10;
                            TamaNumList[a + 2] = 10;
                            TamaNumList[a + 3] = 10;
                            TamaNumList[a + 4] = 10;
                            TamaNumList[a + 5] = 10;
                        }
                    }
                    else
                    {
                        //5個消す
                        Destroy(TamaSpawnedList[a]);
                        Destroy(TamaSpawnedList[a + 1]);
                        Destroy(TamaSpawnedList[a + 2]);
                        Destroy(TamaSpawnedList[a + 3]);
                        Destroy(TamaSpawnedList[a + 4]);
                        TamaNumList[a] = 10;
                        TamaNumList[a + 1] = 10;
                        TamaNumList[a + 2] = 10;
                        TamaNumList[a + 3] = 10;
                        TamaNumList[a + 4] = 10;
                    }
                }
                else
                {
                    //4個消す
                    Destroy(TamaSpawnedList[a]);
                    Destroy(TamaSpawnedList[a + 1]);
                    Destroy(TamaSpawnedList[a + 2]);
                    Destroy(TamaSpawnedList[a + 3]);
                    TamaNumList[a] = 10;
                    TamaNumList[a + 1] = 10;
                    TamaNumList[a + 2] = 10;
                    TamaNumList[a + 3] = 10;
                }
            }
        }

        for (int a = 7; a < 11; a++)
        {
            int b = a + 1;
            int c = a + 2;
            int d = a + 3;
            int e = a + 4;
            int f = a + 5;
            int g = a + 6;

            //2列
            if (TamaNumList[a] != 10 && TamaNumList[a] == TamaNumList[b] && TamaNumList[a] == TamaNumList[c] && TamaNumList[a] == TamaNumList[d])
            {
                //条件
                if(TamaNumList[a - 7] != 10 && TamaNumList[b - 7] != 10 && TamaNumList[c - 7] != 10 && TamaNumList[d - 7] != 10)
                {
                    if (TamaNumList[a] == TamaNumList[e] && TamaNumList[e] < 14 && TamaNumList[e - 7] != 10)
                    {
                        if (TamaNumList[a] == TamaNumList[f] && TamaNumList[f] < 14 && TamaNumList[f - 7] != 10)
                        {
                            if (TamaNumList[a] == TamaNumList[g] && TamaNumList[g] < 14 && TamaNumList[g - 7] != 10)
                            {
                                //7個消す
                                Destroy(TamaSpawnedList[a]);
                                Destroy(TamaSpawnedList[a + 1]);
                                Destroy(TamaSpawnedList[a + 2]);
                                Destroy(TamaSpawnedList[a + 3]);
                                Destroy(TamaSpawnedList[a + 4]);
                                Destroy(TamaSpawnedList[a + 5]);
                                Destroy(TamaSpawnedList[a + 6]);
                                TamaNumList[a] = 10;
                                TamaNumList[a + 1] = 10;
                                TamaNumList[a + 2] = 10;
                                TamaNumList[a + 3] = 10;
                                TamaNumList[a + 4] = 10;
                                TamaNumList[a + 5] = 10;
                                TamaNumList[a + 6] = 10;
                            }
                            else
                            {
                                //6個消す
                                Destroy(TamaSpawnedList[a]);
                                Destroy(TamaSpawnedList[a + 1]);
                                Destroy(TamaSpawnedList[a + 2]);
                                Destroy(TamaSpawnedList[a + 3]);
                                Destroy(TamaSpawnedList[a + 4]);
                                Destroy(TamaSpawnedList[a + 5]);
                                TamaNumList[a] = 10;
                                TamaNumList[a + 1] = 10;
                                TamaNumList[a + 2] = 10;
                                TamaNumList[a + 3] = 10;
                                TamaNumList[a + 4] = 10;
                                TamaNumList[a + 5] = 10;
                            }
                        }
                        else
                        {
                            //5個消す
                            Destroy(TamaSpawnedList[a]);
                            Destroy(TamaSpawnedList[a + 1]);
                            Destroy(TamaSpawnedList[a + 2]);
                            Destroy(TamaSpawnedList[a + 3]);
                            Destroy(TamaSpawnedList[a + 4]);
                            TamaNumList[a] = 10;
                            TamaNumList[a + 1] = 10;
                            TamaNumList[a + 2] = 10;
                            TamaNumList[a + 3] = 10;
                            TamaNumList[a + 4] = 10;
                        }
                    }
                    else
                    {
                        //4個消す
                        Destroy(TamaSpawnedList[a]);
                        Destroy(TamaSpawnedList[a + 1]);
                        Destroy(TamaSpawnedList[a + 2]);
                        Destroy(TamaSpawnedList[a + 3]);
                        TamaNumList[a] = 10;
                        TamaNumList[a + 1] = 10;
                        TamaNumList[a + 2] = 10;
                        TamaNumList[a + 3] = 10;
                    }
                }
                else
                {
                    //Nothing
                }
            }
        }

        for (int a = 14; a < 18; a++)
        {
            int b = a + 1;
            int c = a + 2;
            int d = a + 3;
            int e = a + 4;
            int f = a + 5;
            int g = a + 6;

            //3列
            if (TamaNumList[a] != 10 && TamaNumList[a] == TamaNumList[b] && TamaNumList[a] == TamaNumList[c] && TamaNumList[a] == TamaNumList[d])
            {
                //条件
                if(TamaNumList[a - 7] != 10 && TamaNumList[a - 14] != 10 && TamaNumList[b - 7] != 10 && TamaNumList[b - 14] != 10 && TamaNumList[c - 7] != 10 && TamaNumList[c - 14] != 10 && TamaNumList[d - 7] != 10 && TamaNumList[d - 14] != 10)
                {
                    if (TamaNumList[a] == TamaNumList[e] && TamaNumList[e] < 21 && TamaNumList[e - 7] != 10 && TamaNumList[e - 14] != 10)
                    {
                        if (TamaNumList[a] == TamaNumList[f] && TamaNumList[f] < 21 && TamaNumList[f - 7] != 10 && TamaNumList[f - 14] != 10)
                        {
                            if (TamaNumList[a] == TamaNumList[g] && TamaNumList[g] < 21 && TamaNumList[g - 7] != 10 && TamaNumList[g - 14] != 10)
                            {
                                //7個消す
                                Destroy(TamaSpawnedList[a]);
                                Destroy(TamaSpawnedList[a + 1]);
                                Destroy(TamaSpawnedList[a + 2]);
                                Destroy(TamaSpawnedList[a + 3]);
                                Destroy(TamaSpawnedList[a + 4]);
                                Destroy(TamaSpawnedList[a + 5]);
                                Destroy(TamaSpawnedList[a + 6]);
                                TamaNumList[a] = 10;
                                TamaNumList[a + 1] = 10;
                                TamaNumList[a + 2] = 10;
                                TamaNumList[a + 3] = 10;
                                TamaNumList[a + 4] = 10;
                                TamaNumList[a + 5] = 10;
                                TamaNumList[a + 6] = 10;
                            }
                            else
                            {
                                //6個消す
                                Destroy(TamaSpawnedList[a]);
                                Destroy(TamaSpawnedList[a + 1]);
                                Destroy(TamaSpawnedList[a + 2]);
                                Destroy(TamaSpawnedList[a + 3]);
                                Destroy(TamaSpawnedList[a + 4]);
                                Destroy(TamaSpawnedList[a + 5]);
                                TamaNumList[a] = 10;
                                TamaNumList[a + 1] = 10;
                                TamaNumList[a + 2] = 10;
                                TamaNumList[a + 3] = 10;
                                TamaNumList[a + 4] = 10;
                                TamaNumList[a + 5] = 10;
                            }
                        }
                        else
                        {
                            //5個消す
                            Destroy(TamaSpawnedList[a]);
                            Destroy(TamaSpawnedList[a + 1]);
                            Destroy(TamaSpawnedList[a + 2]);
                            Destroy(TamaSpawnedList[a + 3]);
                            Destroy(TamaSpawnedList[a + 4]);
                            TamaNumList[a] = 10;
                            TamaNumList[a + 1] = 10;
                            TamaNumList[a + 2] = 10;
                            TamaNumList[a + 3] = 10;
                            TamaNumList[a + 4] = 10;
                        }
                    }
                    else
                    {
                        //4個消す
                        Destroy(TamaSpawnedList[a]);
                        Destroy(TamaSpawnedList[a + 1]);
                        Destroy(TamaSpawnedList[a + 2]);
                        Destroy(TamaSpawnedList[a + 3]);
                        TamaNumList[a] = 10;
                        TamaNumList[a + 1] = 10;
                        TamaNumList[a + 2] = 10;
                        TamaNumList[a + 3] = 10;
                    }
                }
                else
                {
                    //Nothing
                }
            }
        }

        for (int a = 21; a < 25; a++)
        {
            int b = a + 1;
            int c = a + 2;
            int d = a + 3;
            int e = a + 4;
            int f = a + 5;
            int g = a + 6;

            //4列
            if (TamaNumList[a] != 10 && TamaNumList[a] == TamaNumList[b] && TamaNumList[a] == TamaNumList[c] && TamaNumList[a] == TamaNumList[d])
            {
                //条件
                if (TamaNumList[a - 7] != 10 && TamaNumList[a - 14] != 10 && TamaNumList[a - 21] != 10 && TamaNumList[b - 7] != 10 && TamaNumList[b - 14] != 10 && TamaNumList[b - 21] != 10 && TamaNumList[c - 7] != 10 && TamaNumList[c - 14] != 10 && TamaNumList[c - 21] != 10 && TamaNumList[d - 7] != 10 && TamaNumList[d - 14] != 10 && TamaNumList[d - 21] != 10)
                {
                    if (TamaNumList[a] == TamaNumList[e] && TamaNumList[e] < 28 && TamaNumList[e - 7] != 10 && TamaNumList[e - 14] != 10 && TamaNumList[e - 21] != 10)
                    {
                        if (TamaNumList[a] == TamaNumList[f] && TamaNumList[f] < 28 && TamaNumList[f - 7] != 10 && TamaNumList[f - 14] != 10 && TamaNumList[f - 21] != 10)
                        {
                            if (TamaNumList[a] == TamaNumList[g] && TamaNumList[g] < 28 && TamaNumList[g - 7] != 10 && TamaNumList[g - 14] != 10 && TamaNumList[g - 21] != 10)
                            {
                                //7個消す
                                Destroy(TamaSpawnedList[a]);
                                Destroy(TamaSpawnedList[a + 1]);
                                Destroy(TamaSpawnedList[a + 2]);
                                Destroy(TamaSpawnedList[a + 3]);
                                Destroy(TamaSpawnedList[a + 4]);
                                Destroy(TamaSpawnedList[a + 5]);
                                Destroy(TamaSpawnedList[a + 6]);
                                TamaNumList[a] = 10;
                                TamaNumList[a + 1] = 10;
                                TamaNumList[a + 2] = 10;
                                TamaNumList[a + 3] = 10;
                                TamaNumList[a + 4] = 10;
                                TamaNumList[a + 5] = 10;
                                TamaNumList[a + 6] = 10;
                            }
                            else
                            {
                                //6個消す
                                Destroy(TamaSpawnedList[a]);
                                Destroy(TamaSpawnedList[a + 1]);
                                Destroy(TamaSpawnedList[a + 2]);
                                Destroy(TamaSpawnedList[a + 3]);
                                Destroy(TamaSpawnedList[a + 4]);
                                Destroy(TamaSpawnedList[a + 5]);
                                TamaNumList[a] = 10;
                                TamaNumList[a + 1] = 10;
                                TamaNumList[a + 2] = 10;
                                TamaNumList[a + 3] = 10;
                                TamaNumList[a + 4] = 10;
                                TamaNumList[a + 5] = 10;
                            }
                        }
                        else
                        {
                            //5個消す
                            Destroy(TamaSpawnedList[a]);
                            Destroy(TamaSpawnedList[a + 1]);
                            Destroy(TamaSpawnedList[a + 2]);
                            Destroy(TamaSpawnedList[a + 3]);
                            Destroy(TamaSpawnedList[a + 4]);
                            TamaNumList[a] = 10;
                            TamaNumList[a + 1] = 10;
                            TamaNumList[a + 2] = 10;
                            TamaNumList[a + 3] = 10;
                            TamaNumList[a + 4] = 10;
                        }
                    }
                    else
                    {
                        //4個消す
                        Destroy(TamaSpawnedList[a]);
                        Destroy(TamaSpawnedList[a + 1]);
                        Destroy(TamaSpawnedList[a + 2]);
                        Destroy(TamaSpawnedList[a + 3]);
                        TamaNumList[a] = 10;
                        TamaNumList[a + 1] = 10;
                        TamaNumList[a + 2] = 10;
                        TamaNumList[a + 3] = 10;
                    }
                }
            }
        }

        for (int a = 28; a < 32; a++)
        {
            int b = a + 1;
            int c = a + 2;
            int d = a + 3;
            int e = a + 4;
            int f = a + 5;
            int g = a + 6;

            //5列
            if (TamaNumList[a] != 10 && TamaNumList[a] == TamaNumList[b] && TamaNumList[a] == TamaNumList[c] && TamaNumList[a] == TamaNumList[d])
            {
                //条件
                if(TamaNumList[a - 7] != 10 && TamaNumList[a - 14] != 10 && TamaNumList[a - 21] != 10 && TamaNumList[a - 28] != 10 && TamaNumList[b - 7] != 10 && TamaNumList[b - 14] != 10 && TamaNumList[b - 21] != 10 && TamaNumList[b - 28] != 10 && TamaNumList[c - 7] != 10 && TamaNumList[c - 14] != 10 && TamaNumList[c - 21] != 10 && TamaNumList[c - 28] != 10 && TamaNumList[d - 7] != 10 && TamaNumList[d - 14] != 10 && TamaNumList[d - 21] != 10 && TamaNumList[d - 28] != 10)
                {
                    if (TamaNumList[a] == TamaNumList[e] && TamaNumList[e] < 35 && TamaNumList[e - 7] != 10 && TamaNumList[e - 14] != 10 && TamaNumList[e - 21] != 10 && TamaNumList[e - 28] != 10)
                    {
                        if (TamaNumList[a] == TamaNumList[f] && TamaNumList[f] < 35 && TamaNumList[f - 7] != 10 && TamaNumList[f - 14] != 10 && TamaNumList[f - 21] != 10 && TamaNumList[f - 28] != 10)
                        {
                            if (TamaNumList[a] == TamaNumList[g] && TamaNumList[g] < 35 && TamaNumList[g - 7] != 10 && TamaNumList[g - 14] != 10 && TamaNumList[g - 21] != 10 && TamaNumList[g - 28] != 10)
                            {
                                //7個消す
                                Destroy(TamaSpawnedList[a]);
                                Destroy(TamaSpawnedList[a + 1]);
                                Destroy(TamaSpawnedList[a + 2]);
                                Destroy(TamaSpawnedList[a + 3]);
                                Destroy(TamaSpawnedList[a + 4]);
                                Destroy(TamaSpawnedList[a + 5]);
                                Destroy(TamaSpawnedList[a + 6]);
                                TamaNumList[a] = 10;
                                TamaNumList[a + 1] = 10;
                                TamaNumList[a + 2] = 10;
                                TamaNumList[a + 3] = 10;
                                TamaNumList[a + 4] = 10;
                                TamaNumList[a + 5] = 10;
                                TamaNumList[a + 6] = 10;
                            }
                            else
                            {
                                //6個消す
                                Destroy(TamaSpawnedList[a]);
                                Destroy(TamaSpawnedList[a + 1]);
                                Destroy(TamaSpawnedList[a + 2]);
                                Destroy(TamaSpawnedList[a + 3]);
                                Destroy(TamaSpawnedList[a + 4]);
                                Destroy(TamaSpawnedList[a + 5]);
                                TamaNumList[a] = 10;
                                TamaNumList[a + 1] = 10;
                                TamaNumList[a + 2] = 10;
                                TamaNumList[a + 3] = 10;
                                TamaNumList[a + 4] = 10;
                                TamaNumList[a + 5] = 10;
                            }
                        }
                        else
                        {
                            //5個消す
                            Destroy(TamaSpawnedList[a]);
                            Destroy(TamaSpawnedList[a + 1]);
                            Destroy(TamaSpawnedList[a + 2]);
                            Destroy(TamaSpawnedList[a + 3]);
                            Destroy(TamaSpawnedList[a + 4]);
                            TamaNumList[a] = 10;
                            TamaNumList[a + 1] = 10;
                            TamaNumList[a + 2] = 10;
                            TamaNumList[a + 3] = 10;
                            TamaNumList[a + 4] = 10;
                        }
                    }
                    else
                    {
                        //4個消す
                        Destroy(TamaSpawnedList[a]);
                        Destroy(TamaSpawnedList[a + 1]);
                        Destroy(TamaSpawnedList[a + 2]);
                        Destroy(TamaSpawnedList[a + 3]);
                        TamaNumList[a] = 10;
                        TamaNumList[a + 1] = 10;
                        TamaNumList[a + 2] = 10;
                        TamaNumList[a + 3] = 10;
                    }
                }
                else
                {
                    //Nothing
                }
            }
        }

        for (int a = 35; a < 39; a++)
        {
            int b = a + 1;
            int c = a + 2;
            int d = a + 3;
            int e = a + 4;
            int f = a + 5;
            int g = a + 6;

            //6列
            if (TamaNumList[a] != 10 && TamaNumList[a] == TamaNumList[b] && TamaNumList[a] == TamaNumList[c] && TamaNumList[a] == TamaNumList[d])
            {
                //条件(35)
                if(TamaNumList[a - 7] != 10 && TamaNumList[a - 14] != 10 && TamaNumList[a - 21] != 10 && TamaNumList[a - 28] != 10 && TamaNumList[a - 35] != 10 && TamaNumList[b - 7] != 10 && TamaNumList[b - 14] != 10 && TamaNumList[b - 21] != 10 && TamaNumList[b - 28] != 10 && TamaNumList[b - 35] != 10 && TamaNumList[c - 7] != 10 && TamaNumList[c - 14] != 10 && TamaNumList[c - 21] != 10 && TamaNumList[c - 28] != 10 && TamaNumList[c - 35] != 10 && TamaNumList[d - 7] != 10 && TamaNumList[d - 14] != 10 && TamaNumList[d - 21] != 10 && TamaNumList[d - 28] != 10 && TamaNumList[d - 35] != 10)
                {
                    if (TamaNumList[a] == TamaNumList[e] && TamaNumList[e] < 42 && TamaNumList[e - 7] != 10 && TamaNumList[e - 14] != 10 && TamaNumList[e - 21] != 10 && TamaNumList[e - 28] != 10 && TamaNumList[e - 35] != 10)
                    {
                        if (TamaNumList[a] == TamaNumList[f] && TamaNumList[f] < 42 && TamaNumList[f - 7] != 10 && TamaNumList[f - 14] != 10 && TamaNumList[f - 21] != 10 && TamaNumList[f - 28] != 10 && TamaNumList[f - 35] != 10)
                        {
                            if (TamaNumList[a] == TamaNumList[g] && TamaNumList[g] < 42 && TamaNumList[g - 7] != 10 && TamaNumList[g - 14] != 10 && TamaNumList[g - 21] != 10 && TamaNumList[g - 28] != 10 && TamaNumList[g - 35] != 10)
                            {
                                //7個消す
                                Destroy(TamaSpawnedList[a]);
                                Destroy(TamaSpawnedList[a + 1]);
                                Destroy(TamaSpawnedList[a + 2]);
                                Destroy(TamaSpawnedList[a + 3]);
                                Destroy(TamaSpawnedList[a + 4]);
                                Destroy(TamaSpawnedList[a + 5]);
                                Destroy(TamaSpawnedList[a + 6]);
                                TamaNumList[a] = 10;
                                TamaNumList[a + 1] = 10;
                                TamaNumList[a + 2] = 10;
                                TamaNumList[a + 3] = 10;
                                TamaNumList[a + 4] = 10;
                                TamaNumList[a + 5] = 10;
                                TamaNumList[a + 6] = 10;
                            }
                            else
                            {
                                //6個消す
                                Destroy(TamaSpawnedList[a]);
                                Destroy(TamaSpawnedList[a + 1]);
                                Destroy(TamaSpawnedList[a + 2]);
                                Destroy(TamaSpawnedList[a + 3]);
                                Destroy(TamaSpawnedList[a + 4]);
                                Destroy(TamaSpawnedList[a + 5]);
                                TamaNumList[a] = 10;
                                TamaNumList[a + 1] = 10;
                                TamaNumList[a + 2] = 10;
                                TamaNumList[a + 3] = 10;
                                TamaNumList[a + 4] = 10;
                                TamaNumList[a + 5] = 10;
                            }
                        }
                        else
                        {
                            //5個消す
                            Destroy(TamaSpawnedList[a]);
                            Destroy(TamaSpawnedList[a + 1]);
                            Destroy(TamaSpawnedList[a + 2]);
                            Destroy(TamaSpawnedList[a + 3]);
                            Destroy(TamaSpawnedList[a + 4]);
                            TamaNumList[a] = 10;
                            TamaNumList[a + 1] = 10;
                            TamaNumList[a + 2] = 10;
                            TamaNumList[a + 3] = 10;
                            TamaNumList[a + 4] = 10;
                        }
                    }
                    else
                    {
                        //4個消す
                        Destroy(TamaSpawnedList[a]);
                        Destroy(TamaSpawnedList[a + 1]);
                        Destroy(TamaSpawnedList[a + 2]);
                        Destroy(TamaSpawnedList[a + 3]);
                        TamaNumList[a] = 10;
                        TamaNumList[a + 1] = 10;
                        TamaNumList[a + 2] = 10;
                        TamaNumList[a + 3] = 10;
                    }
                }
                else
                {
                    //Nothing
                }
            }
        }

        for (int a = 42; a < 46; a++)
        {
            int b = a + 1;
            int c = a + 2;
            int d = a + 3;
            int e = a + 4;
            int f = a + 5;
            int g = a + 6;

            //7列
            if (TamaNumList[a] != 10 && TamaNumList[a] == TamaNumList[b] && TamaNumList[a] == TamaNumList[c] && TamaNumList[a] == TamaNumList[d])
            {
                //条件(42)
                if (TamaNumList[a - 7] != 10 && TamaNumList[a - 14] != 10 && TamaNumList[a - 21] != 10 && TamaNumList[a - 28] != 10 && TamaNumList[a - 35] != 10 && TamaNumList[a - 42] != 10 && TamaNumList[b - 7] != 10 && TamaNumList[b - 14] != 10 && TamaNumList[b - 21] != 10 && TamaNumList[b - 28] != 10 && TamaNumList[b - 35] != 10 && TamaNumList[b - 42] != 10 && TamaNumList[c - 7] != 10 && TamaNumList[c - 14] != 10 && TamaNumList[c - 21] != 10 && TamaNumList[c - 28] != 10 && TamaNumList[c - 35] != 10 && TamaNumList[c - 42] != 10 && TamaNumList[d - 7] != 10 && TamaNumList[d - 14] != 10 && TamaNumList[d - 21] != 10 && TamaNumList[d - 28] != 10 && TamaNumList[d - 35] != 10 && TamaNumList[d - 42] != 10)
                {
                    if (TamaNumList[a] == TamaNumList[e] && TamaNumList[e] < 49 && TamaNumList[e - 7] != 10 && TamaNumList[e - 14] != 10 && TamaNumList[e - 21] != 10 && TamaNumList[e - 28] != 10 && TamaNumList[e - 35] != 10 && TamaNumList[e - 42] != 10)
                    {
                        if (TamaNumList[a] == TamaNumList[f] && TamaNumList[f] < 49 && TamaNumList[f - 7] != 10 && TamaNumList[f - 14] != 10 && TamaNumList[f - 21] != 10 && TamaNumList[f - 28] != 10 && TamaNumList[f - 35] != 10 && TamaNumList[f - 42] != 10)
                        {
                            if (TamaNumList[a] == TamaNumList[g] && TamaNumList[g] < 49 && TamaNumList[g - 7] != 10 && TamaNumList[g - 14] != 10 && TamaNumList[g - 21] != 10 && TamaNumList[g - 28] != 10 && TamaNumList[g - 35] != 10 && TamaNumList[g - 42] != 10)
                            {
                                //7個消す
                                Destroy(TamaSpawnedList[a]);
                                Destroy(TamaSpawnedList[a + 1]);
                                Destroy(TamaSpawnedList[a + 2]);
                                Destroy(TamaSpawnedList[a + 3]);
                                Destroy(TamaSpawnedList[a + 4]);
                                Destroy(TamaSpawnedList[a + 5]);
                                Destroy(TamaSpawnedList[a + 6]);
                                TamaNumList[a] = 10;
                                TamaNumList[a + 1] = 10;
                                TamaNumList[a + 2] = 10;
                                TamaNumList[a + 3] = 10;
                                TamaNumList[a + 4] = 10;
                                TamaNumList[a + 5] = 10;
                                TamaNumList[a + 6] = 10;
                            }
                            else
                            {
                                //6個消す
                                Destroy(TamaSpawnedList[a]);
                                Destroy(TamaSpawnedList[a + 1]);
                                Destroy(TamaSpawnedList[a + 2]);
                                Destroy(TamaSpawnedList[a + 3]);
                                Destroy(TamaSpawnedList[a + 4]);
                                Destroy(TamaSpawnedList[a + 5]);
                                TamaNumList[a] = 10;
                                TamaNumList[a + 1] = 10;
                                TamaNumList[a + 2] = 10;
                                TamaNumList[a + 3] = 10;
                                TamaNumList[a + 4] = 10;
                                TamaNumList[a + 5] = 10;
                            }
                        }
                        else
                        {
                            //5個消す
                            Destroy(TamaSpawnedList[a]);
                            Destroy(TamaSpawnedList[a + 1]);
                            Destroy(TamaSpawnedList[a + 2]);
                            Destroy(TamaSpawnedList[a + 3]);
                            Destroy(TamaSpawnedList[a + 4]);
                            TamaNumList[a] = 10;
                            TamaNumList[a + 1] = 10;
                            TamaNumList[a + 2] = 10;
                            TamaNumList[a + 3] = 10;
                            TamaNumList[a + 4] = 10;
                        }
                    }
                    else
                    {
                        //4個消す
                        Destroy(TamaSpawnedList[a]);
                        Destroy(TamaSpawnedList[a + 1]);
                        Destroy(TamaSpawnedList[a + 2]);
                        Destroy(TamaSpawnedList[a + 3]);
                        TamaNumList[a] = 10;
                        TamaNumList[a + 1] = 10;
                        TamaNumList[a + 2] = 10;
                        TamaNumList[a + 3] = 10;
                    }
                }
                else
                {
                    //Nothing
                }
            }
        }

        for (int a = 49; a < 53; a++)
        {
            int b = a + 1;
            int c = a + 2;
            int d = a + 3;
            int e = a + 4;
            int f = a + 5;
            int g = a + 6;

            //8列
            if (TamaNumList[a] != 10 && TamaNumList[a] == TamaNumList[b] && TamaNumList[a] == TamaNumList[c] && TamaNumList[a] == TamaNumList[d])
            {
                //条件(49)
                if(TamaNumList[a - 7] != 10 && TamaNumList[a - 14] != 10 && TamaNumList[a - 21] != 10 && TamaNumList[a - 28] != 10 && TamaNumList[a - 35] != 10 && TamaNumList[a - 42] != 10 && TamaNumList[a - 49] != 10 && TamaNumList[b - 7] != 10 && TamaNumList[b - 14] != 10 && TamaNumList[b - 21] != 10 && TamaNumList[b - 28] != 10 && TamaNumList[b - 35] != 10 && TamaNumList[b - 42] != 10 && TamaNumList[b - 49] != 10 && TamaNumList[c - 7] != 10 && TamaNumList[c - 14] != 10 && TamaNumList[c - 21] != 10 && TamaNumList[c - 28] != 10 && TamaNumList[c - 35] != 10 && TamaNumList[c - 42] != 10 && TamaNumList[c - 49] != 10 && TamaNumList[d - 7] != 10 && TamaNumList[d - 14] != 10 && TamaNumList[d - 21] != 10 && TamaNumList[d - 28] != 10 && TamaNumList[d - 35] != 10 && TamaNumList[d - 42] != 10 && TamaNumList[d - 49] != 10)
                {
                    if (TamaNumList[a] == TamaNumList[e] && TamaNumList[e] < 56 && TamaNumList[e - 7] != 10 && TamaNumList[e - 14] != 10 && TamaNumList[e - 21] != 10 && TamaNumList[e - 28] != 10 && TamaNumList[e - 35] != 10 && TamaNumList[e - 42] != 10 && TamaNumList[e - 49] != 10)
                    {
                        if (TamaNumList[a] == TamaNumList[f] && TamaNumList[f] < 56 && TamaNumList[f - 7] != 10 && TamaNumList[f - 14] != 10 && TamaNumList[f - 21] != 10 && TamaNumList[f - 28] != 10 && TamaNumList[f - 35] != 10 && TamaNumList[f - 42] != 10 && TamaNumList[f - 49] != 10)
                        {
                            if (TamaNumList[a] == TamaNumList[g] && TamaNumList[g] < 56 && TamaNumList[g - 7] != 10 && TamaNumList[g - 14] != 10 && TamaNumList[g - 21] != 10 && TamaNumList[g - 28] != 10 && TamaNumList[g - 35] != 10 && TamaNumList[g - 42] != 10 && TamaNumList[g - 49] != 10)
                            {
                                //7個消す
                                Destroy(TamaSpawnedList[a]);
                                Destroy(TamaSpawnedList[a + 1]);
                                Destroy(TamaSpawnedList[a + 2]);
                                Destroy(TamaSpawnedList[a + 3]);
                                Destroy(TamaSpawnedList[a + 4]);
                                Destroy(TamaSpawnedList[a + 5]);
                                Destroy(TamaSpawnedList[a + 6]);
                                TamaNumList[a] = 10;
                                TamaNumList[a + 1] = 10;
                                TamaNumList[a + 2] = 10;
                                TamaNumList[a + 3] = 10;
                                TamaNumList[a + 4] = 10;
                                TamaNumList[a + 5] = 10;
                                TamaNumList[a + 6] = 10;
                            }
                            else
                            {
                                //6個消す
                                Destroy(TamaSpawnedList[a]);
                                Destroy(TamaSpawnedList[a + 1]);
                                Destroy(TamaSpawnedList[a + 2]);
                                Destroy(TamaSpawnedList[a + 3]);
                                Destroy(TamaSpawnedList[a + 4]);
                                Destroy(TamaSpawnedList[a + 5]);
                                TamaNumList[a] = 10;
                                TamaNumList[a + 1] = 10;
                                TamaNumList[a + 2] = 10;
                                TamaNumList[a + 3] = 10;
                                TamaNumList[a + 4] = 10;
                                TamaNumList[a + 5] = 10;
                            }
                        }
                        else
                        {
                            //5個消す
                            Destroy(TamaSpawnedList[a]);
                            Destroy(TamaSpawnedList[a + 1]);
                            Destroy(TamaSpawnedList[a + 2]);
                            Destroy(TamaSpawnedList[a + 3]);
                            Destroy(TamaSpawnedList[a + 4]);
                            TamaNumList[a] = 10;
                            TamaNumList[a + 1] = 10;
                            TamaNumList[a + 2] = 10;
                            TamaNumList[a + 3] = 10;
                            TamaNumList[a + 4] = 10;
                        }
                    }
                    else
                    {
                        //4個消す
                        Destroy(TamaSpawnedList[a]);
                        Destroy(TamaSpawnedList[a + 1]);
                        Destroy(TamaSpawnedList[a + 2]);
                        Destroy(TamaSpawnedList[a + 3]);
                        TamaNumList[a] = 10;
                        TamaNumList[a + 1] = 10;
                        TamaNumList[a + 2] = 10;
                        TamaNumList[a + 3] = 10;
                    }
                }
                else
                {
                    //Nothing
                }
            }
        }

        for (int a = 56; a < 60; a++)
        {
            int b = a + 1;
            int c = a + 2;
            int d = a + 3;
            int e = a + 4;
            int f = a + 5;
            int g = a + 6;

            //9列
            if (TamaNumList[a] != 10 && TamaNumList[a] == TamaNumList[b] && TamaNumList[a] == TamaNumList[c] && TamaNumList[a] == TamaNumList[d])
            {
                //条件(56)
                if(TamaNumList[a - 7] != 10 && TamaNumList[a - 14] != 10 && TamaNumList[a - 21] != 10 && TamaNumList[a - 28] != 10 && TamaNumList[a - 35] != 10 && TamaNumList[a - 42] != 10 && TamaNumList[a - 49] != 10 && TamaNumList[a - 56] != 10 && TamaNumList[b - 7] != 10 && TamaNumList[b - 14] != 10 && TamaNumList[b - 21] != 10 && TamaNumList[b - 28] != 10 && TamaNumList[b - 35] != 10 && TamaNumList[b - 42] != 10 && TamaNumList[b - 49] != 10 && TamaNumList[b - 56] != 10 && TamaNumList[c - 7] != 10 && TamaNumList[c - 14] != 10 && TamaNumList[c - 21] != 10 && TamaNumList[c - 28] != 10 && TamaNumList[c - 35] != 10 && TamaNumList[c - 42] != 10 && TamaNumList[c - 49] != 10 && TamaNumList[c - 56] != 10 && TamaNumList[d - 7] != 10 && TamaNumList[d - 14] != 10 && TamaNumList[d - 21] != 10 && TamaNumList[d - 28] != 10 && TamaNumList[d - 35] != 10 && TamaNumList[d - 42] != 10 && TamaNumList[d - 49] != 10 && TamaNumList[d - 56] != 10)
                {
                    if (TamaNumList[a] == TamaNumList[e] && TamaNumList[e] < 63 && TamaNumList[e - 7] != 10 && TamaNumList[e - 14] != 10 && TamaNumList[e - 21] != 10 && TamaNumList[e - 28] != 10 && TamaNumList[e - 35] != 10 && TamaNumList[e - 42] != 10 && TamaNumList[e - 49] != 10 && TamaNumList[e - 56] != 10)
                    {
                        if (TamaNumList[a] == TamaNumList[f] && TamaNumList[f] < 63 && TamaNumList[f - 7] != 10 && TamaNumList[f - 14] != 10 && TamaNumList[f - 21] != 10 && TamaNumList[f - 28] != 10 && TamaNumList[f - 35] != 10 && TamaNumList[f - 42] != 10 && TamaNumList[f - 49] != 10 && TamaNumList[f - 56] != 10)
                        {
                            if (TamaNumList[a] == TamaNumList[g] && TamaNumList[g] < 63 && TamaNumList[g - 7] != 10 && TamaNumList[g - 14] != 10 && TamaNumList[g - 21] != 10 && TamaNumList[g - 28] != 10 && TamaNumList[g - 35] != 10 && TamaNumList[g - 42] != 10 && TamaNumList[g - 49] != 10 && TamaNumList[g - 56] != 10)
                            {
                                //7個消す
                                Destroy(TamaSpawnedList[a]);
                                Destroy(TamaSpawnedList[a + 1]);
                                Destroy(TamaSpawnedList[a + 2]);
                                Destroy(TamaSpawnedList[a + 3]);
                                Destroy(TamaSpawnedList[a + 4]);
                                Destroy(TamaSpawnedList[a + 5]);
                                Destroy(TamaSpawnedList[a + 6]);
                                TamaNumList[a] = 10;
                                TamaNumList[a + 1] = 10;
                                TamaNumList[a + 2] = 10;
                                TamaNumList[a + 3] = 10;
                                TamaNumList[a + 4] = 10;
                                TamaNumList[a + 5] = 10;
                                TamaNumList[a + 6] = 10;
                            }
                            else
                            {
                                //6個消す
                                Destroy(TamaSpawnedList[a]);
                                Destroy(TamaSpawnedList[a + 1]);
                                Destroy(TamaSpawnedList[a + 2]);
                                Destroy(TamaSpawnedList[a + 3]);
                                Destroy(TamaSpawnedList[a + 4]);
                                Destroy(TamaSpawnedList[a + 5]);
                                TamaNumList[a] = 10;
                                TamaNumList[a + 1] = 10;
                                TamaNumList[a + 2] = 10;
                                TamaNumList[a + 3] = 10;
                                TamaNumList[a + 4] = 10;
                                TamaNumList[a + 5] = 10;
                            }
                        }
                        else
                        {
                            //5個消す
                            Destroy(TamaSpawnedList[a]);
                            Destroy(TamaSpawnedList[a + 1]);
                            Destroy(TamaSpawnedList[a + 2]);
                            Destroy(TamaSpawnedList[a + 3]);
                            Destroy(TamaSpawnedList[a + 4]);
                            TamaNumList[a] = 10;
                            TamaNumList[a + 1] = 10;
                            TamaNumList[a + 2] = 10;
                            TamaNumList[a + 3] = 10;
                            TamaNumList[a + 4] = 10;
                        }
                    }
                    else
                    {
                        //4個消す
                        Destroy(TamaSpawnedList[a]);
                        Destroy(TamaSpawnedList[a + 1]);
                        Destroy(TamaSpawnedList[a + 2]);
                        Destroy(TamaSpawnedList[a + 3]);
                        TamaNumList[a] = 10;
                        TamaNumList[a + 1] = 10;
                        TamaNumList[a + 2] = 10;
                        TamaNumList[a + 3] = 10;
                    }
                }
                else
                {
                    //Nothing
                }
            }
        }

        for (int a = 63; a < 67; a++)
        {
            int b = a + 1;
            int c = a + 2;
            int d = a + 3;
            int e = a + 4;
            int f = a + 5;
            int g = a + 6;

            //10列
            if (TamaNumList[a] != 10 && TamaNumList[a] == TamaNumList[b] && TamaNumList[a] == TamaNumList[c] && TamaNumList[a] == TamaNumList[d])
            {
                //条件(63)
                if(TamaNumList[a - 7] != 10 && TamaNumList[a - 14] != 10 && TamaNumList[a - 21] != 10 && TamaNumList[a - 28] != 10 && TamaNumList[a - 35] != 10 && TamaNumList[a - 42] != 10 && TamaNumList[a - 49] != 10 && TamaNumList[a - 56] != 10 && TamaNumList[a - 63] != 10 && TamaNumList[b - 7] != 10 && TamaNumList[b - 14] != 10 && TamaNumList[b - 21] != 10 && TamaNumList[b - 28] != 10 && TamaNumList[b - 35] != 10 && TamaNumList[b - 42] != 10 && TamaNumList[b - 49] != 10 && TamaNumList[b - 56] != 10 && TamaNumList[b - 63] != 10 && TamaNumList[c - 7] != 10 && TamaNumList[c - 14] != 10 && TamaNumList[c - 21] != 10 && TamaNumList[c - 28] != 10 && TamaNumList[c - 35] != 10 && TamaNumList[c - 42] != 10 && TamaNumList[c - 49] != 10 && TamaNumList[c - 56] != 10 && TamaNumList[c - 63] != 10 && TamaNumList[d - 7] != 10 && TamaNumList[d - 14] != 10 && TamaNumList[d - 21] != 10 && TamaNumList[d - 28] != 10 && TamaNumList[d - 35] != 10 && TamaNumList[d - 42] != 10 && TamaNumList[d - 49] != 10 && TamaNumList[d - 56] != 10 && TamaNumList[d - 63] != 10)
                {
                    if (TamaNumList[a] == TamaNumList[e] && TamaNumList[e] < 70 && TamaNumList[e - 7] != 10 && TamaNumList[e - 14] != 10 && TamaNumList[e - 21] != 10 && TamaNumList[e - 28] != 10 && TamaNumList[e - 35] != 10 && TamaNumList[e - 42] != 10 && TamaNumList[e - 49] != 10 && TamaNumList[e - 56] != 10 && TamaNumList[e - 63] != 10)
                    {
                        if (TamaNumList[a] == TamaNumList[f] && TamaNumList[f] < 70 && TamaNumList[f - 7] != 10 && TamaNumList[f - 14] != 10 && TamaNumList[f - 21] != 10 && TamaNumList[f - 28] != 10 && TamaNumList[f - 35] != 10 && TamaNumList[f - 42] != 10 && TamaNumList[f - 49] != 10 && TamaNumList[f - 56] != 10 && TamaNumList[f - 63] != 10)
                        {
                            if (TamaNumList[a] == TamaNumList[g] && TamaNumList[g] < 70 && TamaNumList[g - 7] != 10 && TamaNumList[g - 14] != 10 && TamaNumList[g - 21] != 10 && TamaNumList[g - 28] != 10 && TamaNumList[g - 35] != 10 && TamaNumList[g - 42] != 10 && TamaNumList[g - 49] != 10 && TamaNumList[g - 56] != 10 && TamaNumList[g - 63] != 10)
                            {
                                //7個消す
                                Destroy(TamaSpawnedList[a]);
                                Destroy(TamaSpawnedList[a + 1]);
                                Destroy(TamaSpawnedList[a + 2]);
                                Destroy(TamaSpawnedList[a + 3]);
                                Destroy(TamaSpawnedList[a + 4]);
                                Destroy(TamaSpawnedList[a + 5]);
                                Destroy(TamaSpawnedList[a + 6]);
                                TamaNumList[a] = 10;
                                TamaNumList[a + 1] = 10;
                                TamaNumList[a + 2] = 10;
                                TamaNumList[a + 3] = 10;
                                TamaNumList[a + 4] = 10;
                                TamaNumList[a + 5] = 10;
                                TamaNumList[a + 6] = 10;
                            }
                            else
                            {
                                //6個消す
                                Destroy(TamaSpawnedList[a]);
                                Destroy(TamaSpawnedList[a + 1]);
                                Destroy(TamaSpawnedList[a + 2]);
                                Destroy(TamaSpawnedList[a + 3]);
                                Destroy(TamaSpawnedList[a + 4]);
                                Destroy(TamaSpawnedList[a + 5]);
                                TamaNumList[a] = 10;
                                TamaNumList[a + 1] = 10;
                                TamaNumList[a + 2] = 10;
                                TamaNumList[a + 3] = 10;
                                TamaNumList[a + 4] = 10;
                                TamaNumList[a + 5] = 10;
                            }
                        }
                        else
                        {
                            //5個消す
                            Destroy(TamaSpawnedList[a]);
                            Destroy(TamaSpawnedList[a + 1]);
                            Destroy(TamaSpawnedList[a + 2]);
                            Destroy(TamaSpawnedList[a + 3]);
                            Destroy(TamaSpawnedList[a + 4]);
                            TamaNumList[a] = 10;
                            TamaNumList[a + 1] = 10;
                            TamaNumList[a + 2] = 10;
                            TamaNumList[a + 3] = 10;
                            TamaNumList[a + 4] = 10;
                        }
                    }
                    else
                    {
                        //4個消す
                        Destroy(TamaSpawnedList[a]);
                        Destroy(TamaSpawnedList[a + 1]);
                        Destroy(TamaSpawnedList[a + 2]);
                        Destroy(TamaSpawnedList[a + 3]);
                        TamaNumList[a] = 10;
                        TamaNumList[a + 1] = 10;
                        TamaNumList[a + 2] = 10;
                        TamaNumList[a + 3] = 10;
                    }
                }
                else
                {
                    //Nothing
                }

            }
        }

        //Tama Clear Vertical
        for(int b = 0; b < 49; b++)
        {
            if(TamaNumList[b] != 10 && TamaNumList[b] == TamaNumList[b + 7] && TamaNumList[b] == TamaNumList[b + 14] && TamaNumList[b] == TamaNumList[b + 21])
            {
                if(TamaNumList[b] == TamaNumList[b + 28] && TamaNumList[b + 28] < 70)
                {
                    if(TamaNumList[b] == TamaNumList[b + 35] && TamaNumList[b + 35] < 70)
                    {
                        if(TamaNumList[b] == TamaNumList[b + 42] && TamaNumList[b + 42] < 70)
                        {
                            //7個消す
                            Destroy(TamaSpawnedList[b]);
                            Destroy(TamaSpawnedList[b + 7]);
                            Destroy(TamaSpawnedList[b + 14]);
                            Destroy(TamaSpawnedList[b + 21]);
                            Destroy(TamaSpawnedList[b + 28]);
                            Destroy(TamaSpawnedList[b + 35]);
                            Destroy(TamaSpawnedList[b + 42]);
                            TamaNumList[b] = 10;
                            TamaNumList[b + 7] = 10;
                            TamaNumList[b + 14] = 10;
                            TamaNumList[b + 21] = 10;
                            TamaNumList[b + 28] = 10;
                            TamaNumList[b + 35] = 10;
                            TamaNumList[b + 42] = 10;
                        }
                        else
                        {
                            //6個消す
                            Destroy(TamaSpawnedList[b]);
                            Destroy(TamaSpawnedList[b + 7]);
                            Destroy(TamaSpawnedList[b + 14]);
                            Destroy(TamaSpawnedList[b + 21]);
                            Destroy(TamaSpawnedList[b + 28]);
                            Destroy(TamaSpawnedList[b + 35]);
                            TamaNumList[b] = 10;
                            TamaNumList[b + 7] = 10;
                            TamaNumList[b + 14] = 10;
                            TamaNumList[b + 21] = 10;
                            TamaNumList[b + 28] = 10;
                            TamaNumList[b + 35] = 10;
                        }
                    }
                    else
                    {
                        //5個消す
                        Destroy(TamaSpawnedList[b]);
                        Destroy(TamaSpawnedList[b + 7]);
                        Destroy(TamaSpawnedList[b + 14]);
                        Destroy(TamaSpawnedList[b + 21]);
                        Destroy(TamaSpawnedList[b + 28]);
                        TamaNumList[b] = 10;
                        TamaNumList[b + 7] = 10;
                        TamaNumList[b + 14] = 10;
                        TamaNumList[b + 21] = 10;
                        TamaNumList[b + 28] = 10;
                    }
                }
                else
                {
                    //4個消す
                    Destroy(TamaSpawnedList[b]);
                    Destroy(TamaSpawnedList[b + 7]);
                    Destroy(TamaSpawnedList[b + 14]);
                    Destroy(TamaSpawnedList[b + 21]);
                    TamaNumList[b] = 10;
                    TamaNumList[b + 7] = 10;
                    TamaNumList[b + 14] = 10;
                    TamaNumList[b + 21] = 10;
                }
            }
        }
        

        StartCoroutine(TamaMoveClear());
    }

    //Skill
    //Skill_bat
    public void BtnSkillBat()
    {
        Debug.Log("Skill : Bat");
    }

    //Skill BottomDelete
    public void BtnSkillBottomDelete()
    {
        for(int i = 0; i < 7; i++)
        {
            if(TamaNumList[i] == 10)
            {

            }
            else if(TamaNumList[i] != 10)
            {
                //7個消す
                Destroy(TamaSpawnedList[i]);
                TamaNumList[i] = 10;
            }
        }
        Debug.Log("Skill : BottomDelete");
    }

    //Skill Rocket
    public void BtnSkillRocket()
    {
        int a = -1;
        int b = -1;
        int c = -1;
        int d = -1;
        int e = -1;

        while(true)
        {
            if(a == -1)
            {
                int i = Random.Range(0, 84);

                if(TamaNumList[i] == 10)
                {
                    //OneMore
                }
                else if(TamaNumList[i] != 10)
                {
                    a = i;
                    Debug.Log("a : " + a);
                }
            }
            else if(a != -1 && b == -1)
            {
                int i = Random.Range(0, 84);

                if (TamaNumList[i] == 10 || i == a)
                {
                    //OneMore
                }
                else if (TamaNumList[i] != 10 && i != a)
                {
                    b = i;
                    Debug.Log("b : " + b);
                }
            }
            else if (a != -1 && b != -1 && c == -1)
            {
                int i = Random.Range(0, 84);

                if (TamaNumList[i] == 10 || i == a || i == b)
                {
                    //OneMore
                }
                else if (TamaNumList[i] != 10 && i != a && i != b)
                {
                    c = i;
                    Debug.Log("c : " + c);
                }
            }
            else if (a != -1 && b != -1 && c != -1 && d == -1)
            {
                int i = Random.Range(0, 84);

                if (TamaNumList[i] == 10 || i == a || i == b || i == c)
                {
                    //OneMore
                }
                else if (TamaNumList[i] != 10 && i != a && i != b && i != c)
                {
                    d = i;
                    Debug.Log("d : " + d);
                }
            }
            else if (a != -1 && b != -1 && c != -1 && d != -1 && e == -1)
            {
                int i = Random.Range(0, 84);

                if (TamaNumList[i] == 10 || i == a || i == b || i == c || i == d)
                {
                    //OneMore
                }
                else if (TamaNumList[i] != 10 && i != a && i != b && i != c && i != d)
                {
                    e = i;
                    Debug.Log("e : " + e);
                }
            }
            else if(a != -1 && b != -1 && c != -1 && d != -1 && e != -1)
            {
                //5個消す
                Destroy(TamaSpawnedList[a]);
                Destroy(TamaSpawnedList[b]);
                Destroy(TamaSpawnedList[c]);
                Destroy(TamaSpawnedList[d]);
                Destroy(TamaSpawnedList[e]);
                TamaNumList[a] = 10;
                TamaNumList[b] = 10;
                TamaNumList[c] = 10;
                TamaNumList[d] = 10;
                TamaNumList[e] = 10;
                break;
            }

            Debug.Log("Skill : Rocket");
        }
    }

    //Skill Turtle
    public void BtnSkillTurtle()
    {
        tamaSpeed = 0.5f;
        Debug.Log("Skill : Turtle");
    }

    //Skill Stop
    public void BtnSkillStop()
    {
        GameObject.Find("UILogic").GetComponent<GameUIManager>().SkillStop();
        Debug.Log("Skill : Stop");
    }

    //Skill CharacterSkill
    public void BtnSkillCharacterSkill()
    {
        Debug.Log("Skill : CharacterSkill");
    }
}
