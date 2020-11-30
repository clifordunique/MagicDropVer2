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

    //GameOver Check Coroutine
    IEnumerator GameOverCheck()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < ColumnCount; i++)
        {
            var isNotGameOver = false;
            for (int j = 0; j <= RowCount; j++)
            {
                var checkIndex = j * ColumnCount;
                if (_gameLogic.TamaNumList[checkIndex] == RowCount)
                {
                    isNotGameOver = true;
                    break;
                }
            }
            if (isNotGameOver != true)
            {
                GameOver();
                break;
            }
        }
    }

    //GameOver
    void GameOver()
    {
        _uiManager.PopupGameOverOpen();
    }
}
