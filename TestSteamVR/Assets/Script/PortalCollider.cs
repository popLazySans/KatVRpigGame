using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCollider : MonoBehaviour
{
    public bool isLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
        
            SceneManagers sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManagers>();
            
            //test
            //sceneManager.WinActive();
            if(isLevel == false)
                sceneManager.clickToAnotherScene("Play");
            else{
                PointManager pointManager = GameObject.FindGameObjectWithTag("PointManager").GetComponent<PointManager>();
                if (pointManager != null)
                    {
                        if (pointManager.Point >= 1000 && pointManager.Point <= 3000)
                        {
                        sceneManager.WinActive();
                        sceneManager.clickToAnotherScene("Play");
                        Destroy(this.gameObject);
                    }
                    else
                    {
                        sceneManager.TryAgain();
                    }
            }
            }
            

            
        }
    }
}
