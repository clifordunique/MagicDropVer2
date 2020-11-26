using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{




    void Awake()
    {
        Screen.SetResolution(1080, 1920, false);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //Go To Lobby
    public void BtnGoToLobby()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("01LobbyScene");
    }
}
