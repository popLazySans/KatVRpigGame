using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class SceneManagers : MonoBehaviour,IPointerClickHandler
{
    public PortalSpawner portalSpawner;
    public TMP_Text winText;
    public string sceneName;
    SceneStateMachine stateMachine;
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void WinActive()
    {
        if(winText != null)
            winText.text = "Win";
    }
    public void TryAgain()
    {
       // if (winText != null)
           // winText.text = "Please Balance Your Energy.";
    }
    public void LoseActive()
    {
        if(winText != null)
            winText.text = "Lose";
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
