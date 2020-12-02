using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public const int ColumnCount = 7;
    public const int RowCount = 12;
    public const int TamaNull = 10;
    public const int TamaMinChainCount = 4;
    //Tama
    public float tamaSpeed;
    int carryNum;
    int selectNum;
    int receiveDropNum;
    bool checkCarry;      //true=carry   , false=not carry
    bool checkSelectTamaDelete;         //true=Delete   , false=not Delete

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

        carryNum = TamaNull;
        selectNum = TamaNull;
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
            NextTamaNumList[i] = TamaNull;
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
        if(TamaNumList[0] != TamaNull)
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
        if (TamaNumList[1] != TamaNull)
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
        if (TamaNumList[2] != TamaNull)
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
        if (TamaNumList[3] != TamaNull)
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
        if (TamaNumList[4] != TamaNull)
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
        if (TamaNumList[5] != TamaNull)
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
        if (TamaNumList[6] != TamaNull)
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
                    TamaNumList[0] = TamaNull;
                    checkSelectTamaDelete = false;
                    break;
                case 1:
                    Destroy(TamaSpawnedList[1]);
                    TamaNumList[1] = TamaNull;
                    checkSelectTamaDelete = false;
                    break;
                case 2:
                    Destroy(TamaSpawnedList[2]);
                    TamaNumList[2] = TamaNull;
                    checkSelectTamaDelete = false;
                    break;
                case 3:
                    Destroy(TamaSpawnedList[3]);
                    TamaNumList[3] = TamaNull;
                    checkSelectTamaDelete = false;
                    break;
                case 4:
                    Destroy(TamaSpawnedList[4]);
                    TamaNumList[4] = TamaNull;
                    checkSelectTamaDelete = false;
                    break;
                case 5:
                    Destroy(TamaSpawnedList[5]);
                    TamaNumList[5] = TamaNull;
                    checkSelectTamaDelete = false;
                    break;
                case 6:
                    Destroy(TamaSpawnedList[6]);
                    TamaNumList[6] = TamaNull;
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
            if(TamaNumList[63] == TamaNull && TamaNumList[64] == TamaNull && TamaNumList[65] == TamaNull && TamaNumList[66] == TamaNull && TamaNumList[67] == TamaNull && TamaNumList[68] == TamaNull && TamaNumList[69] == TamaNull)
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
            else if(TamaNumList[70] == TamaNull && TamaNumList[71] == TamaNull && TamaNumList[72] == TamaNull && TamaNumList[73] == TamaNull && TamaNumList[74] == TamaNull && TamaNumList[75] == TamaNull && TamaNumList[76] == TamaNull)
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
                if (TamaNumList[77] == TamaNull && TamaNumList[78] == TamaNull && TamaNumList[79] == TamaNull && TamaNumList[80] == TamaNull && TamaNumList[81] == TamaNull && TamaNumList[82] == TamaNull && TamaNumList[83] == TamaNull)
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
            carryNum = TamaNull;
            selectNum = TamaNull;
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
        yield return TamaMove();

        CheckTamaClearHorizonal();
        CheckTamaClearVertical();

        // roop
        StartCoroutine(TamaMoveClear());
    }

    //Move (Tama Fall.)
    IEnumerator TamaMove ()
    {
        for (int i = 0; i < 77; i++)
        {
            if (TamaNumList[i] == TamaNull)
            {
                if (TamaNumList[i + 7] != TamaNull)
                {
                    Transform targetPoint = TamaTransformList[i];
                    GameObject newTama = Instantiate(TamaKindList[TamaNumList[i + 7]]);
                    newTama.transform.position = targetPoint.position;
                    TamaSpawnedList[i] = newTama;
                    TamaNumList[i] = TamaNumList[i + 7];

                    Destroy(TamaSpawnedList[i + 7]);
                    TamaNumList[i + 7] = TamaNull;
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
    }

    /// <summary>
    /// Check Tama Clear.
    /// </summary>
    void CheckTamaClearHorizonal()
    {
        // 縦方向
        for (var v = 0; v < RowCount - 1; v++)
        {
            // 横方向
            for (int h = 0; h < ColumnCount - 3; h++)
            {
                // 探索中の配列index and object
                var targetIndex = v * ColumnCount + h;
                var targetTama = TamaNumList[targetIndex];

                // 連結しているか探索 (横方向 chain horizonai)
                var chainCount = 1;
                var limitCount = (v + 1) * ColumnCount;
                var chainStrings = $"[{v}:{h}] ({targetTama}) [{targetIndex}]";

                if (targetIndex < ColumnCount)
                {
                    for (var ch = targetIndex + 1; ch < limitCount; ch++)
                    {
                        // 連結しているならカウントアップ
                        if (targetTama != TamaNull && targetTama == TamaNumList[ch])
                        {
                            chainCount++;
                            chainStrings += $" | [{ch}]";
                        }
                        else
                            break;
                    }
                }
                else
                {
                    for (var ch = targetIndex + 1; ch < limitCount; ch++)
                    {
                        // 連結しているならカウントアップ
                        if (targetTama != TamaNull && targetTama == TamaNumList[ch] && TamaNumList[ch - ColumnCount] != TamaNull)
                        {
                            chainCount++;
                            chainStrings += $" | [{ch}]";
                        }
                        else
                            break;
                    }
                }

                //Debug.Log($"{chainCount}"); 
                if (TamaMinChainCount <= chainCount)
                {
                    Debug.Log($"{chainStrings}");
                    for (var ch = targetIndex; ch < targetIndex + chainCount; ch++)
                    {
                        Destroy(TamaSpawnedList[ch]);
                        TamaNumList[ch] = TamaNull;
                    }
                    break;
                }
            }
        }
        {
            /*
            //Tama Clear Horizontal
            for (int i = 0; i < ColumnCount; i++)
            {
                //下 1列
                var checkTama = TamaNumList[i];
                if (checkTama != TamaNull && checkTama == TamaNumList[i + 1] &&
                    checkTama == TamaNumList[i + 2] && checkTama == TamaNumList[i + 3])
                {
                    if (checkTama == TamaNumList[i + 4] && i + 4 < ColumnCount)
                    {
                        if (checkTama == TamaNumList[i + 5] && i + 5 < ColumnCount)
                        {
                            if (checkTama == TamaNumList[i + 6] && i + 6 < ColumnCount)
                            {
                                //7個消す
                                Destroy(TamaSpawnedList[i]);
                                Destroy(TamaSpawnedList[i + 1]);
                                Destroy(TamaSpawnedList[i + 2]);
                                Destroy(TamaSpawnedList[i + 3]);
                                Destroy(TamaSpawnedList[i + 4]);
                                Destroy(TamaSpawnedList[i + 5]);
                                Destroy(TamaSpawnedList[i + 6]);
                                TamaNumList[i] = TamaNull;
                                TamaNumList[i + 1] = TamaNull;
                                TamaNumList[i + 2] = TamaNull;
                                TamaNumList[i + 3] = TamaNull;
                                TamaNumList[i + 4] = TamaNull;
                                TamaNumList[i + 5] = TamaNull;
                                TamaNumList[i + 6] = TamaNull;
                            }
                            else
                            {
                                //6個消す
                                Destroy(TamaSpawnedList[i]);
                                Destroy(TamaSpawnedList[i + 1]);
                                Destroy(TamaSpawnedList[i + 2]);
                                Destroy(TamaSpawnedList[i + 3]);
                                Destroy(TamaSpawnedList[i + 4]);
                                Destroy(TamaSpawnedList[i + 5]);
                                TamaNumList[i] = TamaNull;
                                TamaNumList[i + 1] = TamaNull;
                                TamaNumList[i + 2] = TamaNull;
                                TamaNumList[i + 3] = TamaNull;
                                TamaNumList[i + 4] = TamaNull;
                                TamaNumList[i + 5] = TamaNull;
                            }
                        }
                        else
                        {
                            //5個消す
                            Destroy(TamaSpawnedList[i]);
                            Destroy(TamaSpawnedList[i + 1]);
                            Destroy(TamaSpawnedList[i + 2]);
                            Destroy(TamaSpawnedList[i + 3]);
                            Destroy(TamaSpawnedList[i + 4]);
                            TamaNumList[i] = TamaNull;
                            TamaNumList[i + 1] = TamaNull;
                            TamaNumList[i + 2] = TamaNull;
                            TamaNumList[i + 3] = TamaNull;
                            TamaNumList[i + 4] = TamaNull;
                        }
                    }
                    else
                    {
                        //4個消す
                        Destroy(TamaSpawnedList[i]);
                        Destroy(TamaSpawnedList[i + 1]);
                        Destroy(TamaSpawnedList[i + 2]);
                        Destroy(TamaSpawnedList[i + 3]);
                        TamaNumList[i] = TamaNull;
                        TamaNumList[i + 1] = TamaNull;
                        TamaNumList[i + 2] = TamaNull;
                        TamaNumList[i + 3] = TamaNull;
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
                if (TamaNumList[a] != TamaNull && TamaNumList[a] == TamaNumList[b] && TamaNumList[a] == TamaNumList[c] && TamaNumList[a] == TamaNumList[d])
                {
                    //条件
                    if (TamaNumList[a - 7] != TamaNull && TamaNumList[b - 7] != TamaNull && TamaNumList[c - 7] != TamaNull && TamaNumList[d - 7] != TamaNull)
                    {
                        if (TamaNumList[a] == TamaNumList[e] && TamaNumList[e] < 14 && TamaNumList[e - 7] != TamaNull)
                        {
                            if (TamaNumList[a] == TamaNumList[f] && TamaNumList[f] < 14 && TamaNumList[f - 7] != TamaNull)
                            {
                                if (TamaNumList[a] == TamaNumList[g] && TamaNumList[g] < 14 && TamaNumList[g - 7] != TamaNull)
                                {
                                    //7個消す
                                    Destroy(TamaSpawnedList[a]);
                                    Destroy(TamaSpawnedList[a + 1]);
                                    Destroy(TamaSpawnedList[a + 2]);
                                    Destroy(TamaSpawnedList[a + 3]);
                                    Destroy(TamaSpawnedList[a + 4]);
                                    Destroy(TamaSpawnedList[a + 5]);
                                    Destroy(TamaSpawnedList[a + 6]);
                                    TamaNumList[a] = TamaNull;
                                    TamaNumList[a + 1] = TamaNull;
                                    TamaNumList[a + 2] = TamaNull;
                                    TamaNumList[a + 3] = TamaNull;
                                    TamaNumList[a + 4] = TamaNull;
                                    TamaNumList[a + 5] = TamaNull;
                                    TamaNumList[a + 6] = TamaNull;
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
                                    TamaNumList[a] = TamaNull;
                                    TamaNumList[a + 1] = TamaNull;
                                    TamaNumList[a + 2] = TamaNull;
                                    TamaNumList[a + 3] = TamaNull;
                                    TamaNumList[a + 4] = TamaNull;
                                    TamaNumList[a + 5] = TamaNull;
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
                                TamaNumList[a] = TamaNull;
                                TamaNumList[a + 1] = TamaNull;
                                TamaNumList[a + 2] = TamaNull;
                                TamaNumList[a + 3] = TamaNull;
                                TamaNumList[a + 4] = TamaNull;
                            }
                        }
                        else
                        {
                            //4個消す
                            Destroy(TamaSpawnedList[a]);
                            Destroy(TamaSpawnedList[a + 1]);
                            Destroy(TamaSpawnedList[a + 2]);
                            Destroy(TamaSpawnedList[a + 3]);
                            TamaNumList[a] = TamaNull;
                            TamaNumList[a + 1] = TamaNull;
                            TamaNumList[a + 2] = TamaNull;
                            TamaNumList[a + 3] = TamaNull;
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
                if (TamaNumList[a] != TamaNull && TamaNumList[a] == TamaNumList[b] && TamaNumList[a] == TamaNumList[c] && TamaNumList[a] == TamaNumList[d])
                {
                    //条件
                    if (TamaNumList[a - 7] != TamaNull && TamaNumList[a - 14] != TamaNull && TamaNumList[b - 7] != TamaNull && TamaNumList[b - 14] != TamaNull && TamaNumList[c - 7] != TamaNull && TamaNumList[c - 14] != TamaNull && TamaNumList[d - 7] != TamaNull && TamaNumList[d - 14] != TamaNull)
                    {
                        if (TamaNumList[a] == TamaNumList[e] && TamaNumList[e] < 21 && TamaNumList[e - 7] != TamaNull && TamaNumList[e - 14] != TamaNull)
                        {
                            if (TamaNumList[a] == TamaNumList[f] && TamaNumList[f] < 21 && TamaNumList[f - 7] != TamaNull && TamaNumList[f - 14] != TamaNull)
                            {
                                if (TamaNumList[a] == TamaNumList[g] && TamaNumList[g] < 21 && TamaNumList[g - 7] != TamaNull && TamaNumList[g - 14] != TamaNull)
                                {
                                    //7個消す
                                    Destroy(TamaSpawnedList[a]);
                                    Destroy(TamaSpawnedList[a + 1]);
                                    Destroy(TamaSpawnedList[a + 2]);
                                    Destroy(TamaSpawnedList[a + 3]);
                                    Destroy(TamaSpawnedList[a + 4]);
                                    Destroy(TamaSpawnedList[a + 5]);
                                    Destroy(TamaSpawnedList[a + 6]);
                                    TamaNumList[a] = TamaNull;
                                    TamaNumList[a + 1] = TamaNull;
                                    TamaNumList[a + 2] = TamaNull;
                                    TamaNumList[a + 3] = TamaNull;
                                    TamaNumList[a + 4] = TamaNull;
                                    TamaNumList[a + 5] = TamaNull;
                                    TamaNumList[a + 6] = TamaNull;
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
                                    TamaNumList[a] = TamaNull;
                                    TamaNumList[a + 1] = TamaNull;
                                    TamaNumList[a + 2] = TamaNull;
                                    TamaNumList[a + 3] = TamaNull;
                                    TamaNumList[a + 4] = TamaNull;
                                    TamaNumList[a + 5] = TamaNull;
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
                                TamaNumList[a] = TamaNull;
                                TamaNumList[a + 1] = TamaNull;
                                TamaNumList[a + 2] = TamaNull;
                                TamaNumList[a + 3] = TamaNull;
                                TamaNumList[a + 4] = TamaNull;
                            }
                        }
                        else
                        {
                            //4個消す
                            Destroy(TamaSpawnedList[a]);
                            Destroy(TamaSpawnedList[a + 1]);
                            Destroy(TamaSpawnedList[a + 2]);
                            Destroy(TamaSpawnedList[a + 3]);
                            TamaNumList[a] = TamaNull;
                            TamaNumList[a + 1] = TamaNull;
                            TamaNumList[a + 2] = TamaNull;
                            TamaNumList[a + 3] = TamaNull;
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
                if (TamaNumList[a] != TamaNull && TamaNumList[a] == TamaNumList[b] && TamaNumList[a] == TamaNumList[c] && TamaNumList[a] == TamaNumList[d])
                {
                    //条件
                    if (TamaNumList[a - 7] != TamaNull && TamaNumList[a - 14] != TamaNull && TamaNumList[a - 21] != TamaNull && TamaNumList[b - 7] != TamaNull && TamaNumList[b - 14] != TamaNull && TamaNumList[b - 21] != TamaNull && TamaNumList[c - 7] != TamaNull && TamaNumList[c - 14] != TamaNull && TamaNumList[c - 21] != TamaNull && TamaNumList[d - 7] != TamaNull && TamaNumList[d - 14] != TamaNull && TamaNumList[d - 21] != TamaNull)
                    {
                        if (TamaNumList[a] == TamaNumList[e] && TamaNumList[e] < 28 && TamaNumList[e - 7] != TamaNull && TamaNumList[e - 14] != TamaNull && TamaNumList[e - 21] != TamaNull)
                        {
                            if (TamaNumList[a] == TamaNumList[f] && TamaNumList[f] < 28 && TamaNumList[f - 7] != TamaNull && TamaNumList[f - 14] != TamaNull && TamaNumList[f - 21] != TamaNull)
                            {
                                if (TamaNumList[a] == TamaNumList[g] && TamaNumList[g] < 28 && TamaNumList[g - 7] != TamaNull && TamaNumList[g - 14] != TamaNull && TamaNumList[g - 21] != TamaNull)
                                {
                                    //7個消す
                                    Destroy(TamaSpawnedList[a]);
                                    Destroy(TamaSpawnedList[a + 1]);
                                    Destroy(TamaSpawnedList[a + 2]);
                                    Destroy(TamaSpawnedList[a + 3]);
                                    Destroy(TamaSpawnedList[a + 4]);
                                    Destroy(TamaSpawnedList[a + 5]);
                                    Destroy(TamaSpawnedList[a + 6]);
                                    TamaNumList[a] = TamaNull;
                                    TamaNumList[a + 1] = TamaNull;
                                    TamaNumList[a + 2] = TamaNull;
                                    TamaNumList[a + 3] = TamaNull;
                                    TamaNumList[a + 4] = TamaNull;
                                    TamaNumList[a + 5] = TamaNull;
                                    TamaNumList[a + 6] = TamaNull;
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
                                    TamaNumList[a] = TamaNull;
                                    TamaNumList[a + 1] = TamaNull;
                                    TamaNumList[a + 2] = TamaNull;
                                    TamaNumList[a + 3] = TamaNull;
                                    TamaNumList[a + 4] = TamaNull;
                                    TamaNumList[a + 5] = TamaNull;
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
                                TamaNumList[a] = TamaNull;
                                TamaNumList[a + 1] = TamaNull;
                                TamaNumList[a + 2] = TamaNull;
                                TamaNumList[a + 3] = TamaNull;
                                TamaNumList[a + 4] = TamaNull;
                            }
                        }
                        else
                        {
                            //4個消す
                            Destroy(TamaSpawnedList[a]);
                            Destroy(TamaSpawnedList[a + 1]);
                            Destroy(TamaSpawnedList[a + 2]);
                            Destroy(TamaSpawnedList[a + 3]);
                            TamaNumList[a] = TamaNull;
                            TamaNumList[a + 1] = TamaNull;
                            TamaNumList[a + 2] = TamaNull;
                            TamaNumList[a + 3] = TamaNull;
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
                if (TamaNumList[a] != TamaNull && TamaNumList[a] == TamaNumList[b] && TamaNumList[a] == TamaNumList[c] && TamaNumList[a] == TamaNumList[d])
                {
                    //条件
                    if (TamaNumList[a - 7] != TamaNull && TamaNumList[a - 14] != TamaNull && TamaNumList[a - 21] != TamaNull && TamaNumList[a - 28] != TamaNull && TamaNumList[b - 7] != TamaNull && TamaNumList[b - 14] != TamaNull && TamaNumList[b - 21] != TamaNull && TamaNumList[b - 28] != TamaNull && TamaNumList[c - 7] != TamaNull && TamaNumList[c - 14] != TamaNull && TamaNumList[c - 21] != TamaNull && TamaNumList[c - 28] != TamaNull && TamaNumList[d - 7] != TamaNull && TamaNumList[d - 14] != TamaNull && TamaNumList[d - 21] != TamaNull && TamaNumList[d - 28] != TamaNull)
                    {
                        if (TamaNumList[a] == TamaNumList[e] && TamaNumList[e] < 35 && TamaNumList[e - 7] != TamaNull && TamaNumList[e - 14] != TamaNull && TamaNumList[e - 21] != TamaNull && TamaNumList[e - 28] != TamaNull)
                        {
                            if (TamaNumList[a] == TamaNumList[f] && TamaNumList[f] < 35 && TamaNumList[f - 7] != TamaNull && TamaNumList[f - 14] != TamaNull && TamaNumList[f - 21] != TamaNull && TamaNumList[f - 28] != TamaNull)
                            {
                                if (TamaNumList[a] == TamaNumList[g] && TamaNumList[g] < 35 && TamaNumList[g - 7] != TamaNull && TamaNumList[g - 14] != TamaNull && TamaNumList[g - 21] != TamaNull && TamaNumList[g - 28] != TamaNull)
                                {
                                    //7個消す
                                    Destroy(TamaSpawnedList[a]);
                                    Destroy(TamaSpawnedList[a + 1]);
                                    Destroy(TamaSpawnedList[a + 2]);
                                    Destroy(TamaSpawnedList[a + 3]);
                                    Destroy(TamaSpawnedList[a + 4]);
                                    Destroy(TamaSpawnedList[a + 5]);
                                    Destroy(TamaSpawnedList[a + 6]);
                                    TamaNumList[a] = TamaNull;
                                    TamaNumList[a + 1] = TamaNull;
                                    TamaNumList[a + 2] = TamaNull;
                                    TamaNumList[a + 3] = TamaNull;
                                    TamaNumList[a + 4] = TamaNull;
                                    TamaNumList[a + 5] = TamaNull;
                                    TamaNumList[a + 6] = TamaNull;
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
                                    TamaNumList[a] = TamaNull;
                                    TamaNumList[a + 1] = TamaNull;
                                    TamaNumList[a + 2] = TamaNull;
                                    TamaNumList[a + 3] = TamaNull;
                                    TamaNumList[a + 4] = TamaNull;
                                    TamaNumList[a + 5] = TamaNull;
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
                                TamaNumList[a] = TamaNull;
                                TamaNumList[a + 1] = TamaNull;
                                TamaNumList[a + 2] = TamaNull;
                                TamaNumList[a + 3] = TamaNull;
                                TamaNumList[a + 4] = TamaNull;
                            }
                        }
                        else
                        {
                            //4個消す
                            Destroy(TamaSpawnedList[a]);
                            Destroy(TamaSpawnedList[a + 1]);
                            Destroy(TamaSpawnedList[a + 2]);
                            Destroy(TamaSpawnedList[a + 3]);
                            TamaNumList[a] = TamaNull;
                            TamaNumList[a + 1] = TamaNull;
                            TamaNumList[a + 2] = TamaNull;
                            TamaNumList[a + 3] = TamaNull;
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
                if (TamaNumList[a] != TamaNull && TamaNumList[a] == TamaNumList[b] && TamaNumList[a] == TamaNumList[c] && TamaNumList[a] == TamaNumList[d])
                {
                    //条件(35)
                    if (TamaNumList[a - 7] != TamaNull && TamaNumList[a - 14] != TamaNull && TamaNumList[a - 21] != TamaNull && TamaNumList[a - 28] != TamaNull && TamaNumList[a - 35] != TamaNull && TamaNumList[b - 7] != TamaNull && TamaNumList[b - 14] != TamaNull && TamaNumList[b - 21] != TamaNull && TamaNumList[b - 28] != TamaNull && TamaNumList[b - 35] != TamaNull && TamaNumList[c - 7] != TamaNull && TamaNumList[c - 14] != TamaNull && TamaNumList[c - 21] != TamaNull && TamaNumList[c - 28] != TamaNull && TamaNumList[c - 35] != TamaNull && TamaNumList[d - 7] != TamaNull && TamaNumList[d - 14] != TamaNull && TamaNumList[d - 21] != TamaNull && TamaNumList[d - 28] != TamaNull && TamaNumList[d - 35] != TamaNull)
                    {
                        if (TamaNumList[a] == TamaNumList[e] && TamaNumList[e] < 42 && TamaNumList[e - 7] != TamaNull && TamaNumList[e - 14] != TamaNull && TamaNumList[e - 21] != TamaNull && TamaNumList[e - 28] != TamaNull && TamaNumList[e - 35] != TamaNull)
                        {
                            if (TamaNumList[a] == TamaNumList[f] && TamaNumList[f] < 42 && TamaNumList[f - 7] != TamaNull && TamaNumList[f - 14] != TamaNull && TamaNumList[f - 21] != TamaNull && TamaNumList[f - 28] != TamaNull && TamaNumList[f - 35] != TamaNull)
                            {
                                if (TamaNumList[a] == TamaNumList[g] && TamaNumList[g] < 42 && TamaNumList[g - 7] != TamaNull && TamaNumList[g - 14] != TamaNull && TamaNumList[g - 21] != TamaNull && TamaNumList[g - 28] != TamaNull && TamaNumList[g - 35] != TamaNull)
                                {
                                    //7個消す
                                    Destroy(TamaSpawnedList[a]);
                                    Destroy(TamaSpawnedList[a + 1]);
                                    Destroy(TamaSpawnedList[a + 2]);
                                    Destroy(TamaSpawnedList[a + 3]);
                                    Destroy(TamaSpawnedList[a + 4]);
                                    Destroy(TamaSpawnedList[a + 5]);
                                    Destroy(TamaSpawnedList[a + 6]);
                                    TamaNumList[a] = TamaNull;
                                    TamaNumList[a + 1] = TamaNull;
                                    TamaNumList[a + 2] = TamaNull;
                                    TamaNumList[a + 3] = TamaNull;
                                    TamaNumList[a + 4] = TamaNull;
                                    TamaNumList[a + 5] = TamaNull;
                                    TamaNumList[a + 6] = TamaNull;
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
                                    TamaNumList[a] = TamaNull;
                                    TamaNumList[a + 1] = TamaNull;
                                    TamaNumList[a + 2] = TamaNull;
                                    TamaNumList[a + 3] = TamaNull;
                                    TamaNumList[a + 4] = TamaNull;
                                    TamaNumList[a + 5] = TamaNull;
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
                                TamaNumList[a] = TamaNull;
                                TamaNumList[a + 1] = TamaNull;
                                TamaNumList[a + 2] = TamaNull;
                                TamaNumList[a + 3] = TamaNull;
                                TamaNumList[a + 4] = TamaNull;
                            }
                        }
                        else
                        {
                            //4個消す
                            Destroy(TamaSpawnedList[a]);
                            Destroy(TamaSpawnedList[a + 1]);
                            Destroy(TamaSpawnedList[a + 2]);
                            Destroy(TamaSpawnedList[a + 3]);
                            TamaNumList[a] = TamaNull;
                            TamaNumList[a + 1] = TamaNull;
                            TamaNumList[a + 2] = TamaNull;
                            TamaNumList[a + 3] = TamaNull;
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
                if (TamaNumList[a] != TamaNull && TamaNumList[a] == TamaNumList[b] && TamaNumList[a] == TamaNumList[c] && TamaNumList[a] == TamaNumList[d])
                {
                    //条件(42)
                    if (TamaNumList[a - 7] != TamaNull && TamaNumList[a - 14] != TamaNull && TamaNumList[a - 21] != TamaNull && TamaNumList[a - 28] != TamaNull && TamaNumList[a - 35] != TamaNull && TamaNumList[a - 42] != TamaNull && TamaNumList[b - 7] != TamaNull && TamaNumList[b - 14] != TamaNull && TamaNumList[b - 21] != TamaNull && TamaNumList[b - 28] != TamaNull && TamaNumList[b - 35] != TamaNull && TamaNumList[b - 42] != TamaNull && TamaNumList[c - 7] != TamaNull && TamaNumList[c - 14] != TamaNull && TamaNumList[c - 21] != TamaNull && TamaNumList[c - 28] != TamaNull && TamaNumList[c - 35] != TamaNull && TamaNumList[c - 42] != TamaNull && TamaNumList[d - 7] != TamaNull && TamaNumList[d - 14] != TamaNull && TamaNumList[d - 21] != TamaNull && TamaNumList[d - 28] != TamaNull && TamaNumList[d - 35] != TamaNull && TamaNumList[d - 42] != TamaNull)
                    {
                        if (TamaNumList[a] == TamaNumList[e] && TamaNumList[e] < 49 && TamaNumList[e - 7] != TamaNull && TamaNumList[e - 14] != TamaNull && TamaNumList[e - 21] != TamaNull && TamaNumList[e - 28] != TamaNull && TamaNumList[e - 35] != TamaNull && TamaNumList[e - 42] != TamaNull)
                        {
                            if (TamaNumList[a] == TamaNumList[f] && TamaNumList[f] < 49 && TamaNumList[f - 7] != TamaNull && TamaNumList[f - 14] != TamaNull && TamaNumList[f - 21] != TamaNull && TamaNumList[f - 28] != TamaNull && TamaNumList[f - 35] != TamaNull && TamaNumList[f - 42] != TamaNull)
                            {
                                if (TamaNumList[a] == TamaNumList[g] && TamaNumList[g] < 49 && TamaNumList[g - 7] != TamaNull && TamaNumList[g - 14] != TamaNull && TamaNumList[g - 21] != TamaNull && TamaNumList[g - 28] != TamaNull && TamaNumList[g - 35] != TamaNull && TamaNumList[g - 42] != TamaNull)
                                {
                                    //7個消す
                                    Destroy(TamaSpawnedList[a]);
                                    Destroy(TamaSpawnedList[a + 1]);
                                    Destroy(TamaSpawnedList[a + 2]);
                                    Destroy(TamaSpawnedList[a + 3]);
                                    Destroy(TamaSpawnedList[a + 4]);
                                    Destroy(TamaSpawnedList[a + 5]);
                                    Destroy(TamaSpawnedList[a + 6]);
                                    TamaNumList[a] = TamaNull;
                                    TamaNumList[a + 1] = TamaNull;
                                    TamaNumList[a + 2] = TamaNull;
                                    TamaNumList[a + 3] = TamaNull;
                                    TamaNumList[a + 4] = TamaNull;
                                    TamaNumList[a + 5] = TamaNull;
                                    TamaNumList[a + 6] = TamaNull;
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
                                    TamaNumList[a] = TamaNull;
                                    TamaNumList[a + 1] = TamaNull;
                                    TamaNumList[a + 2] = TamaNull;
                                    TamaNumList[a + 3] = TamaNull;
                                    TamaNumList[a + 4] = TamaNull;
                                    TamaNumList[a + 5] = TamaNull;
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
                                TamaNumList[a] = TamaNull;
                                TamaNumList[a + 1] = TamaNull;
                                TamaNumList[a + 2] = TamaNull;
                                TamaNumList[a + 3] = TamaNull;
                                TamaNumList[a + 4] = TamaNull;
                            }
                        }
                        else
                        {
                            //4個消す
                            Destroy(TamaSpawnedList[a]);
                            Destroy(TamaSpawnedList[a + 1]);
                            Destroy(TamaSpawnedList[a + 2]);
                            Destroy(TamaSpawnedList[a + 3]);
                            TamaNumList[a] = TamaNull;
                            TamaNumList[a + 1] = TamaNull;
                            TamaNumList[a + 2] = TamaNull;
                            TamaNumList[a + 3] = TamaNull;
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
                if (TamaNumList[a] != TamaNull && TamaNumList[a] == TamaNumList[b] && TamaNumList[a] == TamaNumList[c] && TamaNumList[a] == TamaNumList[d])
                {
                    //条件(49)
                    if (TamaNumList[a - 7] != TamaNull && TamaNumList[a - 14] != TamaNull && TamaNumList[a - 21] != TamaNull && TamaNumList[a - 28] != TamaNull && TamaNumList[a - 35] != TamaNull && TamaNumList[a - 42] != TamaNull && TamaNumList[a - 49] != TamaNull && TamaNumList[b - 7] != TamaNull && TamaNumList[b - 14] != TamaNull && TamaNumList[b - 21] != TamaNull && TamaNumList[b - 28] != TamaNull && TamaNumList[b - 35] != TamaNull && TamaNumList[b - 42] != TamaNull && TamaNumList[b - 49] != TamaNull && TamaNumList[c - 7] != TamaNull && TamaNumList[c - 14] != TamaNull && TamaNumList[c - 21] != TamaNull && TamaNumList[c - 28] != TamaNull && TamaNumList[c - 35] != TamaNull && TamaNumList[c - 42] != TamaNull && TamaNumList[c - 49] != TamaNull && TamaNumList[d - 7] != TamaNull && TamaNumList[d - 14] != TamaNull && TamaNumList[d - 21] != TamaNull && TamaNumList[d - 28] != TamaNull && TamaNumList[d - 35] != TamaNull && TamaNumList[d - 42] != TamaNull && TamaNumList[d - 49] != TamaNull)
                    {
                        if (TamaNumList[a] == TamaNumList[e] && TamaNumList[e] < 56 && TamaNumList[e - 7] != TamaNull && TamaNumList[e - 14] != TamaNull && TamaNumList[e - 21] != TamaNull && TamaNumList[e - 28] != TamaNull && TamaNumList[e - 35] != TamaNull && TamaNumList[e - 42] != TamaNull && TamaNumList[e - 49] != TamaNull)
                        {
                            if (TamaNumList[a] == TamaNumList[f] && TamaNumList[f] < 56 && TamaNumList[f - 7] != TamaNull && TamaNumList[f - 14] != TamaNull && TamaNumList[f - 21] != TamaNull && TamaNumList[f - 28] != TamaNull && TamaNumList[f - 35] != TamaNull && TamaNumList[f - 42] != TamaNull && TamaNumList[f - 49] != TamaNull)
                            {
                                if (TamaNumList[a] == TamaNumList[g] && TamaNumList[g] < 56 && TamaNumList[g - 7] != TamaNull && TamaNumList[g - 14] != TamaNull && TamaNumList[g - 21] != TamaNull && TamaNumList[g - 28] != TamaNull && TamaNumList[g - 35] != TamaNull && TamaNumList[g - 42] != TamaNull && TamaNumList[g - 49] != TamaNull)
                                {
                                    //7個消す
                                    Destroy(TamaSpawnedList[a]);
                                    Destroy(TamaSpawnedList[a + 1]);
                                    Destroy(TamaSpawnedList[a + 2]);
                                    Destroy(TamaSpawnedList[a + 3]);
                                    Destroy(TamaSpawnedList[a + 4]);
                                    Destroy(TamaSpawnedList[a + 5]);
                                    Destroy(TamaSpawnedList[a + 6]);
                                    TamaNumList[a] = TamaNull;
                                    TamaNumList[a + 1] = TamaNull;
                                    TamaNumList[a + 2] = TamaNull;
                                    TamaNumList[a + 3] = TamaNull;
                                    TamaNumList[a + 4] = TamaNull;
                                    TamaNumList[a + 5] = TamaNull;
                                    TamaNumList[a + 6] = TamaNull;
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
                                    TamaNumList[a] = TamaNull;
                                    TamaNumList[a + 1] = TamaNull;
                                    TamaNumList[a + 2] = TamaNull;
                                    TamaNumList[a + 3] = TamaNull;
                                    TamaNumList[a + 4] = TamaNull;
                                    TamaNumList[a + 5] = TamaNull;
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
                                TamaNumList[a] = TamaNull;
                                TamaNumList[a + 1] = TamaNull;
                                TamaNumList[a + 2] = TamaNull;
                                TamaNumList[a + 3] = TamaNull;
                                TamaNumList[a + 4] = TamaNull;
                            }
                        }
                        else
                        {
                            //4個消す
                            Destroy(TamaSpawnedList[a]);
                            Destroy(TamaSpawnedList[a + 1]);
                            Destroy(TamaSpawnedList[a + 2]);
                            Destroy(TamaSpawnedList[a + 3]);
                            TamaNumList[a] = TamaNull;
                            TamaNumList[a + 1] = TamaNull;
                            TamaNumList[a + 2] = TamaNull;
                            TamaNumList[a + 3] = TamaNull;
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
                if (TamaNumList[a] != TamaNull && TamaNumList[a] == TamaNumList[b] && TamaNumList[a] == TamaNumList[c] && TamaNumList[a] == TamaNumList[d])
                {
                    //条件(56)
                    if (TamaNumList[a - 7] != TamaNull && TamaNumList[a - 14] != TamaNull && TamaNumList[a - 21] != TamaNull && TamaNumList[a - 28] != TamaNull && TamaNumList[a - 35] != TamaNull && TamaNumList[a - 42] != TamaNull && TamaNumList[a - 49] != TamaNull && TamaNumList[a - 56] != TamaNull && TamaNumList[b - 7] != TamaNull && TamaNumList[b - 14] != TamaNull && TamaNumList[b - 21] != TamaNull && TamaNumList[b - 28] != TamaNull && TamaNumList[b - 35] != TamaNull && TamaNumList[b - 42] != TamaNull && TamaNumList[b - 49] != TamaNull && TamaNumList[b - 56] != TamaNull && TamaNumList[c - 7] != TamaNull && TamaNumList[c - 14] != TamaNull && TamaNumList[c - 21] != TamaNull && TamaNumList[c - 28] != TamaNull && TamaNumList[c - 35] != TamaNull && TamaNumList[c - 42] != TamaNull && TamaNumList[c - 49] != TamaNull && TamaNumList[c - 56] != TamaNull && TamaNumList[d - 7] != TamaNull && TamaNumList[d - 14] != TamaNull && TamaNumList[d - 21] != TamaNull && TamaNumList[d - 28] != TamaNull && TamaNumList[d - 35] != TamaNull && TamaNumList[d - 42] != TamaNull && TamaNumList[d - 49] != TamaNull && TamaNumList[d - 56] != TamaNull)
                    {
                        if (TamaNumList[a] == TamaNumList[e] && TamaNumList[e] < 63 && TamaNumList[e - 7] != TamaNull && TamaNumList[e - 14] != TamaNull && TamaNumList[e - 21] != TamaNull && TamaNumList[e - 28] != TamaNull && TamaNumList[e - 35] != TamaNull && TamaNumList[e - 42] != TamaNull && TamaNumList[e - 49] != TamaNull && TamaNumList[e - 56] != TamaNull)
                        {
                            if (TamaNumList[a] == TamaNumList[f] && TamaNumList[f] < 63 && TamaNumList[f - 7] != TamaNull && TamaNumList[f - 14] != TamaNull && TamaNumList[f - 21] != TamaNull && TamaNumList[f - 28] != TamaNull && TamaNumList[f - 35] != TamaNull && TamaNumList[f - 42] != TamaNull && TamaNumList[f - 49] != TamaNull && TamaNumList[f - 56] != TamaNull)
                            {
                                if (TamaNumList[a] == TamaNumList[g] && TamaNumList[g] < 63 && TamaNumList[g - 7] != TamaNull && TamaNumList[g - 14] != TamaNull && TamaNumList[g - 21] != TamaNull && TamaNumList[g - 28] != TamaNull && TamaNumList[g - 35] != TamaNull && TamaNumList[g - 42] != TamaNull && TamaNumList[g - 49] != TamaNull && TamaNumList[g - 56] != TamaNull)
                                {
                                    //7個消す
                                    Destroy(TamaSpawnedList[a]);
                                    Destroy(TamaSpawnedList[a + 1]);
                                    Destroy(TamaSpawnedList[a + 2]);
                                    Destroy(TamaSpawnedList[a + 3]);
                                    Destroy(TamaSpawnedList[a + 4]);
                                    Destroy(TamaSpawnedList[a + 5]);
                                    Destroy(TamaSpawnedList[a + 6]);
                                    TamaNumList[a] = TamaNull;
                                    TamaNumList[a + 1] = TamaNull;
                                    TamaNumList[a + 2] = TamaNull;
                                    TamaNumList[a + 3] = TamaNull;
                                    TamaNumList[a + 4] = TamaNull;
                                    TamaNumList[a + 5] = TamaNull;
                                    TamaNumList[a + 6] = TamaNull;
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
                                    TamaNumList[a] = TamaNull;
                                    TamaNumList[a + 1] = TamaNull;
                                    TamaNumList[a + 2] = TamaNull;
                                    TamaNumList[a + 3] = TamaNull;
                                    TamaNumList[a + 4] = TamaNull;
                                    TamaNumList[a + 5] = TamaNull;
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
                                TamaNumList[a] = TamaNull;
                                TamaNumList[a + 1] = TamaNull;
                                TamaNumList[a + 2] = TamaNull;
                                TamaNumList[a + 3] = TamaNull;
                                TamaNumList[a + 4] = TamaNull;
                            }
                        }
                        else
                        {
                            //4個消す
                            Destroy(TamaSpawnedList[a]);
                            Destroy(TamaSpawnedList[a + 1]);
                            Destroy(TamaSpawnedList[a + 2]);
                            Destroy(TamaSpawnedList[a + 3]);
                            TamaNumList[a] = TamaNull;
                            TamaNumList[a + 1] = TamaNull;
                            TamaNumList[a + 2] = TamaNull;
                            TamaNumList[a + 3] = TamaNull;
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

                //TamaNull列
                if (TamaNumList[a] != TamaNull && TamaNumList[a] == TamaNumList[b] && TamaNumList[a] == TamaNumList[c] && TamaNumList[a] == TamaNumList[d])
                {
                    //条件(63)
                    if (TamaNumList[a - 7] != TamaNull && TamaNumList[a - 14] != TamaNull && TamaNumList[a - 21] != TamaNull && TamaNumList[a - 28] != TamaNull && TamaNumList[a - 35] != TamaNull && TamaNumList[a - 42] != TamaNull && TamaNumList[a - 49] != TamaNull && TamaNumList[a - 56] != TamaNull && TamaNumList[a - 63] != TamaNull && TamaNumList[b - 7] != TamaNull && TamaNumList[b - 14] != TamaNull && TamaNumList[b - 21] != TamaNull && TamaNumList[b - 28] != TamaNull && TamaNumList[b - 35] != TamaNull && TamaNumList[b - 42] != TamaNull && TamaNumList[b - 49] != TamaNull && TamaNumList[b - 56] != TamaNull && TamaNumList[b - 63] != TamaNull && TamaNumList[c - 7] != TamaNull && TamaNumList[c - 14] != TamaNull && TamaNumList[c - 21] != TamaNull && TamaNumList[c - 28] != TamaNull && TamaNumList[c - 35] != TamaNull && TamaNumList[c - 42] != TamaNull && TamaNumList[c - 49] != TamaNull && TamaNumList[c - 56] != TamaNull && TamaNumList[c - 63] != TamaNull && TamaNumList[d - 7] != TamaNull && TamaNumList[d - 14] != TamaNull && TamaNumList[d - 21] != TamaNull && TamaNumList[d - 28] != TamaNull && TamaNumList[d - 35] != TamaNull && TamaNumList[d - 42] != TamaNull && TamaNumList[d - 49] != TamaNull && TamaNumList[d - 56] != TamaNull && TamaNumList[d - 63] != TamaNull)
                    {
                        if (TamaNumList[a] == TamaNumList[e] && TamaNumList[e] < 70 && TamaNumList[e - 7] != TamaNull && TamaNumList[e - 14] != TamaNull && TamaNumList[e - 21] != TamaNull && TamaNumList[e - 28] != TamaNull && TamaNumList[e - 35] != TamaNull && TamaNumList[e - 42] != TamaNull && TamaNumList[e - 49] != TamaNull && TamaNumList[e - 56] != TamaNull && TamaNumList[e - 63] != TamaNull)
                        {
                            if (TamaNumList[a] == TamaNumList[f] && TamaNumList[f] < 70 && TamaNumList[f - 7] != TamaNull && TamaNumList[f - 14] != TamaNull && TamaNumList[f - 21] != TamaNull && TamaNumList[f - 28] != TamaNull && TamaNumList[f - 35] != TamaNull && TamaNumList[f - 42] != TamaNull && TamaNumList[f - 49] != TamaNull && TamaNumList[f - 56] != TamaNull && TamaNumList[f - 63] != TamaNull)
                            {
                                if (TamaNumList[a] == TamaNumList[g] && TamaNumList[g] < 70 && TamaNumList[g - 7] != TamaNull && TamaNumList[g - 14] != TamaNull && TamaNumList[g - 21] != TamaNull && TamaNumList[g - 28] != TamaNull && TamaNumList[g - 35] != TamaNull && TamaNumList[g - 42] != TamaNull && TamaNumList[g - 49] != TamaNull && TamaNumList[g - 56] != TamaNull && TamaNumList[g - 63] != TamaNull)
                                {
                                    //7個消す
                                    Destroy(TamaSpawnedList[a]);
                                    Destroy(TamaSpawnedList[a + 1]);
                                    Destroy(TamaSpawnedList[a + 2]);
                                    Destroy(TamaSpawnedList[a + 3]);
                                    Destroy(TamaSpawnedList[a + 4]);
                                    Destroy(TamaSpawnedList[a + 5]);
                                    Destroy(TamaSpawnedList[a + 6]);
                                    TamaNumList[a] = TamaNull;
                                    TamaNumList[a + 1] = TamaNull;
                                    TamaNumList[a + 2] = TamaNull;
                                    TamaNumList[a + 3] = TamaNull;
                                    TamaNumList[a + 4] = TamaNull;
                                    TamaNumList[a + 5] = TamaNull;
                                    TamaNumList[a + 6] = TamaNull;
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
                                    TamaNumList[a] = TamaNull;
                                    TamaNumList[a + 1] = TamaNull;
                                    TamaNumList[a + 2] = TamaNull;
                                    TamaNumList[a + 3] = TamaNull;
                                    TamaNumList[a + 4] = TamaNull;
                                    TamaNumList[a + 5] = TamaNull;
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
                                TamaNumList[a] = TamaNull;
                                TamaNumList[a + 1] = TamaNull;
                                TamaNumList[a + 2] = TamaNull;
                                TamaNumList[a + 3] = TamaNull;
                                TamaNumList[a + 4] = TamaNull;
                            }
                        }
                        else
                        {
                            //4個消す
                            Destroy(TamaSpawnedList[a]);
                            Destroy(TamaSpawnedList[a + 1]);
                            Destroy(TamaSpawnedList[a + 2]);
                            Destroy(TamaSpawnedList[a + 3]);
                            TamaNumList[a] = TamaNull;
                            TamaNumList[a + 1] = TamaNull;
                            TamaNumList[a + 2] = TamaNull;
                            TamaNumList[a + 3] = TamaNull;
                        }
                    }
                    else
                    {
                        //Nothing
                    }

                }
            }
            */
        }
    }

    /// <summary>
    /// Check Tama Clear Vertical
    /// </summary>
    void CheckTamaClearVertical()
    {
        // 縦方向につながっている玉がないか確認する
        // Light Bottom to Right Top.
        for (int i = 0; i < ColumnCount * 7; i++)
        {
            var checkTama = TamaNumList[i];
            // 4つ以上つながっている場合
            if (checkTama != TamaNull && checkTama == TamaNumList[i + 7] &&
                checkTama == TamaNumList[i + 14] && checkTama == TamaNumList[i + 21])
            {
                // 更につながっている
                // TODO : 後ほど改修する
                if (checkTama == TamaNumList[i + 28] && TamaNumList[i + 28] < 70)
                {
                    continue;
                }

                //4個消す
                for (var v = 0; v < 4; v++)
                {
                    var removeIndex = i + v * ColumnCount;
                    Destroy(TamaSpawnedList[removeIndex]);
                    TamaNumList[removeIndex] = TamaNull;
                }
            }
        }
    }
}
