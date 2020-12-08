using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MagicDrop;
using UniRx;
using System;

public class GameLogic : MonoBehaviour
{
    public const int ColumnCount = 7;
    public const int RowCount = 12;
    public const int TamaNull = 10;
    public const int TamaMinChainCount = 4;
    private const int DropLineFirst = 63;

    //Tama
    public float tamaSpeed;
    int carryNum;
    int selectNum;
    int receiveDropNum;
    bool checkCarry;      //true=carry   , false=not carry
    bool checkSelectTamaDelete;         //true=Delete   , false=not Delete

    //Skill
    bool checkSkillBat;   //true=can     , false=can't
    public GameObject objTamaSelectBox;
    [SerializeField] private GameObject _batTama;
    [SerializeField] private GameUIManager _uiManager;
    bool checkTurtleSkill;  //true=slow   , false=normal

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
    public List<List<int>> ClearDropList = new List<List<int>>();
    //List

    private PlayerLogic _playerLogic;

    void Awake()
    {
        ResetAll();

        _playerLogic = GameObject.Find("Player").GetComponent<PlayerLogic>();
    }

    void Start()
    {
        Invoke("Initialize", 0.1f);
    }

    void Initialize()
    {
        TamaStart();
        NextTamaStart();
        StartCoroutine(UpdateDrops());
    }

    void Update()
    {
        if (checkSkillBat == true)
        {
            //Active Bat Skill
            if (Input.GetMouseButtonDown(0))
            {
                SkillBat();
            }
        }
        else
        {
            //Don't Active Bat Skill
        }

        TurtlrSkill();
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

        //Skill
        checkSkillBat = false;
        _batTama = null;
        objTamaSelectBox.gameObject.SetActive(true);
        checkTurtleSkill = false;
    }

    //ゲームが始まるとき、下端部の3つの列に生じる玉      (void Start)
    void TamaStart()
    {
        for (int i = 0; i < 21; i++)
        {
            int z = (UnityEngine.Random.Range(0, 4));

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
            int z = (UnityEngine.Random.Range(0, 4));

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
            var z = UnityEngine.Random.Range(0, 4);

            Transform targetPoint = NextTamaTransformList[i];
            GameObject newTama = Instantiate(TamaKindList[z]);
            newTama.transform.position = targetPoint.position;
            NextTamaList[i] = newTama;
            NextTamaNumList[i] = z;
        }
    }

    private void BtnOnPointer(int index)
    {
        if (TamaNumList[index] != TamaNull)
        {
            carryNum = TamaNumList[index];
            selectNum = index;
            checkCarry = true;

            //OnMouseDrag
            OnMouseDrag();
        }
        else
        {

        }
    }

    //TamaSelectButton (OnpointerDown)
    public void BtnOnpointer_0()
    {
        BtnOnPointer(0);
    }

    public void BtnOnpointer_1()
    {
        BtnOnPointer(1);
    }

    public void BtnOnpointer_2()
    {
        BtnOnPointer(2);
    }

    public void BtnOnpointer_3()
    {
        BtnOnPointer(3);
    }

    public void BtnOnpointer_4()
    {
        BtnOnPointer(4);
    }

    public void BtnOnpointer_5()
    {
        BtnOnPointer(5);
    }

    public void BtnOnpointer_6()
    {
        BtnOnPointer(6);
    }

    //Drag
    public void OnMouseDrag()
    {
        if (checkCarry == true)
        {
            var vecX = -2.4f + (selectNum * 0.8f);
            var carryTama = Instantiate(TamaSelectKindList[carryNum], new Vector3(vecX, -2.9f, 0), Quaternion.identity);
            TamaCarryList.Add(carryTama);
        }
        else
        {

        }
    }

    //下端部の選んだ玉を消す
    public void SelectTamaDelete()
    {
        if (checkSelectTamaDelete == true)
        {
            Destroy(TamaSpawnedList[selectNum]);
            TamaNumList[selectNum] = TamaNull;
            checkSelectTamaDelete = false;
        }
        else
        {
            //Don't Delete
        }
    }

    //TamaDrop
    public void TamaDrop()
    {
        if (checkCarry == true)
        {
            if (_playerLogic.dropNum < ColumnCount)
            {
                for (var v = 0; v < 2; v++)
                {
                    var receiveDropNum = (DropLineFirst + v * ColumnCount) + _playerLogic.dropNum;
                    if (TamaNumList[receiveDropNum] == TamaNull)
                    {
                        var targetPoint = TamaTransformList[receiveDropNum];
                        var newTama = Instantiate(TamaKindList[carryNum]);
                        newTama.transform.position = targetPoint.position;
                        TamaSpawnedList[receiveDropNum] = newTama;
                        TamaNumList[receiveDropNum] = carryNum;
                        break;
                    }
                }
            }

            _playerLogic.DragOff();
            _playerLogic.ResetAll();
            for (var i = 0; i < TamaCarryList.Count; i++)
            {
                Destroy(TamaCarryList[i]);
            }
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
    IEnumerator UpdateDrops()
    {
        yield return TamaMove();

        if (GameSettings.ClearMode == DropClearMode.Line)
        {
            CheckTamaClearHorizontal();
            CheckTamaClearVertical();

            ClearDrops();
        }
        else if (GameSettings.ClearMode == DropClearMode.Chain)
        {
            if (CheckClearDrops())
                ClearDrops();

        }

        // UpdateDrops Loops
        StartCoroutine(UpdateDrops());
    }

    //Move (Tama Fall.)
    IEnumerator TamaMove()
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
    /// 玉を削除
    /// </summary>
    void ClearDrops()
    {
        for (int i = 0; i < ClearDropList.Count; i++)
        {
            var drops = ClearDropList[i];
            foreach (var dropIndex in drops)
            {
                var tama = TamaSpawnedList[dropIndex];
                tama.GetComponent<TamaLogic>().Splash(() =>
                {
                    TamaNumList[dropIndex] = TamaNull;
                });
            }
            drops.Clear();
        }
        ClearDropList.Clear();
    }

    /// <summary>
    /// Drop Clear Logic
    /// </summary>
    /// <returns></returns>
    private bool CheckClearDrops()
    {
        // 列ごとに確認
        for (var h = 0; h < ColumnCount; h++)
        {
            // 上からチェックする
            // 上から落下させるため、各列の１番上が消えるため
            for (var v = RowCount - 1; 0 < v; v--)
            {
                var dropIndex = v * ColumnCount + h;
                var dropTarget = TamaNumList[dropIndex];
                if (dropTarget != TamaNull)
                {
                    // 消されるドロップリストにない
                    if (ClearDropList.Find(list => list.Contains(dropIndex)) == null)
                    {
                        var checkCell = new List<List<int>>(ColumnCount);
                        for (var i = 0; i < ColumnCount; i++)
                        {
                            var checkRow = new List<int>(v);
                            for (var j = 0; j <= v; j++)
                            {
                                var index = i * ColumnCount + j;
                                checkRow.Add(TamaNumList[index] == TamaNull ? TamaNull : -1); //チェックしない : 未チェック
                            }
                            checkCell.Add(checkRow);
                        }
                        CheckDropRecursive(h, v, dropTarget, checkCell);

                        if (TamaMinChainCount <= checkCell.Sum(x => x.Count<int>(y => y == 1)))
                        {
                            var debugLog = "AnyChained" + $"{(dropTarget)}";
                            Debug.Log(debugLog);

                            var chainedList = new List<int>();

                            for (var i = 0; i < checkCell.Count; i++)
                            {
                                for (var j = 0; j < checkCell[i].Count; j++)
                                {
                                    if (checkCell[i][j] == 1)
                                    {
                                        chainedList.Add(j * ColumnCount + i);
                                    }
                                }
                            }
                            ClearDropList.Add(chainedList);
                        }
                    }

                    // var chainedList = CheckChainDropList(dropIndex, dropTarget, checkCell);
                    // if (chainedList != null)
                    // {
                    //     
                    // }
                }
            }
        }
        return 0 < ClearDropList.Count;
    }

    private void CheckDropRecursive(int x, int y, int dropTratget, List<List<int>> checkCell)
    {
        if (checkCell.Count <= x || checkCell[x].Count <= y || 0 < checkCell[x][y]) return; //範囲外か探索済み

        var index = y * ColumnCount + x;
        if (TamaNumList[index] != dropTratget)
        {
            //ブロックの種類が違う
            checkCell[x][y] = 2;
            return;
        }
        //一致
        checkCell[x][y] = 1; //チェック

        if (x < checkCell.Count - 1)
            CheckDropRecursive(x + 1, y, dropTratget, checkCell); //右探索
        if (0 < x)
            CheckDropRecursive(x - 1, y, dropTratget, checkCell); //左
        if (y < checkCell[x].Count - 1)
            CheckDropRecursive(x, y + 1, dropTratget, checkCell); //下
        if (0 < y)
            CheckDropRecursive(x, y - 1, dropTratget, checkCell); //上
        return;
    }

    /// <summary>
    /// Check Tama Clear.
    /// </summary>
    void CheckTamaClearHorizontal()
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

                for (var ch = targetIndex + 1; ch < limitCount; ch++)
                {
                    var isChained = targetTama != TamaNull && targetTama == TamaNumList[ch];
                    if (targetIndex < ColumnCount)
                    {
                        // 連結しているならカウントアップ
                        if (isChained)
                        {
                            chainCount++;
                            chainStrings += $" | [{ch}]";
                        }
                        else
                            break;
                    }
                    else
                    {
                        // 連結しているならカウントアップ
                        if (isChained && TamaNumList[ch - ColumnCount] != TamaNull)
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
                    ClearDropList.Add(new List<int>());
                    var lastList = ClearDropList.Last();
                    for (var ch = targetIndex; ch < targetIndex + chainCount; ch++)
                    {
                        lastList.Add(ch);
                    }
                    break;
                }
            }
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
                ClearDropList.Add(new List<int>());
                var lastList = ClearDropList.Last();
                for (var v = 0; v < 4; v++)
                {
                    var removeIndex = i + v * ColumnCount;
                    lastList.Add(removeIndex);
                }
            }
        }
    }

    //Skill
    //Skill_bat
    void SkillBat()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            _batTama = hit.collider.gameObject;
            int i = GetGameObjectIndex(_batTama, TamaSpawnedList);

            //Destroy & Effect
            _batTama.GetComponent<TamaLogic>().Splash(() =>
            {
                TamaNumList[i] = TamaNull;
            });

            //Reset
            checkSkillBat = false;
            objTamaSelectBox.gameObject.SetActive(true);
            _uiManager.SkillBatOff();
        }
    }

    int GetGameObjectIndex(GameObject _batTama, List<GameObject> TamaSpawnedList)
    {
        if (TamaSpawnedList == null)
            return -1;

        if (TamaSpawnedList.Count <= 0)
            return -1;

        for (int i = 0; i < TamaSpawnedList.Count; i++)
        {
            if (TamaSpawnedList[i] == _batTama)
            {
                return i;
            }
        }

        return -1;
    }

    public void BtnSkillBat()
    {
        _batTama = null;
        checkSkillBat = true;
        objTamaSelectBox.gameObject.SetActive(false);
        Debug.Log("Skill : Bat");
    }

    //Skill BottomDelete
    public void BtnSkillBottomDelete()
    {
        for (int i = 0; i < 7; i++)
        {
            if (TamaNumList[i] == TamaNull)
            {

            }
            else if (TamaNumList[i] != TamaNull)
            {
                //7個消す
                Destroy(TamaSpawnedList[i]);
                TamaNumList[i] = TamaNull;
            }
        }
        Debug.Log("Skill : BottomDelete");
    }

    //Skill Rocket
    public void BtnSkillRocket()
    {
        int listNum = 0;

        for (int i = 0; i < 84; i++)
        {
            if (TamaNumList[i] != TamaNull)
            {
                listNum++;
            }
            else
            {
                //Nothing
            }
        }


        //残っている玉が5個以上
        if (listNum >= 5)
        {
            int a = -1;
            int b = -1;
            int c = -1;
            int d = -1;
            int e = -1;

            while (true)
            {
                if (a == -1)
                {
                    int i = UnityEngine.Random.Range(0, 84);

                    if (TamaNumList[i] == TamaNull)
                    {
                        //OneMore
                    }
                    else if (TamaNumList[i] != TamaNull)
                    {
                        a = i;
                        Debug.Log("a : " + a);
                    }
                }
                else if (a != -1 && b == -1)
                {
                    int i = UnityEngine.Random.Range(0, 84);

                    if (TamaNumList[i] == TamaNull || i == a)
                    {
                        //OneMore
                    }
                    else if (TamaNumList[i] != TamaNull && i != a)
                    {
                        b = i;
                        Debug.Log("b : " + b);
                    }
                }
                else if (a != -1 && b != -1 && c == -1)
                {
                    int i = UnityEngine.Random.Range(0, 84);

                    if (TamaNumList[i] == TamaNull || i == a || i == b)
                    {
                        //OneMore
                    }
                    else if (TamaNumList[i] != TamaNull && i != a && i != b)
                    {
                        c = i;
                        Debug.Log("c : " + c);
                    }
                }
                else if (a != -1 && b != -1 && c != -1 && d == -1)
                {
                    int i = UnityEngine.Random.Range(0, 84);

                    if (TamaNumList[i] == TamaNull || i == a || i == b || i == c)
                    {
                        //OneMore
                    }
                    else if (TamaNumList[i] != TamaNull && i != a && i != b && i != c)
                    {
                        d = i;
                        Debug.Log("d : " + d);
                    }
                }
                else if (a != -1 && b != -1 && c != -1 && d != -1 && e == -1)
                {
                    int i = UnityEngine.Random.Range(0, 84);

                    if (TamaNumList[i] == TamaNull || i == a || i == b || i == c || i == d)
                    {
                        //OneMore
                    }
                    else if (TamaNumList[i] != TamaNull && i != a && i != b && i != c && i != d)
                    {
                        e = i;
                        Debug.Log("e : " + e);
                    }
                }
                else if (a != -1 && b != -1 && c != -1 && d != -1 && e != -1)
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
        //残っている玉が5個以下
        else if (listNum < 5)
        {
            //残り全部消す
            for (int i = 0; i < 84; i++)
            {
                if (TamaNumList[i] != TamaNull)
                {
                    Destroy(TamaSpawnedList[i]);
                    TamaNumList[i] = TamaNull;
                }
                else
                {
                    //Nothing
                }
            }
        }



    }

    //Skill Turtle
    public void BtnSkillTurtle()
    {
        if (checkTurtleSkill == true)
        {
            checkTurtleSkill = false;
        }
        else if (checkTurtleSkill == false)
        {
            checkTurtleSkill = true;
        }

        Debug.Log("Skill : Turtle");
    }

    void TurtlrSkill()                 //void update
    {
        if (checkTurtleSkill == true)
        {
            tamaSpeed = 0.6f;
        }
        else if (checkTurtleSkill == false)
        {
            tamaSpeed = 0.4f;
        }
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
