using System.Collections;
using UnityEngine;

public class GameOverLogic : MonoBehaviour
{
    private const string TargetTag = "Tama";

    [SerializeField] private GameLogic _gameLogic;
    [SerializeField] private GameUIManager _uiManager;

    // Start is called before the first frame update
    private void Start()
    {
        if (_gameLogic == null)
            _gameLogic = FindObjectOfType<GameLogic>();
    }

    //GameOver Check
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(TargetTag))
        {
            StartCoroutine(GameOverCheck());
        }
    }

    //GameOver Check Coroutine
    private IEnumerator GameOverCheck()
    {
        yield return new WaitForSeconds(0.5f);

        for (int column = 0; column < GameLogic.ColumnCount; column++)
        {
            var isGameOver = true;
            for (int row = 0; row < GameLogic.RowCount - 1; row++)
            {
                var index = column + row * GameLogic.ColumnCount;
                if (_gameLogic.TamaNumList[index] == GameLogic.TamaNull)
                {
                    isGameOver = false;
                    break;
                }
            }
            if (isGameOver == true)
            {
                GameOver();
                break;
            }
        }
    }

    //GameOver
    private void GameOver()
    {
        _uiManager.PopupGameOverOpen();
    }
}
