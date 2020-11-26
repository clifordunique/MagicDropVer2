using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbySceneManager : MonoBehaviour
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

    //Go To GameScene
    public void BtnGoToGameScene()
    {
        SceneManager.LoadScene("02GameScene");
    }
}
