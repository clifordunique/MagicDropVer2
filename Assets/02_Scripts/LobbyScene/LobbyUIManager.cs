using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUIManager : MonoBehaviour
{
    //Popup
    public GameObject popupGameMode;

    //GameMode
    bool _clearRule;
    bool _clearTiming;
    bool _tamaCreate;
    public Button btnclearRuleHoriVer;
    public Button btnclearRuleTetris;
    public Button btnclearTimingAlways;
    public Button btnclearTimingAfterDrop;
    public Button btntamaCreateTop;
    public Button btntamaCreateBottom;

    [SerializeField] private LobbyLogic _lobbyLogic;




    void Awake()
    {
        ResetAll();
    }

    void Start()
    {
        
    }

    void Update()
    {
        GameModeButtonCheck();
    }

    //ResetAll        (void Awake)
    void ResetAll()
    {
        popupGameMode.gameObject.SetActive(false);
    }

    //GameMode Button Check       (void Update)
    void GameModeButtonCheck()
    {
        _clearRule = _lobbyLogic.clearRule;
        _clearTiming = _lobbyLogic.clearTiming;
        _tamaCreate = _lobbyLogic.tamaCreate;

        switch (_clearRule)
        {
            case true:
                btnclearRuleHoriVer.GetComponent<Image>().color = new Color(255 / 255f, 200 / 255f, 0 / 255f);
                btnclearRuleTetris.GetComponent<Image>().color = new Color(50 / 255f, 50 / 255f, 0 / 255f);
                break;
            case false:
                btnclearRuleHoriVer.GetComponent<Image>().color = new Color(50 / 255f, 50 / 255f, 0 / 255f);
                btnclearRuleTetris.GetComponent<Image>().color = new Color(255 / 255f, 200 / 255f, 0 / 255f);
                break;
        }

        switch (_clearTiming)
        {
            case true:
                btnclearTimingAlways.GetComponent<Image>().color = new Color(255 / 255f, 200 / 255f, 0 / 255f);
                btnclearTimingAfterDrop.GetComponent<Image>().color = new Color(50 / 255f, 50 / 255f, 0 / 255f);
                break;
            case false:
                btnclearTimingAlways.GetComponent<Image>().color = new Color(50 / 255f, 50 / 255f, 0 / 255f);
                btnclearTimingAfterDrop.GetComponent<Image>().color = new Color(255 / 255f, 200 / 255f, 0 / 255f);
                break;
        }

        switch (_tamaCreate)
        {
            case true:
                btntamaCreateTop.GetComponent<Image>().color = new Color(255 / 255f, 200 / 255f, 0 / 255f);
                btntamaCreateBottom.GetComponent<Image>().color = new Color(50 / 255f, 50 / 255f, 0 / 255f);
                break;
            case false:
                btntamaCreateTop.GetComponent<Image>().color = new Color(50 / 255f, 50 / 255f, 0 / 255f);
                btntamaCreateBottom.GetComponent<Image>().color = new Color(255 / 255f, 200 / 255f, 0 / 255f);
                break;
        }
    }

    //Popup GameMode Open
    public void BtnPopupGameModeOpen()
    {
        popupGameMode.gameObject.SetActive(true);
    }

    //Popup GameMode Close
    public void BtnPopupGameModeClose()
    {
        popupGameMode.gameObject.SetActive(false);
    }
}
