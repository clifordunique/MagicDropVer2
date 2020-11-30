using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverLogic : MonoBehaviour
{
    private const string TargetTag = "Tama";
    private const int ColumnCount = 7;
    private const int RowCount = 10;

    [SerializeField] private GameLogic _gameLogic;
    [SerializeField] private GameUIManager _uiManager;

    // Start is called before the first frame update
    private void Start()
    {
        if (_gameLogic == null)
        {
            _gameLogic = FindObjectOfType<GameLogic>();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    //GameOver Check
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(TargetTag))
        {
            StartCoroutine(GameOverCheck());
        }
    }

    //GameOver
    void GameOver()
    {
        _uiManager.PopupGameOverOpen();
    }

    //GameOver Check Coroutine
    IEnumerator GameOverCheck()
    {
        yield return new WaitForSeconds(0.5f);

        int a = 0;
        int b = 1;
        int c = 2;
        int d = 3;
        int e = 4;
        int f = 5;
        int g = 6;

        if (_gameLogic.TamaNumList[a] != 10 && _gameLogic.TamaNumList[a + 7] != 10 && _gameLogic.TamaNumList[a + 14] != 10 && _gameLogic.TamaNumList[a + 21] != 10 && _gameLogic.TamaNumList[a + 28] != 10 && _gameLogic.TamaNumList[a + 35] != 10 && _gameLogic.TamaNumList[a + 42] != 10 && _gameLogic.TamaNumList[a + 49] != 10 && _gameLogic.TamaNumList[a + 56] != 10 && _gameLogic.TamaNumList[a + 63] != 10 && _gameLogic.TamaNumList[a + 70] != 10)
        {
            GameOver();
        }
        else if (_gameLogic.TamaNumList[b] != 10 && _gameLogic.TamaNumList[b + 7] != 10 && _gameLogic.TamaNumList[b + 14] != 10 && _gameLogic.TamaNumList[b + 21] != 10 && _gameLogic.TamaNumList[b + 28] != 10 && _gameLogic.TamaNumList[b + 35] != 10 && _gameLogic.TamaNumList[b + 42] != 10 && _gameLogic.TamaNumList[b + 49] != 10 && _gameLogic.TamaNumList[b + 56] != 10 && _gameLogic.TamaNumList[b + 63] != 10 && _gameLogic.TamaNumList[b + 70] != 10)
        {
            GameOver();
        }
        else if (_gameLogic.TamaNumList[c] != 10 && _gameLogic.TamaNumList[c + 7] != 10 && _gameLogic.TamaNumList[c + 14] != 10 && _gameLogic.TamaNumList[c + 21] != 10 && _gameLogic.TamaNumList[c + 28] != 10 && _gameLogic.TamaNumList[c + 35] != 10 && _gameLogic.TamaNumList[c + 42] != 10 && _gameLogic.TamaNumList[c + 49] != 10 && _gameLogic.TamaNumList[c + 56] != 10 && _gameLogic.TamaNumList[c + 63] != 10 && _gameLogic.TamaNumList[c + 70] != 10)
        {
            GameOver();
        }
        else if (_gameLogic.TamaNumList[d] != 10 && _gameLogic.TamaNumList[d + 7] != 10 && _gameLogic.TamaNumList[d + 14] != 10 && _gameLogic.TamaNumList[d + 21] != 10 && _gameLogic.TamaNumList[d + 28] != 10 && _gameLogic.TamaNumList[d + 35] != 10 && _gameLogic.TamaNumList[d + 42] != 10 && _gameLogic.TamaNumList[d + 49] != 10 && _gameLogic.TamaNumList[d + 56] != 10 && _gameLogic.TamaNumList[d + 63] != 10 && _gameLogic.TamaNumList[d + 70] != 10)
        {
            GameOver();
        }
        else if (_gameLogic.TamaNumList[e] != 10 && _gameLogic.TamaNumList[e + 7] != 10 && _gameLogic.TamaNumList[e + 14] != 10 && _gameLogic.TamaNumList[e + 21] != 10 && _gameLogic.TamaNumList[e + 28] != 10 && _gameLogic.TamaNumList[e + 35] != 10 && _gameLogic.TamaNumList[e + 42] != 10 && _gameLogic.TamaNumList[e + 49] != 10 && _gameLogic.TamaNumList[e + 56] != 10 && _gameLogic.TamaNumList[e + 63] != 10 && _gameLogic.TamaNumList[e + 70] != 10)
        {
            GameOver();
        }
        else if (_gameLogic.TamaNumList[f] != 10 && _gameLogic.TamaNumList[f + 7] != 10 && _gameLogic.TamaNumList[f + 14] != 10 && _gameLogic.TamaNumList[f + 21] != 10 && _gameLogic.TamaNumList[f + 28] != 10 && _gameLogic.TamaNumList[f + 35] != 10 && _gameLogic.TamaNumList[f + 42] != 10 && _gameLogic.TamaNumList[f + 49] != 10 && _gameLogic.TamaNumList[f + 56] != 10 && _gameLogic.TamaNumList[f + 63] != 10 && _gameLogic.TamaNumList[f + 70] != 10)
        {
            GameOver();
        }
        else if (_gameLogic.TamaNumList[g] != 10 && _gameLogic.TamaNumList[g + 7] != 10 && _gameLogic.TamaNumList[g + 14] != 10 && _gameLogic.TamaNumList[g + 21] != 10 && _gameLogic.TamaNumList[g + 28] != 10 && _gameLogic.TamaNumList[g + 35] != 10 && _gameLogic.TamaNumList[g + 42] != 10 && _gameLogic.TamaNumList[g + 49] != 10 && _gameLogic.TamaNumList[g + 56] != 10 && _gameLogic.TamaNumList[g + 63] != 10 && _gameLogic.TamaNumList[g + 70] != 10)
        {
            GameOver();
        }
        else
        {
            //Nothing
        }
    }
}
