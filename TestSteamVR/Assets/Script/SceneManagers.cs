using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class SceneManagers : MonoBehaviour,IPointerClickHandler
{
    public PortalSpawner portalSpawner;
    public string sceneName;
    SceneStateMachine stateMachine;
    public PlayerSpeedHandler playerSpeedHandler;
    private ShowText showText;
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneStateMachine>();
        showText = GameObject.FindGameObjectWithTag("ShowText").GetComponent<ShowText>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void WinActive()
    {
        showText.ShowWinText();
    }
    public void TryAgain()
    {
       // if (winText != null)
           // winText.text = "Please Balance Your Energy.";
        showText.ShowTryAgainText();
    }
    public void LoseActive()
    {
        showText.ShowLoseText();
        playerSpeedHandler.stop();
    }
    public void clickToAnotherScene(string sceneName)
    {
        //UseForChangeByScene
        //SceneManager.LoadScene(sceneName);

        //UseForChangeByGameObject
        stateMachine.ChangeScene(sceneName);
    }
    public void exit()
    {
        Application.Quit();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        stateMachine.ChangeScene(sceneName);
        if (sceneName == "Exit")
            Application.Quit();
    }
}
