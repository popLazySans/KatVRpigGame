using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SceneStateMachine : MonoBehaviour
{
    [SerializeField] public int Scenenumber = 0;
    public List<GameObject> sceneGameObjects = new List<GameObject>();
    public LineRenderer pointer_LineRenderer;
    public GameObject VRcanvasGameObject;
    public GameObject directionalLightGameObject;
    public GameObject lightGameObject;
    // Start is called before the first frame update
    void Start()
    {
        ChangeScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeScene(string sceneName)
    {
        pointer_LineRenderer.enabled = false;
        foreach (GameObject gameObject in sceneGameObjects)
        {
            gameObject.SetActive(false);
        }
        if (sceneName == "Menu")
        {
            toMainMenu();
        }
        else if (sceneName == "Play")
        {
            toGameplay();
        }
        changeLight();
        sceneGameObjects[Scenenumber].SetActive(true);
    }
    public void toMainMenu()
    {
        Scenenumber = 0;
        pointer_LineRenderer.enabled = true;
        VRcanvasGameObject.SetActive(false);
    }
    public void toGameplay()
    {
        Scenenumber += 1;
        VRcanvasGameObject.SetActive(true);
    }
    public void changeLight()
    {
        if(sceneGameObjects[Scenenumber].tag == "NoonScene")
        {
            RenderSettings.ambientIntensity = 1.25f;
            lightGameObject.SetActive(false);
            directionalLightGameObject.SetActive(true);
        }
        else if (sceneGameObjects[Scenenumber].tag == "NightScene")
        {
            RenderSettings.ambientIntensity = 0f;
            lightGameObject.SetActive(true);
            directionalLightGameObject.SetActive(false);
        }
    }
}
